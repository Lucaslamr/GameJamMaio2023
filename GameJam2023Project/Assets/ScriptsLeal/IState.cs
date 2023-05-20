using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IState 
{
    protected EState nextState;

    public abstract void OnBegin();
    public abstract EState OnUpdate();
    public abstract void OnEnd();
}
