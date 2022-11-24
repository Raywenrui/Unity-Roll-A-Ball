using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public float speed;
    private int count;
    private int numPickups = 3; //Put here the number of pickups you have. public Text scoreText;
    public Text scoreText;
    public Text winText;
    public Text positionText;
    public Text velocityText;
    private Vector3 curpos;
    private float velocity;
    void FixedUpdate()
    {
        float horAxis = Input.GetAxis("Horizontal");
        float verAxis = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horAxis, 0.0f, verAxis);
        GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
        positionText.text = "position: " + transform.position.x.ToString("0.00")+","+transform.position.z.ToString("0.00");

        velocity = (Vector3.Magnitude(transform.position - curpos) / Time.deltaTime);
        curpos = transform.position;
        velocityText.text = "velocity: " + velocity.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    private void SetCountText()
    {
        
        scoreText.text = "Score: " + count.ToString(); if (count >= numPickups)
        {
            winText.text = "You win!";
        }
    }
}
