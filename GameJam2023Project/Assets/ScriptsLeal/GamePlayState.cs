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
        GameManager.Instance.LoadScene("GamePlay");
        deaths = 0;
        starded = false;
    }
    public override EState OnUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space) && starded)
        {
            Color color = Camera.main.backgroundColor;
            color.b += 0.3f;
            Camera.main.backgroundColor = color;
            deaths++;
            if(deaths > 2)
                nextState = EState.GameOver;
        }

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
