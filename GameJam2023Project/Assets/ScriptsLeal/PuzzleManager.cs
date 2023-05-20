using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    public static int[] puzzleSequence;
    public Button[] buttons = new Button[4];

    public GameObject canvas;

    bool canPlay = false;
    int index;
    
    Color[] colors = new Color[] {new Color(255,0,0,255), new Color(0,0,255,255), new Color(0,255,0,255) ,new Color(255,255,0,255)};
    public void Start()
    {
        Debug.Log("Start");
        StartCoroutine(flashPuzzle());
    }
    void OnEnable()
    {
        index = 0;
        StartCoroutine(flashPuzzle());
    }

    IEnumerator flashPuzzle(){
        canPlay = false;
        yield return new WaitForSeconds(2);
        foreach(int i in puzzleSequence){
            Color oldColor = new Color(0,0,0,255);
            Image image = null;
            image = buttons[i].GetComponent<Image>();
            oldColor = image.color;
            image.color = colors[i];
            yield return new WaitForSeconds(2);
            image.color = oldColor;
        }
        canPlay = true;
    }

    public void checkButton(int i){
        if(!canPlay){
            //yield break;
            return;
        }

        Color oldColor = new Color(0,0,0,255);
        Image image = null;
        image = buttons[i].GetComponent<Image>();
        oldColor = image.color;
        image.color = colors[i];
        //yield return new WaitForSeconds(2);

        if(i == puzzleSequence[index]){
            index++;
        } else {
            index = 0;
            StartCoroutine(flashPuzzle());
        }
        
        if(index == puzzleSequence.Length){
            TopDownMovement.canMove = true;
            canvas.SetActive(false);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
