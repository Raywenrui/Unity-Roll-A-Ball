using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class asteroids : MonoBehaviour
{
    private float x;
    private float y;
    private float z;
    public float speed;
    public GameObject player;
    private Vector3 position;
    private Rigidbody rb;
    public AudioClip exp;
    public GameController controller;
    [SerializeField] private GameObject explosion;
 
    void Start()
    {
        
        if (player != null)
        {
            
            System.Random r = new System.Random();
            x = r.Next(15, 60);
            y = r.Next(15, 60);
            z = r.Next(15, 60);
            position = player.transform.position;
            rb = GetComponent<Rigidbody>();
            Move();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.gameObject != null)
        {
            transform.Rotate(new Vector3(x, y, z) * Time.deltaTime);
            rb.position = new Vector3(rb.position.x, 2f, rb.position.z);
        }
        if(player == null) { Destroy(transform.gameObject); }
    }

    private void FixedUpdate()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "bolt")
        {
            controller.score++;
            Destroy(other.gameObject);
            Destroy(transform.gameObject);
            GameObject timeobjects = GameObject.Instantiate(explosion, transform.position, new Quaternion(0,0,0,0));
            AudioSource.PlayClipAtPoint(exp, transform.position);
            timeobjects.SetActive(true);
            Destroy(timeobjects,2f);
        }

        if (other.gameObject.tag == "player")
        {
            Destroy(other.gameObject);
            Destroy(transform.gameObject);
            GameObject timeobjects = GameObject.Instantiate(explosion, transform.position, new Quaternion(0, 0, 0, 0));
            AudioSource.PlayClipAtPoint(exp, transform.position);
            timeobjects.SetActive(true);
            Destroy(timeobjects, 2f);
        }

        if (other.gameObject.tag == "Asteroid") 
        {

            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity-other.gameObject.GetComponent<Rigidbody>().velocity;
        }

    }
    private void Move()
    {
        GetComponent<Rigidbody>().velocity=-Vector3.MoveTowards(transform.position, position,0)*speed*Time.deltaTime;
        
    }

}
