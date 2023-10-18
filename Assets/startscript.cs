using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startscript : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] GameObject textobj;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 3);
        text=textobj.GetComponent<Text>();
        GameObject sc = GameObject.FindGameObjectWithTag("UI");
        int round =sc.GetComponent<scoremanager>().round;
        text.text = "Round " + round+ "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Change()
    {
        text.text=("Let's Rock!");
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject go in player)
        {
            go.GetComponent<characterScriptplayer>().canmove = true;
            go.GetComponent<characterScriptplayer>().resetstats();
        }
    }
}
