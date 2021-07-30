using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour
{
    private BuyCoinMap _mapCoins;
    public Image[] maps;
    public Sprite selected, notSelected;

   private void Start()
    {whichMapSelected();
        
        
        _mapCoins = GetComponent<BuyCoinMap>();
        if (PlayerPrefs.GetString("Megapolis") == "Open")
        {   
            _mapCoins.coins5000.SetActive(false);
            _mapCoins.money1_99.SetActive(false);
            _mapCoins.megapolis_button.SetActive(true);
            
        }

        if (PlayerPrefs.GetString("City") == "Open")
        {
            _mapCoins.coins1000.SetActive(false);
            _mapCoins.money0_99.SetActive(false);
            _mapCoins.city_button.SetActive(true);

        }
        
    }

    public void whichMapSelected()
    {
        switch (PlayerPrefs.GetInt("NowMap"))
        {
            case 2:
                maps[0].sprite = notSelected;
                maps[1].sprite = selected;  
                maps[2].sprite = notSelected;
                    break;
            case 3:
                maps[0].sprite = notSelected;
                maps[1].sprite = notSelected;
                maps[2].sprite = selected;
                break;
            default:
                maps[0].sprite = selected;
                maps[1].sprite = notSelected;
                maps[2].sprite = notSelected;
                break;
        }
    }
}
