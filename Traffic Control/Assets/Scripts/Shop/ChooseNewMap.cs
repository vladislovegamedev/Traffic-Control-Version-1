using UnityEngine;

public class ChooseNewMap : MonoBehaviour
{public AudioClip buttonClick;

    public void ChoseNewMap(int numberMap)
    {
        
        if (PlayerPrefs.GetString("music") != "No"){
            GetComponent<AudioSource>().Play();
    GetComponent<AudioSource>().clip = buttonClick;
        }

        PlayerPrefs.SetInt("NowMap", numberMap);
        GetComponent<MapController>().whichMapSelected();

       
    }

    
    
     
    
}
