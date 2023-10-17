using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscript : MonoBehaviour
{

    public int direction = 1;
    [SerializeField] float speed = 10f;
    [SerializeField] Sprite red;
    [SerializeField] Sprite blue;
    public int team;
    bool doonce;

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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&&!doonce)
        {
            Debug.Log("hit");
            collision.gameObject.GetComponent<characterScriptplayer>().damaged();
            doonce=true;
            Destroy(this.gameObject.transform.parent.gameObject);
        }

        if (collision.CompareTag("Tile"))
        {
            Destroy(this.gameObject.transform.parent.gameObject);
        }


    }
}
