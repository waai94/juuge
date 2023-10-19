using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscript : MonoBehaviour
{
    public bool knockup;
    public int direction = 1;
    [SerializeField] float speed = 10f;
    [SerializeField] Sprite red;
    [SerializeField] Sprite blue;
    public int team;
    bool doonce;
    [SerializeField]GameObject effect;

    private Rigidbody2D rb = null;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject.transform.parent.gameObject, 5f);
        switch (team)
        {
            case 0:
                GetComponent<SpriteRenderer>().sprite = red;
        break;
            case 1:
                GetComponent<SpriteRenderer>().sprite = blue;
                break;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity=new Vector2(speed * direction, 0);
        if (knockup)
        {
            transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&&!doonce)
        {
        
            collision.gameObject.GetComponent<characterScriptplayer>().damaged();
            if (knockup)
            {
                Instantiate(effect,collision.transform.position,this.transform.rotation);
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 50f);
                for(int i=0; i<3; i++)
                {
                    collision.gameObject.GetComponent<characterScriptplayer>().damaged();
                }
            }
         
            doonce=true;
            Destroy(this.gameObject.transform.parent.gameObject);
        }

        if (collision.CompareTag("Tile"))
        {
            Destroy(this.gameObject.transform.parent.gameObject);
        }


    }
}
