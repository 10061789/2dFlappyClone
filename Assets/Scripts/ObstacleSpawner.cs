using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{


    public GameObject obstacle;
    public float maxTimer;
    float timer;
    public float maxY;
    public float minY;
    float randomY;
    // Start is called before the first frame update
    void Start()
    {
        //InstantiateObstacle();
    }


    // Update is called once per frame
    void Update()
    {

        if (GameManager.gameOver==false && GameManager.gameStarted==true)
        {
            timer += Time.deltaTime;
            if (timer >= maxTimer)
            {
                randomY = Random.Range(minY, maxY);
                InstantiateObstacle();
                timer = 0;
            }
        }


        
    }

    public void InstantiateObstacle()
    {
        GameObject newObstacle = Instantiate(obstacle);
        newObstacle.transform.position = new Vector2(transform.position.x, randomY);
    }
}
