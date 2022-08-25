using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineManager : MonoBehaviour
{
    public bool isReady;
    public enum State
    {
        Idle,
        Move,
        Jump,
        Fall,
        Attack,
        Dash,
        Slide,
        Crouch,        
        Hurt,
        Die
    }

    public State state;

    private Dictionary<State, StateMachineBase> _machines = new Dictionary<State, StateMachineBase>();
    private Dictionary<KeyCode, State> _states = new Dictionary<KeyCode, State>();
    // -1 : left , +1 : right
    private int _direction;
    public int direction
    {
        get
        {
            return _direction;
        }
        set
        {
            if (value < 0)
            {
                _direction = -1;
                transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
            }
            else
            {
                _direction = 1;
                transform.eulerAngles = Vector3.zero;
            }
        }
    }
    
    [SerializeField] private int _directionInit;
    public bool isMovable { get; set; }
    public bool isDirectionChangable { get; set; }
    private Vector2 _move;

    [SerializeField] private float _moveSpeed = 2.0f;

    private AnimationManager _animationManager;
    private StateMachineBase _current;
    private Rigidbody2D _rb;
    private Player _player;

    [SerializeField] private Vector2 _attackHitCastCenter = new Vector2(0.2f, 0.2f);
    [SerializeField] private Vector2 _attackHitCastSize = new Vector2(0.4f, 0.4f);
    [SerializeField] private LayerMask _attackTargetLayer;

    private float h => Input.GetAxis("Horizontal");
    private float v => Input.GetAxis("Vertical");
    //==============================================================================
    //**********************************Public Method*******************************
    //==============================================================================

    public void ChangeState(State newState)
    {
        if (state == newState ||
            _machines[newState].IsExecuteOK() == false)
            return;

        _machines[state].ForceStop();
        _machines[newState].Execute();
        _current = _machines[newState];
        state = newState;
    }
    public void ReSetVelocity()
    {
        _move.x = 0.0f;
        _rb.velocity = Vector2.zero;
    }

    //==============================================================================
    //**********************************Public Method*******************************
    //==============================================================================
    private void Awake()
    {
        StartCoroutine(E_Init());                
    }

    IEnumerator E_Init()
    {
        direction = _directionInit;
        _animationManager = GetComponent<AnimationManager>();
        _rb = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();
        yield return new WaitUntil(() => _animationManager.isReady);

        InitStateMachines();
        _current = _machines[State.Idle];
        _current.Execute();

        isReady = true;
    }


    private void InitStateMachines()
    {
        Array values = Enum.GetValues(typeof(State));
        foreach (int value in values)
        {
            AddStateMachine((State)value);
        }
    } 

    private void AddStateMachine(State state)
    {
        if (_machines.ContainsKey(state))
            return;

        string typeName = "StateMachine" + state.ToString();
        Type type = Type.GetType(typeName);
        if (type != null)
        {
           ConstructorInfo constructorInfo =
            type.GetConstructor(new Type[]
            {
                typeof(State),
                typeof(StateMachineManager),
                typeof(AnimationManager)

            });

            StateMachineBase machine =
            constructorInfo.Invoke(new object[]
            {
                state,
                this,
                _animationManager
            }) as StateMachineBase;

            _machines.Add(state, machine);
            if (machine.shortKey != KeyCode.None)
            _states.Add(machine.shortKey, state);

            Debug.Log($"{state} �� �ӽ��� ��� �Ǿ����ϴ�.");
        }
        else
        {
            Debug.LogWarning($"{state} �� �ӽ��� ã�� �� �����ϴ�.");
        }
    }

    private void Update()
    {
        if (isReady == false)
            return;

        if (isDirectionChangable)
        {
            if (h < 0.0f)
                direction = -1;
            else if (h > 0.0f)
                direction = 1;
        }

        if (isMovable)
        {
            _move.x = h;

            if (Mathf.Abs(_move.x) > 0.0f)
                ChangeState(State.Move);
            else
                ChangeState(State.Idle);
        }

        foreach (var shortKey in _states.Keys)
        {
            if (Input.GetKeyDown(shortKey))
            {
                ChangeState(_states[shortKey]);
                return;
            }
        }
        ChangeState(_current.UpdateState());
    }

    private void FixedUpdate()
    {
        if (isReady == false)
            return;

        _current.FixedUpdateState();
        transform.position += new Vector3(_move.x * _moveSpeed, _move.y, 0) * Time.fixedDeltaTime;
    }

    

    private void AttackHit()
    {
        Vector2 attackCenter = new Vector2(_attackHitCastCenter.x * _direction,
                                           _attackHitCastCenter.y) + _rb.position;
        RaycastHit2D hit = Physics2D.BoxCast(attackCenter,
                                             _attackHitCastSize,
                                             0,
                                             Vector2.zero,
                                             0,
                                             _attackTargetLayer);
        if (hit.collider != null)
        {
            if (hit.collider.TryGetComponent(out Enemy enemy))
            {
                enemy.Hurt(_player.damage);
            }
            if (hit.collider.TryGetComponent(out EnemyController enemyController))
            {
                enemyController.KnockBack(_direction);
            }
        }
    }
}
