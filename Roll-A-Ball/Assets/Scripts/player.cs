using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStates { Normal,Distance,Vision }

public class player : MonoBehaviour
{
    public float speed;
    private Vector3 curpos;
    public Vector3 Velocity;
    public float velocity;
    private GameController GameController;
    public GameStates State;
    private int space = 0;
    public Rigidbody rb;
    private void Start()
    {
        GameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        State = GameStates.Normal;
        rb = gameObject.AddComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            space = space + 1;
            ChangeState();
        }
        
    }

    void FixedUpdate()
    {
        float horAxis = Input.GetAxis("Horizontal");
        float verAxis = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horAxis, 0.0f, verAxis);
        Velocity = movement;
        GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
        velocity = (Vector3.Magnitude(transform.position - curpos) / Time.deltaTime);
        curpos = transform.position;
      
           
    }
   void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            Destroy(other.gameObject);
           GameController.count++;
        }
        
    }

    void ChangeState()
    {
        
       
            if (space > 2)
            {
                State = GameStates.Normal;
                space = 0;
            }
            if (space == 1) 
                State = GameStates.Distance;
           
        
    }

}
