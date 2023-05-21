using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlantAction : MonoBehaviour
{
    public TextMeshProUGUI textMessage;
    public GameObject canvasPuzzle;
    public GameObject canvasFlowers;
    CapsuleCollider2D _collider;
    int[] puzzleSequence;
    public static PlantSpot plantSpot;

    KeyCode plantKey = KeyCode.Space;

    LayerMask layer;

    bool canStart;
    void Start()
    {
        _collider = gameObject.GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update() {
        if(!canStart)
        {
            return;
        }
            
        if(Input.GetKeyDown(plantKey)  && plantSpot.canPlay ){
            TopDownMovement.canMove = false;
            canvasPuzzle.SetActive(true);
            canvasFlowers.SetActive(false);
            PuzzleManager.puzzleSequence = puzzleSequence;
            PuzzleManager.plantSpot = plantSpot;
            textMessage.text = "";
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("PlantSpot"))
        {
            // Player entered the trigger
            canStart = true;
            if(other.GetComponent<PlantSpot>() != null){
                plantSpot = other.GetComponent<PlantSpot>();
                puzzleSequence = plantSpot.puzzleSequence;
                if(plantSpot.canPlay){
                    textMessage.text = "Aperte '"+ plantKey +"' para plantar";
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("PlantSpot")) {
            canStart = false;
        }

        textMessage.text = "";
    }
    
    
}
