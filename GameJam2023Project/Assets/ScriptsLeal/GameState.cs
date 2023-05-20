using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public enum EState { MainMenu, GamePlay, GameOver }


[System.Serializable]
public class GameState 
{
    private IState[] _states = { new MainMenuState(), new GamePlayState()};
    [SerializeField]
    private EState _currentState = EState.MainMenu;

    public void OnBegin()
    {
        _states[0].OnBegin();
    }

    public void OnUpdate()
    {
        EState nextState = _states[(int)_currentState].OnUpdate();
        if (nextState != _currentState)
            ChangeState(nextState);
    }

    private void ChangeState(EState nextState)
    {
        _states[(int)_currentState].OnEnd();
        _states[(int)nextState].OnBegin();
        _currentState= nextState;
    }
}
