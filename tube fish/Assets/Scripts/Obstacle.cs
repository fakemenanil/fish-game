using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int model;
    public float damage;
    public float radius;
    public GameObject tentacle, bottle, soda, soy;
    Vector3 newPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        model = Random.Range(0,3);
    }

    // Update is called once per frame
    void Update()
    {
        if(model==0)
        {
            tentacle.SetActive(true);
            bottle.SetActive(false);
            soda.SetActive(false);
            soy.SetActive(false);
        }

        else if(model==1)
        {
            tentacle.SetActive(false);
            bottle.SetActive(true);
            soda.SetActive(false);
            soy.SetActive(false);
        }

        else if(model==2)
        {
            tentacle.SetActive(false);
            bottle.SetActive(false);
            soda.SetActive(true);
            soy.SetActive(false);
        }

        else if(model==3)
        {
            tentacle.SetActive(false);
            bottle.SetActive(false);
            soda.SetActive(false);
            soy.SetActive(true);
        }
    }

    public Vector3 GetRandomPositionInRadius(float radius)
    {
        // get quaternion of random rotation in all 3 axes
        Quaternion quat = Quaternion.Euler(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f));

        // get forward vector
        Vector3 forward = quat * Vector3.forward;

        // get random distance from center, and move that way to find position
        Vector3 ranPos = forward * Random.Range(0.0f, radius);

        return ranPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("RoadSectionTrigger"))
        {
            //Instantiate(roadSection, new Vector3(0,0,36), Quaternion.identity);
            model = Random.Range(0,3);
            newPos = GetRandomPositionInRadius(radius);
            newPos.z = 40;
            transform.position = newPos;
        }

        if(other.gameObject.CompareTag("Player"))
        {
            //Instantiate(roadSection, new Vector3(0,0,36), Quaternion.identity);
            model = Random.Range(0,3);
            newPos = GetRandomPositionInRadius(radius);
            newPos.z = 40;
            transform.position = newPos;
        }
    }
}
