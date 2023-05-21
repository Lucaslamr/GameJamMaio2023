using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Flores { Centaurea, Girassol, Lirio, Orquidea, Rosa, Tulipa, Violeta};

public class PlantSpot : MonoBehaviour
{
    public GameObject corruptedTiles;
    public int[] puzzleSequence;
    public Flores flor;
    public HudFlores hud;

    public bool canPlay = true;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnFinishedMinigame(){
        GameManager.flores[((int)flor)] += 1;
        hud.UpdateHud((int)flor);
        corruptedTiles.SetActive(false);
        canPlay = false;
    }
}
