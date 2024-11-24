using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    public GameObject roadSection;
    
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("RoadSectionTrigger"))
        {
            //Instantiate(roadSection, new Vector3(0,0,36), Quaternion.identity);
            transform.position = new Vector3(0,0,25);
        }
    }
}
