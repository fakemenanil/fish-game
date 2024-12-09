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
    public SkinManager playerSkinManager;
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
        UpdateShopSkin();
        shopFish = shopTrigger.fish;
    }

    public void Play()
    {
        StartCoroutine(StartPlay());
        fadePanel.SetActive(true);
    }

    public void ResetPrefs()
    {
        PlayerPrefs.SetInt("AnglerUnlocked", 0);
        PlayerPrefs.SetInt("HighScore", 0);
        PlayerPrefs.SetInt("LionUnlocked", 0);
        PlayerPrefs.SetInt("PiranhaUnlocked", 0);
        PlayerPrefs.SetInt("RunGold", 0);
        PlayerPrefs.SetInt("SharkUnlocked", 0);
        PlayerPrefs.SetInt("Skin", 0);
        PlayerPrefs.SetInt("SwordUnlocked", 0);
        PlayerPrefs.SetInt("TotalGold", 0);
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
        StartCoroutine(OpenShop(2));
    }

    public void CloseShop()
    {
        shopButton.SetActive(true);
        playButton.SetActive(true);
        fishDragger.enabled = false;
        shopAnim.SetBool("On", false);
        playerSkinManager.UpdateSkin();
    }

    private IEnumerator OpenShop(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        shopButton.SetActive(false);
        playButton.SetActive(false);
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
            Debug.Log("Seçilen skin Swordfish");
        }

        else if(shopFish == 1 && PlayerPrefs.GetInt("SwordUnlocked") ==0)
        {
            swordUnlock.SetActive(true);
            sharkUnlock.SetActive(false);
            piranhaUnlock.SetActive(false);
            lionUnlock.SetActive(false);
            anglerUnlock.SetActive(false);
            Debug.Log("Swordfish kilitli");
        }


        if(shopFish == 2 && PlayerPrefs.GetInt("SharkUnlocked") ==1)
        {
            PlayerPrefs.SetInt("Skin",2);
            Debug.Log("Seçilen skin Shark");
        }

        else if(shopFish == 2 && PlayerPrefs.GetInt("SharkUnlocked") ==0)
        {
            sharkUnlock.SetActive(true);
            swordUnlock.SetActive(false);
            piranhaUnlock.SetActive(false);
            lionUnlock.SetActive(false);
            anglerUnlock.SetActive(false);
            Debug.Log("Shark kilitli");
        }

        if(shopFish == 3 && PlayerPrefs.GetInt("PiranhaUnlocked") ==1)
        {
            PlayerPrefs.SetInt("Skin",3);
            Debug.Log("Seçilen skin Piranha");
        }

        else if(shopFish == 3 && PlayerPrefs.GetInt("PiranhaUnlocked") ==0)
        {
            piranhaUnlock.SetActive(true);
            swordUnlock.SetActive(false);
            sharkUnlock.SetActive(false);
            lionUnlock.SetActive(false);
            anglerUnlock.SetActive(false);
            Debug.Log("Piranha kilitli");
        }

        if(shopFish == 4 && PlayerPrefs.GetInt("LionUnlocked") ==1)
        {
            PlayerPrefs.SetInt("Skin",4);
            Debug.Log("Seçilen skin Lionfish");
        }

        else if(shopFish == 4 && PlayerPrefs.GetInt("LionUnlocked") ==0)
        {
            lionUnlock.SetActive(true);
            swordUnlock.SetActive(false);
            sharkUnlock.SetActive(false);
            piranhaUnlock.SetActive(false);
            anglerUnlock.SetActive(false);
            Debug.Log("Lionfish kilitli");
        }

        if(shopFish == 5 && PlayerPrefs.GetInt("AnglerUnlocked") ==1)
        {
            PlayerPrefs.SetInt("Skin",5);
            Debug.Log("Seçilen skin Anglerfish");
        }
        else if(shopFish == 5 && PlayerPrefs.GetInt("AnglerUnlocked") ==0)
        {
            anglerUnlock.SetActive(true);
            swordUnlock.SetActive(false);
            sharkUnlock.SetActive(false);
            piranhaUnlock.SetActive(false);
            lionUnlock.SetActive(false);
            Debug.Log("Anglerfish kilitli");
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
