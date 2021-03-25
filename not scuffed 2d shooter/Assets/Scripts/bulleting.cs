using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulleting : MonoBehaviour
{

    public float speed;
    public float lifeTime;

    public GameObject destroyEffect;
    public GameObject destroyEffect2;

    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right* speed * Time.deltaTime);
    }

    void DestroyProjectile1()
    {
        GameObject effect = Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(effect, 2f);
        Destroy(gameObject);
    }

     void DestroyProjectile2()
    {
        GameObject effect = Instantiate(destroyEffect2, transform.position, Quaternion.identity);
        Destroy(effect, 2f);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
       if (other.tag == "Ground")
       {
              DestroyProjectile1();
       }

       if (other.tag == "Enemy")
       {
           DestroyProjectile2();
       }

       if (other.tag == "Wall")
       {
           DestroyProjectile1();
       }
     
    }
}
