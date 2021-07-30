using UnityEngine;
using UnityEngine.UI;

public class BuyCoinMap : MonoBehaviour
{
    public AudioClip succes, fail;
    public Animation coinsText;
    public GameObject coins1000, coins5000, money0_99, money1_99, city_button, town_button, megapolis_button;
    public Text coinsCount;

    public void BuyNewMap(int needCoins)

    {

       


        int coins = PlayerPrefs.GetInt("Coins");
        if (coins < needCoins) { 
            if (PlayerPrefs.GetString("music") != "No")
            {
                GetComponent<AudioSource>().clip = fail;
                GetComponent<AudioSource>().Play();
            }
        coinsText.Play(); }
        else 
        {
            switch (needCoins)
            {           case 1000:
                    PlayerPrefs.SetString("City", "Open");
                    PlayerPrefs.SetInt("NowMap", 2);
                    GetComponent<MapController>().whichMapSelected();
                    coins1000.SetActive(false);
                    money0_99.SetActive(false);
                    city_button.SetActive(true);
                      break;

                         case 5000:
                    PlayerPrefs.SetString("Megapolis", "Open");
                    PlayerPrefs.SetInt("NowMap", 3);
                    coins5000.SetActive(false);
                    money1_99.SetActive(false);
                    megapolis_button.SetActive(true);
                    
                    GetComponent<MapController>().whichMapSelected();
                         break;
                
            }

            int nowCoins = coins - needCoins;
            coinsCount.text = nowCoins.ToString();
            PlayerPrefs.SetInt("Coins", nowCoins);

            if (PlayerPrefs.GetString("music") != "No")
            {
                GetComponent<AudioSource>().clip = succes;
                GetComponent<AudioSource>().Play();
            }
        } 
        
        
    }

    
    
}
