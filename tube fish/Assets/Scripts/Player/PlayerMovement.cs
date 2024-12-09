using TMPro;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public Vector2 center = Vector2.zero; 
    public float radius = 5f;
    public float rotationMul = 20f;
    public DynamicJoystick joystick;
    public float health;
    public RectTransform healthBar;
    [HideInInspector] public int runGold;
    public TMP_Text goldText;
    PlayerMovement player;

    public GameObject butterfly, lionFish, swordFish, pirana, shark, angler;

    [HideInInspector]public Animator anim;
    public GameObject deathScreen;

    public float targetY; // Hedef Y pozisyonu
    public float deathRiseSpeed; // Hareket hızı (ne kadar yavaş hareket edeceği)

    public bool dead;

    public GameObject recordIndicator;
    int skin;

    void Start()
    {
        player = GetComponent<PlayerMovement>();
        health = 100;
        runGold = 0;
        skin = PlayerPrefs.GetInt("Skin");
        UpdateSkin();
    }


    void Update()
    {
        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;

        if(!dead)
        {
            Move(horizontalInput, verticalInput);
            Rotate(horizontalInput, verticalInput); 
        }
        healthBar.localScale = new Vector3(health/100,1,1);
        Debug.Log(health);

        if(health==0)
        {
            Die();
        }
    }

    void Move(float horizontalInput, float verticalInput)
    {
        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0f).normalized;

        
        Vector3 newPosition = transform.position + moveDirection * moveSpeed * Time.deltaTime;

        
        Vector2 position2D = new Vector2(newPosition.x, newPosition.y);
        float distance = Vector2.Distance(position2D, center);

        
        if (distance > radius)
        {
            Vector2 direction = (position2D - center).normalized;
            position2D = center + direction * radius;
            newPosition = new Vector3(position2D.x, position2D.y, transform.position.z);
        }

        
        transform.position = newPosition;
    }

    void Rotate(float horizontalInput, float verticalInput)
    {
        float xRotation = - verticalInput * rotationMul;
        float yRotation = horizontalInput * rotationMul;
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }

    void Die()
    {
        dead = true;
        //player.enabled = false;
        Debug.LogWarning("Öldün");
        PlayerPrefs.SetInt("TotalGold", PlayerPrefs.GetInt("TotalGold") + runGold);
        anim.SetBool("dead",true);
        deathScreen.SetActive(true);

        StartCoroutine(MoveToY(targetY));

        if(runGold>PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", runGold);
            recordIndicator.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Enemy")
        {
            health -= other.GetComponent<Obstacle>().damage;
        }

        if(other.gameObject.tag == "Gold")
        {
            runGold++;
            PlayerPrefs.SetInt("RunGold", runGold);
            goldText.text = runGold.ToString();
        }
    }

    public void UpdateSkin()
    {
        if(skin==0)
        {
            butterfly.SetActive(true);
            lionFish.SetActive(false);
            swordFish.SetActive(false);
            pirana.SetActive(false);
            shark.SetActive(false);
            angler.SetActive(false);
        }

        if(skin==1)
        {
            butterfly.SetActive(false);
            lionFish.SetActive(false);
            swordFish.SetActive(true);
            pirana.SetActive(false);
            shark.SetActive(false);
            angler.SetActive(false);
        }

        if(skin==2)
        {
            butterfly.SetActive(false);
            lionFish.SetActive(false);
            swordFish.SetActive(false);
            pirana.SetActive(false);
            shark.SetActive(true);
            angler.SetActive(false);
        }

        if(skin==3)
        {
            butterfly.SetActive(false);
            lionFish.SetActive(false);
            swordFish.SetActive(false);
            pirana.SetActive(true);
            shark.SetActive(false);
            angler.SetActive(false);
        }

        if(skin==4)
        {
            butterfly.SetActive(false);
            lionFish.SetActive(true);
            swordFish.SetActive(false);
            pirana.SetActive(false);
            shark.SetActive(false);
            angler.SetActive(false);
        }

        if(skin==5)
        {
            butterfly.SetActive(false);
            lionFish.SetActive(false);
            swordFish.SetActive(false);
            pirana.SetActive(false);
            shark.SetActive(false);
            angler.SetActive(true);
            Debug.LogWarning("Skin Angler");
        }

        anim = GetComponentInChildren<Animator>();
    }

    private IEnumerator MoveToY(float targetY)
    {
        float startY = transform.position.y; // Mevcut Y pozisyonu
        float elapsedTime = 0f; // Geçen süre

        while (elapsedTime < deathRiseSpeed)
        {
            // Geçen süreyi artır
            elapsedTime += Time.deltaTime;

            // Zaman bazlı interpolasyon
            float newY = Mathf.Lerp(startY, targetY, elapsedTime / deathRiseSpeed);

            // Yeni pozisyonu uygula
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);

            // Bir sonraki frame'e kadar bekle
            yield return null;
        }

        // Son olarak hedef pozisyona tam olarak yerleştir
        transform.position = new Vector3(transform.position.x, targetY, transform.position.z);
    }
}
