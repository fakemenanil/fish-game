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

    public GameObject shopMenu;
    public GameObject playButton;
    public SkinManager skinManager;
    public GameObject shopButton;
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
        goldText.text = PlayerPrefs.GetInt("TotalGold").ToString();
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

    public void OpenShop()
    {
        shopButton.SetActive(false);
        playButton.SetActive(false);
        shopMenu.SetActive(true);
    }

    public void CloseShop()
    {
        shopButton.SetActive(true);
        shopMenu.SetActive(false);
        playButton.SetActive(true);
    }

    public void Butterfly()
    {
        PlayerPrefs.SetInt("Skin", 0);
    }

    public void Lionfish()
    {
        if(PlayerPrefs.GetInt("TotalGold")>=50)
        {
            PlayerPrefs.SetInt("Skin", 1);
            PlayerPrefs.SetInt("TotalGold", PlayerPrefs.GetInt("TotalGold") - 50);
            skinManager.UpdateSkin();
        }
    }

    public void SwordFish()
    {
        if(PlayerPrefs.GetInt("TotalGold")>=60){PlayerPrefs.SetInt("Skin", 2); 
        PlayerPrefs.SetInt("TotalGold", PlayerPrefs.GetInt("TotalGold") - 60);skinManager.UpdateSkin();}
    }

    public void Pirana()
    {
        if(PlayerPrefs.GetInt("TotalGold")>=70){PlayerPrefs.SetInt("Skin", 3); PlayerPrefs.SetInt("TotalGold", PlayerPrefs.GetInt("TotalGold") - 70);skinManager.UpdateSkin();}
    }

    public void Shark()
    {
        if(PlayerPrefs.GetInt("TotalGold")>=80){PlayerPrefs.SetInt("Skin", 4); PlayerPrefs.SetInt("TotalGold", PlayerPrefs.GetInt("TotalGold") - 80);skinManager.UpdateSkin();}
    }

    public void AnglerFish()
    {
        if(PlayerPrefs.GetInt("TotalGold")>=100){PlayerPrefs.SetInt("Skin", 5); PlayerPrefs.SetInt("TotalGold", PlayerPrefs.GetInt("TotalGold") - 100);skinManager.UpdateSkin();}
    }
}
