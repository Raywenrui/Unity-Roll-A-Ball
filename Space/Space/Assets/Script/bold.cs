using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bold : MonoBehaviour
{

    
    public float speed;
   

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        
        GetComponent<Rigidbody>().velocity = transform.forward * speed * Time.deltaTime;
    }
}

