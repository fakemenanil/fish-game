using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Move playerMove;
    public float startDelay;
    public Image fadeIn;
    public GameObject fadePanel;
    public float fadeRate;
    public TMP_Text goldText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        goldText.text = PlayerPrefs.GetInt("TotalGold").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        StartCoroutine(StartPlay());
        fadePanel.SetActive(true);
    }

    IEnumerator StartPlay()
    {
        playerMove.enabled = true;
        //fadeIn.color = new Vector4(0,0,0,Mathf.Lerp(fadeIn.color.a, 255f, fadeRate));
        yield return new WaitForSeconds(startDelay);
        SceneManager.LoadScene(1);
    }
}
