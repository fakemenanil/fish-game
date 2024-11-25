using UnityEngine;

public class Gold : MonoBehaviour
{
    public float radius;
    Vector3 newPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
            newPos = GetRandomPositionInRadius(radius);
            newPos.z = 40;
            transform.position = newPos;
        }

        if(other.gameObject.CompareTag("Enemy"))
        {
            //Instantiate(roadSection, new Vector3(0,0,36), Quaternion.identity);
            
            transform.position = GetRandomPositionInRadius(radius);
        }

        if(other.gameObject.CompareTag("Player"))
        {
            newPos = GetRandomPositionInRadius(radius);
            newPos.z = 40;
            transform.position = newPos;
        }
    }
}
