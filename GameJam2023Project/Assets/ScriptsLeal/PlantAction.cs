using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantAction : MonoBehaviour
{
    public GameObject canvasPuzzle;
    CapsuleCollider2D _collider;
    public int[] puzzleSequence;

    LayerMask layer;

    bool canStart;
    void Start()
    {
        _collider = gameObject.GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!canStart)
        {
            return;
        }
            
        if(Input.GetKeyDown(KeyCode.Space) ){
            TopDownMovement.canMove = false;
            Debug.Log(TopDownMovement.canMove);
            canvasPuzzle.SetActive(true);
            PuzzleManager.puzzleSequence = puzzleSequence;
        }
    }

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlantSpot"))
        {
            // Player entered the trigger
            canStart = true;
            if(other.GetComponent<PlantSpot>() != null)
                puzzleSequence = other.GetComponent<PlantSpot>().puzzleSequence;
            Debug.Log("Player entered the trigger.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PlantSpot"))
        {
            // Player exited the trigger
            canStart = false;
            Debug.Log("Player exited the trigger.");
        }
    }
    
    
}
