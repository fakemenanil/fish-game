
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    public Move tube,gold,obstacle;
    public float gameStopSpeed;
    public ScoreManager scoreManager;
    public Move tubeMove,obstacle1Move,goldMove, slowMove;
    bool timeSlowed;
    public int speedpPhase;
    public float speedUpAmount;
    public MusicManager musicManager;
    void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>();
        fadeOut.SetActive(true);
        StartCoroutine(ChangeDirection());
        horizontalStrenght = 0;
        horizontalStrenght = 0;
        speedpPhase=0;
    }

    void Update()
    {
        if(!player.dead)
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

            if(player.slow && !timeSlowed)
            {
                tubeMove.speed = tubeMove.speed/2;
                obstacle1Move.speed = obstacle1Move.speed/2;
                goldMove.speed = goldMove.speed/2;
                slowMove.speed = slowMove.speed/2;
                scoreManager.scoreIncrease = scoreManager.scoreIncrease/2;
                timeSlowed=true;
            }

            if(!player.slow && timeSlowed)
            {
                tubeMove.speed = tubeMove.speed*2;
                obstacle1Move.speed = obstacle1Move.speed*2;
                goldMove.speed = goldMove.speed*2;
                slowMove.speed = slowMove.speed*2;
                scoreManager.scoreIncrease = scoreManager.scoreIncrease*2;
                timeSlowed=false;
            }

            if(scoreManager.runScore> 20 && speedpPhase ==0 && tubeMove.speed<40f)
            {
                speedpPhase++;
                musicManager.StartSolo();
            }

            if(speedpPhase!=0)
            {
                float oldSpeed = tubeMove.speed;
                float newSpeed = oldSpeed +Time.deltaTime/4;
                tubeMove.speed = newSpeed;
                obstacle1Move.speed = newSpeed;
                goldMove.speed = newSpeed;
                slowMove.speed = newSpeed;
            }
        }

        

        if(player.dead == true)
        {
            tube.speed = Mathf.Lerp(tube.speed,0,gameStopSpeed);
            gold.speed = Mathf.Lerp(tube.speed,0,gameStopSpeed);
            obstacle.speed = Mathf.Lerp(tube.speed,0,gameStopSpeed);
        }
    }

    private IEnumerator IncreaseMeter()
    {
        scoreManager.scoreIncrease = scoreManager.scoreIncrease + 1;
        yield return new WaitForSeconds(5);
        StartCoroutine(IncreaseMeter());
    }

    IEnumerator ChangeDirection()
    {
        gamePhase = Random.Range(1,5);
        yield return new WaitForSeconds(phaseLenght);
        yield return ChangeDirection();
    }

    public void BacktoMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync(1);
    }
    
}
