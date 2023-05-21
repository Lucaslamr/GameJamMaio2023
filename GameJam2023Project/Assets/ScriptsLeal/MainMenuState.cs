using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuState : IState
{
    public override void OnBegin()
    {
        nextState = EState.GamePlay;
        GameManager.Instance.OnSceneLoaded += OnSceneLoaded;
        GameManager.Instance.LoadScene("Mapa");

    }
    public override EState OnUpdate()
    {
        return nextState;
    }

    private void OnSceneLoaded(string sceneName)
    {
        GameObject.FindObjectOfType<Button>()?.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        nextState = EState.GamePlay;
    }

    public override void OnEnd()
    {
        GameManager.Instance.OnSceneLoaded-= OnSceneLoaded; 
    }

}
