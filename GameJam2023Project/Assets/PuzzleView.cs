using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleView : MonoBehaviour
{
    public GameObject corruptedTiles;
    public GameObject purifiedTiles;
    public HudFlores hud;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void verificaCompletou(int flor){
        GameManager.flores[((int)flor)] += 1;
        if(GameManager.flores[((int)flor)] == GameManager.floresTotal[((int)flor)]){
            corruptedTiles.SetActive(false);
            purifiedTiles.SetActive(true);
        }
        hud.UpdateHud((int)flor);
    }


}
