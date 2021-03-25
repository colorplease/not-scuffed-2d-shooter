using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;



public class what : Agent
{
   public float MovementSpeed1 = 1f;
    public float JumpForce1 = 1f;
    public float HP;
    public float maxHP;

    public bool isgrounded1;

    public Rigidbody2D rb2d; 

    public HealthController HealthBar;

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

        if (other.tag == "Bullet")
        {
            HP -= 20;
            HealthBar.SetHealth(HP, maxHP);

            if(HP <= 0)
            {
               Destroy(gameObject); 
            }
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
         if (Input.GetKeyDown("space") && isgrounded1 == true)
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

    public override void OnEpisodeBegin()
    {
        HP = maxHP;
        HealthBar.SetHealth(HP, maxHP);
    }

    

    
}

