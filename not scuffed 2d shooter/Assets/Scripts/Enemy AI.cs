using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float MovementSpeed = 1f;
    public float JumpForce = 1f;

    public bool isgrounded;

    public Rigidbody2D rb2d; 

    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        if(Input.GetKey("d"))
        {
            rb2d.AddForce(new Vector2(MovementSpeed, 0));
        }

        if(Input.GetKey("a"))
        {
            rb2d.AddForce(new Vector2(-MovementSpeed, 0));
        }
       

        
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && isgrounded == true)
        {
            rb2d.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }

       

        
    }
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            isgrounded = true;
        }
       
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            isgrounded = false;
        }
    }

    
}


