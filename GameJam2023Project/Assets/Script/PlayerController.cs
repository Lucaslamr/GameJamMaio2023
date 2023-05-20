using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private StateMachine state = new StateMachine();
    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        state.OnBegin(this);
    }

    // Update is called once per frame
    void Update()
    {
        state.OnUpdate();
    }

    private void FixedUpdate()
    {
        state.OnFixedUpdate();
    }
}
