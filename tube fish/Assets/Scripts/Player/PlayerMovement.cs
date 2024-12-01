using TMPro;
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
    int runGold;
    public TMP_Text goldText;
    PlayerMovement player;

    void Start()
    {
        player = GetComponent<PlayerMovement>();
        health = 100;
        runGold = 0;
    }

    void Update()
    {
        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;

        Move(horizontalInput, verticalInput);
        Rotate(horizontalInput, verticalInput); 
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
        player.enabled = false;
        Debug.LogWarning("Öldün");
        PlayerPrefs.SetInt("TotalGold", PlayerPrefs.GetInt("TotalGold") + runGold);
        SceneManager.LoadSceneAsync(0);
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
}
