using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AStates
{
    protected PlayerEstates nextState;
    protected Vector2 movement;
    protected Rigidbody2D body;
    protected Animator animator;
    protected PlayerController player;
    protected StateMachine state;
    protected static readonly int speedParam = Animator.StringToHash("Speed");

    public AStates(PlayerController _player, StateMachine _state)
    {
        player = _player;
        animator = _player.GetComponent<Animator>();
        body = _player.GetComponent<Rigidbody2D>();
        state = _state;
    }
    public abstract void OnBegin();
    public abstract PlayerEstates OnUpdate();
    public abstract void OnFixedUpdate();
}
