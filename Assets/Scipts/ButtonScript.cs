using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    GameModeScipt GetModeSciptt;
        public void AllReset()
    {
        int number;
        Text txt=GameObject.Find("EnterTxt").GetComponent<Text>();
        Text Counttxt=GameObject.Find("CountTxt").GetComponent<Text>();
        if(int.TryParse(txt.text, out number))
        {
            if(number>0){
            foreach(GameObject i in GameObject.FindObjectsOfType<GameObject>())
            {
                if(i.name=="Grid Object")
                {
                    Destroy(i);
                }
                if(i.name=="X(Clone)")
                {
                    Destroy(i);
                }
            }
            GetModeSciptt.Grid=number;
            GetModeSciptt.SetScale();
            GetModeSciptt.CreateGrid();
            Counttxt.text="0";
            }
        }
        
        
    }
    // Start is called before the first frame update
    void Start()
    {
        GetModeSciptt=GameObject.Find("GameMode").GetComponent<GameModeScipt>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
