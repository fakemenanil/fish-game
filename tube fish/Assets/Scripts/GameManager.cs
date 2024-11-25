using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float phaseLenght;
    public int gamePhase=0;
    public Material[] bendingMat;
    public float bendSpeed;
    float horizontalStrenght;
    float verticalStrenght;
    public float maxStrenght;
    public GameObject fadeOut;
    PlayerMovement player;
    void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>();
        fadeOut.SetActive(true);
        StartCoroutine(ChangeDirection());
        horizontalStrenght = 0;
        horizontalStrenght = 0;
    }

    void Update()
    {
        foreach(Material mat in bendingMat)
        {
            mat.SetFloat("_SidewaysStrength", horizontalStrenght);
            mat.SetFloat("_BackwardsStrength", verticalStrenght);
        }

        if(gamePhase==1)
        {
            horizontalStrenght = Mathf.Lerp(horizontalStrenght, maxStrenght, bendSpeed);
            verticalStrenght = Mathf.Lerp(verticalStrenght, 0, bendSpeed);
            Debug.Log("Phase 1");
        }

        if(gamePhase==2)
        {
            horizontalStrenght = Mathf.Lerp(horizontalStrenght, -maxStrenght, bendSpeed);
            verticalStrenght = Mathf.Lerp(verticalStrenght, 0, bendSpeed);
            Debug.Log("Phase 2");
        }

        if(gamePhase==3)
        {
            horizontalStrenght = Mathf.Lerp(horizontalStrenght, 0, bendSpeed);
            verticalStrenght = Mathf.Lerp(verticalStrenght, maxStrenght, bendSpeed);
            Debug.Log("Phase 3");
        }

        if(gamePhase==4)
        {
            horizontalStrenght = Mathf.Lerp(horizontalStrenght, 0, bendSpeed);
            verticalStrenght = Mathf.Lerp(verticalStrenght, -maxStrenght, bendSpeed);
            Debug.Log("Phase 4");
        }

        if(gamePhase==5)
        {
            horizontalStrenght = Mathf.Lerp(horizontalStrenght, 0, bendSpeed);
            verticalStrenght = Mathf.Lerp(verticalStrenght, 0, bendSpeed);
            Debug.Log("Phase 5");
        }
    }

    IEnumerator ChangeDirection()
    {
        gamePhase = Random.Range(1,5);
        yield return new WaitForSeconds(phaseLenght);
        yield return ChangeDirection();
    }

    
}
