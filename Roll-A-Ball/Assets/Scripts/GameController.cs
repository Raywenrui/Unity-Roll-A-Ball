using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public int count=0;
    private int numPickups = 4; //Put here the number of pickups you have. public Text scoreText;
    public Text scoreText;
    public Text winText;
    public Text positionText;
    public Text velocityText;
    public Text closeText;
    public player player;
    public GameObject[] PickUp;
    private float distance;
    private LineRenderer lineRenderer;
    private GameObject obj;
    public float angle = 0f;

    public float unm = 30f;

    private void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        
    }

    private void Update()
    {
        switch (player.State) 
        {
            case GameStates.Normal:
                lineRenderer.enabled = false;
                scoreText.gameObject.SetActive(false);
                winText.gameObject.SetActive(false);
                positionText.gameObject.SetActive(false);
                velocityText.gameObject.SetActive(false);
                closeText.gameObject.SetActive(false);
                break;
            case GameStates.Distance:
                scoreText.gameObject.SetActive(true);
                winText.gameObject.SetActive(true);
                positionText.gameObject.SetActive(true);
                velocityText.gameObject.SetActive(true);
                closeText.gameObject.SetActive(true);
                lineRenderer.enabled = true;

                if (count < numPickups)
                    cloestPickUp();
                
                SetCountText();
                break;
            case GameStates.Vision:
                SetCountText();
                break;
        }
        
    }

    public void SetCountText()
    {
        positionText.text = "position: " + player.transform.position.x.ToString("0.00") + "," + player.transform.position.z.ToString("0.00");
        velocityText.text = "velocity: " + player.velocity.ToString();

        scoreText.text = "Score: " + count.ToString(); if (count == numPickups)
        {
            lineRenderer.enabled = false;
            winText.text = "You win!";
        }
    }

    void cloestPickUp()
    {   int smallone =0;
        distance = 1000;
  
            
            for (int i = 0; i < numPickups; i++) 
        {
            if (PickUp[i] == null) 
            {
                Destroy(PickUp[i]);
                continue;
            }
                
            PickUp[i].GetComponent<Renderer>().material.color = Color.white;
            float Distance = Vector3.Distance(player.transform.position, PickUp[i].transform.position);
            if (Distance <= distance) {
              distance = Distance;
                smallone = i;
            }
            
        }


        lineRenderer.SetPosition(0, player.transform.position);
        lineRenderer.SetPosition(1, PickUp[smallone].transform.position);
        lineRenderer.SetWidth(0.1f, 0.1f);
        PickUp[smallone].GetComponent<Renderer>().material.color = Color.blue;
        closeText.text = "Closest Distance: " + distance.ToString("0.00");
    }


}

