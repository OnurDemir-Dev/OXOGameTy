using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameModeScipt : MonoBehaviour
{
    public int Grid=3;
    public int[,] GridArray;
    public float Scale=0;
    public GameObject[,] XArray;
    public GameObject Prefab;
    public GameObject[,] GridObjArray;



    public void SetArray()
    {
        GridArray=new int[Grid,Grid];
        XArray=new GameObject[Grid,Grid];
        GridObjArray=new GameObject[Grid,Grid];
    }

    public void CreateGrid()
    {
        SetArray();
        for(int i=0;i<Grid;i++)
        {
            for(int j=0;j<Grid;j++)
            {
                GameObject InstantObject=Instantiate(Prefab, new Vector2(j*Scale+(Scale-1)/2,i*Scale+(Scale-1)/2), Quaternion.identity);
                GridScript instantgid=InstantObject.GetComponent<GridScript>();
                GridObjArray[i,j]=InstantObject;
                instantgid.Column=j;
                instantgid.Row=i;
            }
        }
    }

    public void SetScale()
    {
        Scale=8.0f/Grid;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetScale();
        CreateGrid();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
    }
}
