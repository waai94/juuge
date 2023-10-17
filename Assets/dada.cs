using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterscriptplayer2 : MonoBehaviour
{
    private Rigidbody2D rb = null;
    public float speed;
     float hitpoint;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hitpoint = 100;
    }


    // Update is called once per frame
    void Update()
    {
        float horizonatlKey = Input.GetAxis("Horizontal2");
        float xSpeed = 0.0f;
        if (horizonatlKey > 0)
        {
            transform.localScale = new Vector3(5, 5, 5);
            xSpeed = speed;
            rb.velocity = new Vector2(xSpeed, rb.velocity.y);
        }
        else if (horizonatlKey < 0)
        {
            transform.localScale = new Vector3(-5, 5, 5);
            xSpeed = -speed;
            rb.velocity = new Vector2(xSpeed, rb.velocity.y);
        }
        else
        {
            xSpeed = 0.0f;
        }
        if (Input.GetKey("up"))
        {
            rb.velocity = new Vector2(xSpeed, 8);
        }
       
      
    }
}
