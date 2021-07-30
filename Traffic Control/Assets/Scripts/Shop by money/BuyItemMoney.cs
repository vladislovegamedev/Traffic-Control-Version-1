using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class BuyItemMoney : MonoBehaviour
{
    public static bool NoAdSound;

    public enum Types
    {
        REMOVE_ADS, OPEN_CITY, OPEN_MEGAPOLIS
    }

    public Types type;

    public void BuyItem()

    {
        NoAdSound = true;


        switch (type)
        {
            case Types.REMOVE_ADS:
                IAPPManager.instance.BuyNoAds();
                break;
            case Types.OPEN_CITY:
                IAPPManager.instance.BuyCityMap();
                break;
            case Types.OPEN_MEGAPOLIS:
                IAPPManager.instance.BuyMegapolisMap();
                break;
        }
    }

    

}
