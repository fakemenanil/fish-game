using TMPro;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    public TMP_Text shopFishName;

    [HideInInspector] public int fish;
    void Update()
    {
        Debug.LogWarning(fish);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Butterfly")
        {
            shopFishName.text = "Butterfly Fish";
            fish = 0;
            
        }

        if(other.gameObject.tag == "Sword")
        {
            shopFishName.text = "Sword Fish";
            fish=1;
        }

        if(other.gameObject.tag == "Shark")
        {
            shopFishName.text = "Shark";
            fish=2;
        }
        
        if(other.gameObject.tag == "Pirana")
        {
            shopFishName.text = "Piranha";
            fish = 3;
        }

        if(other.gameObject.tag == "Lion")
        {
            shopFishName.text = "Lionfish";
            fish=4;
        }

        if(other.gameObject.tag == "Angler")
        {
            shopFishName.text = "Angler Fish";
            fish=5;
        }
    }
}
