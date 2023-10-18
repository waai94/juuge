using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterScriptplayer : MonoBehaviour
{
    private Rigidbody2D rb = null;
    public float speed;
   public  float hitpoint=3;
    [SerializeField] private string control = "Horizontal1";
    [SerializeField] private string jumpkey = "Jump1";
    bool isjumped = false;
    float yvelocity = 0;
    [SerializeField] private string firekey = "Fire1";
    [SerializeField] private string skillkey = "Skill1";
[SerializeField] private float jumpvelocity = 30f;
    public GameObject mybullet;
    float bulletcooltime;
    public int playernum = 0;
    bool onground;
    GameObject scoreUI;
    public bool canmove;
    bool doonced;
    Vector3 firstpos;
    bool skillused;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hitpoint = 100;
        scoreUI = GameObject.FindGameObjectWithTag("UI");
        firstpos = this.transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        yvelocity = rb.velocity.y;



        if (canmove)
        {
            movement();
            skillpressed();
            fireprogram(false);
            bulletcooltime -= Time.deltaTime;
        }
        
    }

    void movement()
    {
        float horizonatlKey = Input.GetAxis(control);
        float xSpeed = 0.0f;
        float jumpinput=Input.GetAxis(jumpkey);

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
        if (iszimen()&&jumpinput>0)
        {
            rb.velocity = new Vector2(xSpeed, jumpvelocity);
            isjumped = true;
            Debug.Log("jump!");
        }

        if (yvelocity == 0)
        {
            isjumped = false;
        }

    }

    void fireprogram(bool isskill)
    {
        float firekeypressed = Input.GetAxis(firekey);
        if (firekeypressed > 0&&bulletcooltime<=0)
        {
            float  direc = (this.transform.localScale.x);
            int mydirec;
            bulletcooltime = 0.01f;
            if (direc > 0)
            {
                mydirec = 1;
            }
            else
            {
                mydirec = -1;
            }
         GameObject spawned=Instantiate(mybullet,this.transform.position+new Vector3(mydirec,0,0),this.transform.rotation);
            GameObject bulletchild = spawned.transform.GetChild(0).gameObject;
            bulletscript bs = bulletchild.GetComponent<bulletscript>();
            bs.team = playernum;
            bs.knockup = isskill;
            
            bs.direction = mydirec;

         
        }
    }

    void skillpressed()
    {
        float skillpress = Input.GetAxis(skillkey);
        if (skillpress > 0)
        {
            skillused=true;
            fireprogram(skillused);

        }
        else
        {
            skillused = false;
        }
    }
    bool iszimen()
    {
       
        return onground;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tile"))
        {
            onground = true;
        }
        if (collision.CompareTag("Player") && skillused)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 100f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Tile"))
        {
            onground = false;
        }
    }

    public void damaged()
    {
        hitpoint -= 1;
        if (hitpoint <= 0&&!doonced)
        {
            scoreUI.GetComponent<scoremanager>().wingame(playernum);
            doonced = true;
        }
    }

    public void resetstats()
    {
        hitpoint = 100;
        doonced = false;
        transform.position = firstpos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Player" && skillused)
        {
        //    collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 100f);
        }
    }
}
