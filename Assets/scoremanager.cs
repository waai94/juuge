using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoremanager : MonoBehaviour
{
    [SerializeField] Text p1tex;
    [SerializeField] Text p2tex;
    [SerializeField] Text win;
    GameObject[] players;
    [SerializeField] GameObject sui;
    public int round=1;
    // Start is called before the first frame update
    void Start()
    {
        win.enabled = (false);
        players = GameObject.FindGameObjectsWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        showplayerHP();
    }

    void showplayerHP()
    {

           characterScriptplayer ps =players[0].GetComponent<characterScriptplayer>();
        p2tex.text = ps.hitpoint.ToString();
 ps = players[1].GetComponent<characterScriptplayer>();
        p1tex.text = ps.hitpoint.ToString();

    }
    
  public  void wingame(int won)
    {
        win.enabled=(true);
        win.text=("Player " + (won+1) + " Win!!");
        switch (won)
        {
            case 0:
                win.color = new Color(0, 0, 255);
                win.text=("Player" + 2 + " win!");

                break;
            case 1:
             
                win.color = new Color(255, 0, 0);
                win.text = ("Player" + 1 + " win!");
                break;
        }
        foreach(GameObject p in players)
        {
            p.GetComponent<characterScriptplayer>().canmove = false;
           
        }
        Invoke("nextround", 2.5f);
    }
    void nextround()
    {
        round++;
        Instantiate(sui);
        win.enabled = false;
    }
}
