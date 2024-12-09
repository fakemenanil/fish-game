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

    public ShopTrigger shopTrigger;
    public Animator shopAnim;
    public ShopDrag fishDragger;

    public GameObject swordUnlock, sharkUnlock, piranhaUnlock, lionUnlock, anglerUnlock;
    int shopFish;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        goldText.text = PlayerPrefs.GetInt("TotalGold").ToString();
        shopAnim.SetBool("On", false);
    }

    // Update is called once per frame
    void Update()
    {
        goldText.text = PlayerPrefs.GetInt("TotalGold").ToString();
        shopFish = shopTrigger.fish;
        UpdateShopSkin();
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
        shopAnim.SetBool("On", true);
        fishDragger.enabled = true;
        shopButton.SetActive(false);
        playButton.SetActive(false);
    }

    public void CloseShop()
    {
        shopButton.SetActive(true);
        playButton.SetActive(true);
        fishDragger.enabled = false;
        shopAnim.SetBool("On", false);
    }

    public void UpdateShopSkin()
    {
        if(shopFish == 0)
        {
            PlayerPrefs.SetInt("Skin",0);
            swordUnlock.SetActive(false);
            sharkUnlock.SetActive(false);
            piranhaUnlock.SetActive(false);
            lionUnlock.SetActive(false);
            anglerUnlock.SetActive(false);
        }

        if(shopFish == 1 && PlayerPrefs.GetInt("SwordUnlocked") ==1)
        {
            PlayerPrefs.SetInt("Skin",1);
        }

        else if(shopFish == 1 && PlayerPrefs.GetInt("SwordUnlocked") !=1)
        {
            swordUnlock.SetActive(true);
            sharkUnlock.SetActive(false);
            piranhaUnlock.SetActive(false);
            lionUnlock.SetActive(false);
            anglerUnlock.SetActive(false);
        }


        if(shopFish == 2 && PlayerPrefs.GetInt("SharkUnlocked") ==1)
        {
            PlayerPrefs.SetInt("Skin",2);
        }

        else if(shopFish == 2 && PlayerPrefs.GetInt("SharkUnlocked") !=1)
        {
            sharkUnlock.SetActive(true);
            swordUnlock.SetActive(false);
            piranhaUnlock.SetActive(false);
            lionUnlock.SetActive(false);
            anglerUnlock.SetActive(false);
        }

        if(shopFish == 3 && PlayerPrefs.GetInt("PiranhaUnlocked") ==1)
        {
            PlayerPrefs.SetInt("Skin",3);
        }

        else if(shopFish == 3 && PlayerPrefs.GetInt("PiranhaUnlocked") !=1)
        {
            piranhaUnlock.SetActive(true);
            swordUnlock.SetActive(false);
            sharkUnlock.SetActive(false);
            lionUnlock.SetActive(false);
            anglerUnlock.SetActive(false);
        }

        if(shopFish == 4 && PlayerPrefs.GetInt("LionUnlocked") ==1)
        {
            PlayerPrefs.SetInt("Skin",4);
        }

        else if(shopFish == 4 && PlayerPrefs.GetInt("LionUnlocked") !=1)
        {
            lionUnlock.SetActive(true);
            swordUnlock.SetActive(false);
            sharkUnlock.SetActive(false);
            piranhaUnlock.SetActive(false);
            anglerUnlock.SetActive(false);
        }

        if(shopFish == 5 && PlayerPrefs.GetInt("AnglerUnlocked") ==1)
        {
            PlayerPrefs.SetInt("Skin",5);
        }
        else if(shopFish == 5 && PlayerPrefs.GetInt("AnglerUnlocked") !=1)
        {
            anglerUnlock.SetActive(true);
            swordUnlock.SetActive(false);
            sharkUnlock.SetActive(false);
            piranhaUnlock.SetActive(false);
            lionUnlock.SetActive(false);
        }
    }

    public void Butterfly()
    {
        PlayerPrefs.SetInt("Skin", 0);
    }

    public void UnlockSword()
    {
        if(PlayerPrefs.GetInt("TotalGold")>=50)
        {
            PlayerPrefs.SetInt("TotalGold",PlayerPrefs.GetInt("TotalGold")-50);
            PlayerPrefs.SetInt("SwordUnlocked", 1);
            swordUnlock.SetActive(false);
        }
        else
        {
            return;
        }
    }

    public void UnlockShark()
    {
        if(PlayerPrefs.GetInt("TotalGold")>=80)
        {
            PlayerPrefs.SetInt("TotalGold",PlayerPrefs.GetInt("TotalGold")-80);
            PlayerPrefs.SetInt("SharkUnlocked", 1);
            sharkUnlock.SetActive(false);
        }
        else
        {
            return;
        }
    }

    public void UnlockPiranha()
    {
        if(PlayerPrefs.GetInt("TotalGold")>=100)
        {
            PlayerPrefs.SetInt("TotalGold",PlayerPrefs.GetInt("TotalGold")-100);
            PlayerPrefs.SetInt("PiranhaUnlocked", 1);
            piranhaUnlock.SetActive(false);
        }
        else
        {
            return;
        }
    }

    public void UnlockLion()
    {
        if(PlayerPrefs.GetInt("TotalGold")>=120)
        {
            PlayerPrefs.SetInt("TotalGold",PlayerPrefs.GetInt("TotalGold")-120);
            PlayerPrefs.SetInt("LionUnlocked", 1);
            lionUnlock.SetActive(false);
        }
        else
        {
            return;
        }
    }

    public void UnlockAngler()
    {
        if(PlayerPrefs.GetInt("TotalGold")>=150)
        {
            PlayerPrefs.SetInt("TotalGold",PlayerPrefs.GetInt("TotalGold")-150);
            PlayerPrefs.SetInt("AnglerUnlocked", 1);
            anglerUnlock.SetActive(false);
        }
        else
        {
            return;
        }
    }
}
