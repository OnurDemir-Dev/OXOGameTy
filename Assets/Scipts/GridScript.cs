using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridScript : MonoBehaviour
{
    public int Column,Row;
    public float Size;
    public bool IsClicked=false;
    GameModeScipt GameModeSciptt;
    public GameObject Xobject;
    public GameObject InstantObject;
    
    public GameObject UpObj;
    void GetGameMode()
    {
        GameModeSciptt=GameObject.Find("GameMode").GetComponent<GameModeScipt>();
    }
    void GetandSetGameModeValues()
    {
        Size=GameModeSciptt.Scale;
        transform.localScale=new Vector3(Size,Size,1f);
    }

    void SetXArray(GameObject instant)
    {
        GameModeSciptt.XArray[Row,Column]=instant;
    }

    void SetArrayFull()
    {
        GameModeSciptt.GridArray[Row,Column]=1;
    }

    void CreateX()
    {
        InstantObject=Instantiate(Xobject, this.transform.position, Quaternion.identity);
        InstantObject.transform.localScale=new Vector2(Size,Size);
        SetXArray(InstantObject);
        SetArrayFull();
        IsClicked=true;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.name="Grid Object";
        GetGameMode();
        GetandSetGameModeValues();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
    }

    void OnMouseDown()
    {
        if(IsClicked==false)
        {
            int counter=1;
            List<GameObject> GameObj=new List<GameObject>();
            if(Row!=GameModeSciptt.Grid-1){
                //For Upper
            if(GameModeSciptt.GridArray[Row+1,Column]==1)
            {
                GameObj.Add(GameModeSciptt.GridObjArray[Row+1,Column]);
                counter+=1;
                if(Column!=0){
                    if(GameModeSciptt.GridArray[Row+1,Column-1]==1)
                    {
                        GameObj.Add(GameModeSciptt.GridObjArray[Row+1,Column-1]);
                        counter+=1;
                    }
                }
                if(Row<=GameModeSciptt.Grid-3)
                {
                    if(GameModeSciptt.GridArray[Row+2,Column]==1)
                    {
                        GameObj.Add(GameModeSciptt.GridObjArray[Row+2,Column]);
                        counter+=1;
                    }
                }
                if(Column!=GameModeSciptt.Grid-1){
                    if(GameModeSciptt.GridArray[Row+1,Column+1]==1)
                    {
                        GameObj.Add(GameModeSciptt.GridObjArray[Row+1,Column+1]);
                        counter+=1;
                    }
                }
            }
            }
            if(Column!=GameModeSciptt.Grid-1){
                //For Right
            if(GameModeSciptt.GridArray[Row,Column+1]==1)
            {
                GameObj.Add(GameModeSciptt.GridObjArray[Row,Column+1]);
                counter+=1;
                if(Row!=GameModeSciptt.Grid-1){
                    if(GameModeSciptt.GridArray[Row+1,Column+1]==1)
                    {
                        GameObj.Add(GameModeSciptt.GridObjArray[Row+1,Column+1]);
                        counter+=1;
                    }
                }
                if(Column<GameModeSciptt.Grid-2){
                    if(GameModeSciptt.GridArray[Row,Column+2]==1)
                    {
                        GameObj.Add(GameModeSciptt.GridObjArray[Row,Column+2]);
                        counter+=1;
                    }
                }
                if(Row!=0){
                    if(GameModeSciptt.GridArray[Row-1,Column+1]==1)
                    {
                        GameObj.Add(GameModeSciptt.GridObjArray[Row-1,Column+1]);
                        counter+=1;
                    }
                }
                
            }
            }
            if(Row!=0)
            {
                //For bottom
                if(GameModeSciptt.GridArray[Row-1,Column]==1)
                {
                    GameObj.Add(GameModeSciptt.GridObjArray[Row-1,Column]);
                    counter+=1;
                    if(Column!=GameModeSciptt.Grid-1)
                    {
                        if(GameModeSciptt.GridArray[Row-1,Column+1]==1)
                        {
                            GameObj.Add(GameModeSciptt.GridObjArray[Row-1,Column+1]);
                            counter+=1;
                        }
                    }
                    if(Row>=2){
                        if(GameModeSciptt.GridArray[Row-2,Column]==1)
                        {
                            GameObj.Add(GameModeSciptt.GridObjArray[Row-2,Column]);
                            counter+=1;
                        }
                    }
                    if(Column!=0)
                    {
                        if(GameModeSciptt.GridArray[Row-1,Column-1]==1)
                        {
                            GameObj.Add(GameModeSciptt.GridObjArray[Row-1,Column-1]);
                            counter+=1;
                        }
                    }
                }
            }
            if(Column!=0){
                //For Left
                if(GameModeSciptt.GridArray[Row,Column-1]==1)
                {
                    GameObj.Add(GameModeSciptt.GridObjArray[Row,Column-1]);
                    counter+=1;
                    if(Row!=0){
                        if(GameModeSciptt.GridArray[Row-1,Column-1]==1)
                        {
                            GameObj.Add(GameModeSciptt.GridObjArray[Row-1,Column-1]);
                           counter+=1;
                        }
                    }
                    if(Column>=2 && Column<GameModeSciptt.GridArray.Length)
                    {
                        if(GameModeSciptt.GridArray[Row,Column-2]==1)
                        {
                            GameObj.Add(GameModeSciptt.GridObjArray[Row,Column-2]);
                            counter+=1;
                        }
                    }
                    if(Row!=GameModeSciptt.Grid-1)
                    {
                        if(GameModeSciptt.GridArray[Row+1,Column-1]==1)
                        {
                            GameObj.Add(GameModeSciptt.GridObjArray[Row+1,Column-1]);
                            counter+=1;
                        }
                    }
                }
            }
            if(counter>=3)
            {
                Instantiate(UpObj,transform.position,Quaternion.identity);
                for(int i=0;i<=GameObj.Count-1;i++)
                {
                    GridScript InstantGridScript=GameObj[i].GetComponent<GridScript>();
                    Instantiate(UpObj,GameObj[i].transform.position,Quaternion.identity);
                    int InstantColumn=InstantGridScript.Column;
                    int InstantRow=InstantGridScript.Row;
                    GameModeSciptt.GridArray[InstantRow,InstantColumn]=0;
                    InstantGridScript.IsClicked=false;
                    Destroy(GameModeSciptt.XArray[InstantRow,InstantColumn]);
                }
                Text txt=GameObject.Find("CountTxt").GetComponent<Text>();
                txt.text=(counter+int.Parse(txt.text)).ToString();
            }
            else
            {
                CreateX();
            }
        }
        
    }
}
