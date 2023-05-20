using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Idle : AStates
{
    private int timing;


    public Idle(PlayerController _player, StateMachine _state) : base(_player, _state)
    {
    }

    public override void OnBegin()
    {
        Debug.Log("Idle");
        animator.SetBool(transitionParam, false);
        timing = state.timer;
        animator.SetFloat(speedParam, 0.0f);
        nextState = PlayerEstates.Idle;
        movement = new Vector2(0.0f,0.0f);
        body.velocity = movement;
    }

    public override PlayerEstates OnUpdate() 
    {
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.1f || Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.1f)
        {
            nextState = PlayerEstates.Walk;
        }
        if (timing == 0) 
        {
            animator.SetBool(transitionParam, true);
        }

        return nextState;
    }
    public override void OnFixedUpdate()
    {
        timing -= 1;
    }
}
