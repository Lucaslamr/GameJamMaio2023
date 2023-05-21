using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Flores { Centaurea, Girassol, Lirio, Orquidea, Rosa, Tulipa, Violeta};

public class PlantSpot : MonoBehaviour
{
    public PuzzleView puzzleView;
    public Sprite flowerSprite;
    public int[] puzzleSequence;
    public Flores flor;
    

    public bool canPlay = true;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnFinishedMinigame(){
        gameObject.GetComponent<SpriteRenderer>().sprite = flowerSprite;
        puzzleView.verificaCompletou(((int)flor));
        canPlay = false;
    }
}
