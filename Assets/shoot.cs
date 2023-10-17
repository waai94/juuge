using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject player;
    public float shotSpeed;
    private float shotInterval;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("g"));
        {
            if (shotInterval <= 0)
            {
                shotInterval += 1;
            }
           
            
        }
        shotInterval -= Time.deltaTime;
    }
}
