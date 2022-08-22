using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineJump : StateMachineBase
{
    private GroundDetector _groundDetector;
    private Rigidbody2D _rb;
    private float _jumpForce = 2.0f;
    public StateMachineJump(StateMachineManager.State machineState,
                            StateMachineManager manager,
                            AnimationManager animationManager)
        : base(machineState, manager, animationManager)
    {
        _groundDetector = manager.GetComponent<GroundDetector>();
        _rb = manager.GetComponent<Rigidbody2D>();
    }

    public override void Execute()
    {
        manager.isMovable = false;
        manager.isDirectionChangable = false;
        state = State.Prepare;
    }

    public override void FixedUpdateState()
    {
    }   

    public override void ForceStop()
    {
        state = State.Idle;
    }

    public override bool IsExecuteOK()
    {
        bool isOK = false;
        if (_groundDetector.isDetected &&
            manager.state != StateMachineManager.State.Jump &&
            manager.state != StateMachineManager.State.Fall &&
            manager.state != StateMachineManager.State.DownJump&&
            manager.state != StateMachineManager.State.Crouch)
            isOK = true;
        return isOK;
    }

    public override StateMachineManager.State UpdateState()
    {
        StateMachineManager.State nextState = machineState;
        switch (state)
        {
            case State.Idle:
                break;
            case State.Prepare:
                animationManager.Play("Jump");
                _rb.velocity = new Vector2(_rb.velocity.x, 0);
                _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                state++;
                break;
            case State.Casting:
                if (_groundDetector.isDetected == false)
                {
                    state++;
                }
                break;
            case State.OnAction:
                if (_rb.velocity.y > 0)
                {
                    nextState = StateMachineManager.State.Idle;
                }
                break;
            case State.Finish:
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
