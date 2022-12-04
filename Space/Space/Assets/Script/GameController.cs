using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public GameObject asteroid;
    public float WaitTime;
    public float NextTime;
    public GameObject player;
    public int score;
    public Text Score;
    public Text Gameover;
    public Text Restart;
    void Start()
    {
            Gameover.gameObject.SetActive(false);
        Restart.gameObject.SetActive(false);
            StartCoroutine(spawnWaves());
            score = 0;

    }

    private void Update()
    {
        Score.text = "Score: " + score;
        if (player.gameObject == null)
        {
            Gameover.gameObject.SetActive(true);
            Restart.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.S))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
    IEnumerator spawnWaves()
    {

        yield return new WaitForSeconds(2);
        yield return new WaitForSeconds(3);
        while (true)
        {

           
            if (player.gameObject== null)
            {
                
                yield break;
                
            }
                for (int i = 0; i < 5; i++)
            {
                System.Random r = new System.Random();
                int x = r.Next(-7, 7);
                GameObject timeobjects = GameObject.Instantiate(asteroid, new Vector3(x, 2f, 12f), new Quaternion(0, 0, 0, 0));
                timeobjects.SetActive(true);
                yield return new WaitForSeconds(WaitTime);
            }
            yield return new WaitForSeconds(NextTime);
        }
    }
}

   