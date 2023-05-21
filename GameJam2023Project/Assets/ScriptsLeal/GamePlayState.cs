using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayState : IState
{
    int deaths;
    bool starded = false;

    public override void OnBegin()
    {
        nextState = EState.GamePlay;
        GameManager.Instance.OnSceneLoaded += OnSceneLoaded;
        GameManager.Instance.LoadScene("Mapa");
        deaths = 0;
        starded = false;
    }
    public override EState OnUpdate()
    {
        return nextState;
    }

    private void OnSceneLoaded(string sceneName)
    {
        starded = true;
    }

    public override void OnEnd()
    {
        GameManager.Instance.OnSceneLoaded -= OnSceneLoaded;
    }
}
