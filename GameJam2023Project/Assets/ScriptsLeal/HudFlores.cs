using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HudFlores : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i <7; i++){
            UpdateHud( i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHud(int i){
        TextMeshProUGUI textPro = gameObject.transform.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>();
        textPro.text = GameManager.flores[i] + "/" + GameManager.floresTotal[i];
    }
}
