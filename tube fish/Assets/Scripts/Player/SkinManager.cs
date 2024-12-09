using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public GameObject butterfly, lionFish, swordFish, pirana, shark, angler;
    int skin;
    void Start()
    {
        UpdateSkin();
    }

    // Update is called once per frame
    void Update()
    {
        skin = PlayerPrefs.GetInt("Skin");
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
        }
    }
}
