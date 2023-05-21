using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Idle : AStates
{
    private int timing;
    private float fadeTiming;
    private bool faded;

    


    public Idle(PlayerController _player, StateMachine _state) : base(_player, _state)
    {
    }

    public override void OnBegin()
    {
        Debug.Log("Idle");
        //audioSource.Stop();
        faded = false;
        fadeTiming = 0.0f;
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
            if(!puzzles)
                nextState = PlayerEstates.Walk;
        }
        if (timing == 0) 
        {
            animator.SetBool(transitionParam, true);
        }
        //Fade Out steps

        if(fadeTiming < state.fadeDuration)
        {
            fadeTiming += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(0.48f, 0.0f, fadeTiming/state.fadeDuration);
        }
        else if(!faded)
        {
            audioSource.Stop();
            faded = true;
        }


        return nextState;
    }
    public override void OnFixedUpdate()
    {
        timing -= 1;

    }
}
