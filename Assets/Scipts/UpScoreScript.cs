using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpScoreScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameModeScipt GameMode=GameObject.Find("GameMode").GetComponent<GameModeScipt>();
        transform.localScale=new Vector2(transform.localScale.x*GameMode.Scale,transform.localScale.y*GameMode.Scale);
        Destroy(gameObject,1f);
    }
}
