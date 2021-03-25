using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    public float offset;
    
    public GameObject projectile;
    public Transform shotPoint;

    float timeBtwShots;
    public float startTimeBtwShots;

    
    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

if (timeBtwShots <= 0)
{
      if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(projectile, shotPoint.position, shotPoint.rotation);
            timeBtwShots = startTimeBtwShots;
        }
}

else
{
    timeBtwShots -= Time.deltaTime;
}
      
    }
}
