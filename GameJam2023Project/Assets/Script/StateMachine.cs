using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerEstates {Idle, Walk}
public class StateMachine
{
    [SerializeField]
    private PlayerEstates currentState;
    private PlayerEstates nextState;
    private AStates[] states;
    [Header("Movement")]
    public float moveSpeed = 5f;

    public void OnBegin(PlayerController player) 
    {
        states = new AStates[] {new Idle(player, this), new Walk(player, this)};
        currentState = PlayerEstates.Idle;
        nextState = PlayerEstates.Idle;
    }
    public void OnUpdate()
    {
        nextState = states[(int)currentState].OnUpdate();
        if (nextState != currentState)
        {
            states[(int)nextState].OnBegin();
            currentState = nextState;
        }
    }
    public void OnFixedUpdate()
    {
        states[(int)currentState].OnFixedUpdate();
    }
}
