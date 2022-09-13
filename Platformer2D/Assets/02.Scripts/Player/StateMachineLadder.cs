using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineLadder : StateMachineBase
{
    private LadderDetector _ladderDetector;
    private GroundDetector _groundDetector;
    private CapsuleCollider2D _col;
    private Rigidbody2D _rb;
    private float _speed = 2.0f;

    public StateMachineLadder(StateMachineManager.State machineState,
                              StateMachineManager manager,
                              AnimationManager animationManager)
        : base(machineState, manager, animationManager)
    {
        _ladderDetector = manager.GetComponent<LadderDetector>();
        _groundDetector = manager.GetComponent<GroundDetector>();
        _col = manager.GetComponent<CapsuleCollider2D>();
        _rb = manager.GetComponent<Rigidbody2D>();
    }

    public override void Execute()
    {
        manager.isMovable = false;
        manager.isDirectionChangable = false;
        animationManager.speed = 0.0f;
        _rb.bodyType = RigidbodyType2D.Kinematic;
        state = State.Prepare;
    }

    public override void FixedUpdateState()
    {
        
    }

    public override void ForceStop()
    {
        _rb.bodyType = RigidbodyType2D.Dynamic;
        state = State.Idle;
    }

    public override bool IsExecuteOK()
    {
        bool isOK = false;
        if ((_ladderDetector.isGoUpPossible ||
            _ladderDetector.isGoDownPossible) &&
            (manager.state == StateMachineManager.State.Idle ||
             manager.state == StateMachineManager.State.Move ||
             manager.state == StateMachineManager.State.Jump ||
             manager.state == StateMachineManager.State.Slide||
             manager.state == StateMachineManager.State.Dash ||
             manager.state == StateMachineManager.State.Fall ||
             manager.state == StateMachineManager.State.Crouch))
            isOK = true;
        return isOK;

    }

    public override StateMachineManager.State UpdateState()
    {
        StateMachineManager.State nextState = managerState;

        switch (state)
        {
            case State.Idle:
                break;
            case State.Prepare:
                manager.ResetVelocity();
                animationManager.Play("Ladder");

                if (_ladderDetector.isGoUpPossible)
                {                    
                    _rb.position = new Vector2(_ladderDetector.ladderBottomPoint.x,
                                               _rb.position.y + _col.size.y * 0.5f);
                }
                else if (_ladderDetector.isGoDownPossible)
                {
                    _rb.position = new Vector2(_ladderDetector.ladderTopPoint.x,
                                               _rb.position.y - _col.size.y * 0.5f);
                }
                state = State.OnAction;

                break;
            case State.Casting:
                break;
            case State.OnAction:
                float v = Input.GetAxisRaw("Vertical");
                animationManager.speed = Mathf.Abs(v);
                _rb.MovePosition(_rb.position + Vector2.up * v * _speed *  Time.deltaTime);

                // ��ٸ� �Ʒ��� �������� ����
                if (_rb.position.y + (_col.size.y / 2.0f) < _ladderDetector.ladderBottomPoint.y ||
                    _rb.position.y < _ladderDetector.ladderBottomPoint.y && _groundDetector.isDetected)

                {
                    state = State.Finish;
                }
                //��ٸ� ���� �ö󰡴� ����
                else if (_rb.position.y + (_col.size.y / 4.0f) > _ladderDetector.ladderTopPoint.y)
                {
                    _rb.position = _ladderDetector.ladderTopPoint;
                    state = State.Finish;
                }

                //����

                if (Input.GetKey(KeyCode.LeftAlt))
                {
                    if (manager.h < 0)
                        manager.direction = -1;
                    else if (manager.h > 0)
                        manager.direction = 1;

                    if (manager.direction != 0)
                    {
                        manager.move.x = manager.h;
                        manager.ForceChangeState(StateMachineManager.State.Jump);
                        nextState = StateMachineManager.State.Jump;
                    }                    
                }

                break;
            case State.Finish:
                nextState = StateMachineManager.State.Idle;
                break;
            case State.Error:
                break;
            case State.WaitForErrorClear:
                break;
            default:
                break;
        }
        return nextState;
    }
}
