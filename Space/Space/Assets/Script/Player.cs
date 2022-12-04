using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float CD;
    private float remainCD;
    public GameObject shot;
    private Rigidbody rb;
    [SerializeField] private GameObject explosion;
    public AudioClip shoot;
    public AudioClip exp;
    private void Awake()
    {
        remainCD = 0;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        remainCD -= Time.deltaTime;
         fire();
    }
    void FixedUpdate() {
      
float horAxis = Input.GetAxis ("Horizontal");
float verAxis = Input.GetAxis ("Vertical");
Vector3 movement = new Vector3(horAxis, 0.0f, verAxis); 
rb.velocity=movement * speed * Time.deltaTime;
 transform.rotation= Quaternion.Euler (0,0,-horAxis*speed/10);
        rb.position = new Vector3(Mathf.Clamp(rb.position.x,-7f,7f),2f,Mathf.Clamp(rb.position.z,-10f,10f));
 }

    private void fire()
    {
       
        
            if (Input.GetKeyDown(KeyCode.Space))
            {
            if (remainCD <= 0)
            {
                AudioSource.PlayClipAtPoint(shoot, transform.position);
                GameObject timeobjects = GameObject.Instantiate(shot, transform.Find("shot").position, transform.rotation);
                timeobjects.SetActive(true);
                remainCD = CD;
            }
            }
        
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Asteroid")
        {

            Destroy(transform.gameObject);
            GameObject timeobjects = GameObject.Instantiate(explosion, transform.position, new Quaternion(0, 0, 0, 0));
            AudioSource.PlayClipAtPoint(exp, transform.position);
            timeobjects.SetActive(true);
            Destroy(timeobjects, 2f);
        }
    }
    }

