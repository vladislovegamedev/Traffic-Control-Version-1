using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CanvasMenu : MonoBehaviour
{
    public Sprite btn, btnPressed, btnPressedCheckMap, btnCheckMap, btnPressedShop, btnNoAdsPressed, btnNoAds, btnShop, btnPressedRestart, btnRestart , btn5000Coins, btnPressed1_99Coins, btn1_99Coins,  btnPressed5000Coins, musicOn, musicOff, btnPressedPlay, btnPlay, btnPressedExit, btnExit, btnPressed1000Coins, btn1000Coins, btn0_99money, btnPressed0_99money;
    private Camera mainCam;
    private Image image;

    public void Start()
    {
        mainCam = Camera.main;
        image = GetComponent<Image>();
        if (gameObject.name == "Music button")
        {
            if (PlayerPrefs.GetString("music") == "No")
            {
                transform.GetChild(0).GetComponent<Image>().sprite = musicOff;
            }
        }
    }

    public void MusicButton()
    {
        if (PlayerPrefs.GetString("music") == "No")
        {
            PlayerPrefs.SetString("music", "Yes");
            
            transform.GetChild(0).GetComponent<Image>().sprite = musicOn;
        }
        else 
        {
            PlayerPrefs.SetString("music", "No");
            
            transform.GetChild(0).GetComponent<Image>().sprite = musicOff;
        }

        PlayButtonSound();
    }

    

    public void ShopScene()
    {
        StartCoroutine(LoadScene( "Shop"));
        PlayButtonSound();
    }

    public void ExitShopScene()
    {
        StartCoroutine(LoadScene("Menu"));
        PlayButtonSound();
    }

    public void SetPressedButtonExit()
    {
        image.sprite = btnPressedExit;
        

    }

    public void SetDefaultButtonExit()
    {
        image.sprite = btnExit;
        
    }

    public void StartGame()
    {
        if (PlayerPrefs.GetString("First Game") == "No")
        StartCoroutine(LoadScene ( "Game"));
        else
        {
            PlayerPrefs.GetString("First Game", "No");
            StartCoroutine(LoadScene( "Study"));
        }
        PlayButtonSound();
    }

    public void RestartGame()
    {
        
        StartCoroutine(LoadScene( "Game"));
        PlayButtonSound();

    }

    

    public void SetPressedButton()
    {
        image.sprite = btnPressed;
        transform.GetChild(0).localPosition -= new Vector3( -16.7f,  3f,  0);
        
    }

    

    public void SetDefaultButton()
    {
        image.sprite = btn;
       transform.GetChild(0).localPosition += new Vector3( -16.7f,  3f,  0);
    }

    public void SetPressedButtonPlay()
    {
        image.sprite = btnPressedPlay;
       

    }

    public void SetDefaultButtonPlay()
    {
        image.sprite = btnPlay;
        
    }

    IEnumerator LoadScene(string name)
    {
        float fadeTime = mainCam.GetComponent<Fading>().Fade(1f);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(name);
    }

    private void PlayButtonSound()
    {
        if (PlayerPrefs.GetString("music") != "No")
            GetComponent<AudioSource>().Play();
    }

    public void SetPressedButton1000Coins()
    {
        image.sprite = btnPressed1000Coins;


    }

    public void SetDefaultButton1000Coins()
    {
        image.sprite = btn1000Coins;

    }

    public void SetPressedButton0_99money()
    {
        image.sprite = btnPressed0_99money;
        
    }

    public void SetDefaultButton0_99money()
    {
        image.sprite = btn0_99money;
        
    }
    
    
    public void SetPressedButton5000Coins()
    {
        image.sprite = btnPressed5000Coins;
        
    }

    public void SetDefaultButton5000Coins()
    {
        image.sprite = btn5000Coins;
        
    }

    public void SetPressedButton1_99Money()
    {
        image.sprite = btnPressed1_99Coins;

    }

    public void SetDefaultButton1_99Money()
    {
        image.sprite = btn1_99Coins;

    }

    public void SetPressedButtonRestart()
    {
        image.sprite = btnPressedRestart;

    }

    public void SetDefaultButtonRestart()
    {
        image.sprite = btnRestart;

    }
    
    
    public void SetPressedButtonShop()
    {
        image.sprite = btnPressedShop;

    }

    public void SetDefaultButtonShop()
    {
        image.sprite = btnShop;

    }

    public void SetPressedButtonNoAds()
    {
        image.sprite = btnNoAdsPressed;
       

    }



    public void SetDefaultButtonNoAds()
    {
        image.sprite = btnNoAds;
        
    }

    
}
