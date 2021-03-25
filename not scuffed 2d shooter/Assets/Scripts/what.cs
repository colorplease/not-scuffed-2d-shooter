using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;



public class what : Agent
{
   public float MovementSpeed1 = 1f;
    public float JumpForce1 = 1f;

    public bool isgrounded1;

    public Rigidbody2D rb2d; 

    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            isgrounded1 = true;
        }
       
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            isgrounded1 = false;
        }
    }

    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = 0;
        actionsOut[1] = 3;
         if (Input.GetButtonDown("Jump") && isgrounded1 == true)
        {
            actionsOut[0] = 1; 
        }

        if(Input.GetKey("right"))
        {
              actionsOut[1] = 0;
        }

        if(Input.GetKey("left"))
        {
                 actionsOut[1] = 1;
        }
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        if(Mathf.FloorToInt(vectorAction[0]) == 1)
        {
            rb2d.AddForce(new Vector2(0, JumpForce1), ForceMode2D.Impulse);
        }

        if(Mathf.FloorToInt(vectorAction[1]) == 0)
        {
           rb2d.AddForce(new Vector2(MovementSpeed1, 0));
        }

        if(Mathf.FloorToInt(vectorAction[1]) == 1)
        {
           rb2d.AddForce(new Vector2(-MovementSpeed1, 0));
        }
    }

    

    
}

