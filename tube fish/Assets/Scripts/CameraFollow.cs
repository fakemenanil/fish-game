using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float decreationNumber;
    public float camSpeed;
    Vector3 camPos;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void LateUpdate()
    {
        camPos = (player.position / decreationNumber) + offset;
        if(camPos.y > 2.35f) camPos.y = 2.3f;
        if(camPos.x> 1.4f) camPos.x = 1.4f;
        if(camPos.x< -1.4f) camPos.x = -1.4f;
        //transform.position = camPos;
        transform.position = Vector3.Lerp(transform.position, camPos,camSpeed);
    }
}
