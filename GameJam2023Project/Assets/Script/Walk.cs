using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : AStates
{
    private SpriteRenderer srenderer;

    public Walk(PlayerController _player, StateMachine _state) : base(_player, _state)
    {
        srenderer = _player.GetComponent<SpriteRenderer>();
    }

    public override void OnBegin()
    {
        nextState = PlayerEstates.Walk;
    }
    public override PlayerEstates OnUpdate()
    {
        animator.SetFloat(speedParam, Mathf.Abs(body.velocity.x));
        movement = new Vector2(Input.GetAxisRaw("Horizontal") * state.moveSpeed, 0.0f);
        if (movement.sqrMagnitude > 0.1f)
        {
            srenderer.flipX = !(movement.x > 0.0f);
        }
        else
        {
            nextState = PlayerEstates.Idle;
        }

        return nextState;
    }
    public override void OnFixedUpdate()
    {
        // Normalize the movement vector to maintain consistent speed in all directions
        movement.Normalize();

        // Move the rigidbody
        body.velocity = movement * state.moveSpeed;
    }
}
