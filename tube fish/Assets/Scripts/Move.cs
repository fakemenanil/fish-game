using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Move : MonoBehaviour
{
    //public GameObject obstacle;
    //public GameObject gold;
    //public GameObject slow;
    public float speed;

    //public GameManager gameManager;

    public bool spawnObstacles;
    //public Transform[] obstacleSpawnpoints;
    //public Transform[] goldSpawnpoints;

    //public Transform[] slowSpawnpoints;
    //Transform currentPoint;
    //int selectedPoint;
    //Transform currentGoldPoint;
    //int goldSelectedPoint;
    //Transform currentSlowPoint;
    //int slowSelectedPoint;

    

    void Start()
    {
        //gameManager = FindAnyObjectByType<GameManager>();
        /*if(spawnObstacles)
        {
            if (gameManager.score<50)
            {
                SpawnObstacle();
            }

            else if(gameManager.score>=50 && gameManager.score<100)
            {
                SpawnObstacle();
                SpawnObstacle();
            }
        }*/
        //Vector3 obsPos = new Vector3(15.64892f, Random.Range(-4.643939f, 3.356061f),Random.Range(-2.556479f, 5.443521f));
        
        

        //SpawnGold();

        //SpawnSlow();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0,0,-speed) * Time.deltaTime;
    }

    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("DeleteRoad"))
        {
            Destroy(gameObject);
        }
    }

    /*public Vector3 GetRandomPositionInRadius(float radius)
    {
        // get quaternion of random rotation in all 3 axes
        Quaternion quat = Quaternion.Euler(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f));

        // get forward vector
        Vector3 forward = quat * Vector3.forward;

        // get random distance from center, and move that way to find position
        Vector3 ranPos = forward * Random.Range(0.0f, radius);

        return ranPos;
    }

    void SpawnObstacle()
    {
        /*nt obsCount = Random.Range(1,4);

        for (int i = 0; i < obsCount;)
        {
            
            i++;
        }

        Vector3 obsPos = GetRandomPositionInRadius(4);
        obsPos.x = 15.64892f;
        Instantiate(obstacle, obsPos, Quaternion.identity,parent: gameObject.transform);
        /*selectedPoint = Random.Range(0,obstacleSpawnpoints.Length);
        currentPoint = obstacleSpawnpoints[selectedPoint];
        Instantiate(obstacle, currentPoint.position, Quaternion.identity, parent: gameObject.transform);
        
    }*/

    /*void SpawnGold()
    {
        goldSelectedPoint = Random.Range(0,goldSpawnpoints.Length);
        currentGoldPoint = goldSpawnpoints[goldSelectedPoint];
        Instantiate(gold, currentGoldPoint.position, Quaternion.identity, parent: gameObject.transform);
    }

    void SpawnSlow()
    {
        slowSelectedPoint = Random.Range(0,slowSpawnpoints.Length);
        currentSlowPoint = slowSpawnpoints[slowSelectedPoint];
        Instantiate(slow, currentSlowPoint.position, Quaternion.identity, parent: gameObject.transform);
    }*/
}
