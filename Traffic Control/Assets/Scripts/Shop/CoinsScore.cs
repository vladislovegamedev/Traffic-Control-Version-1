
using UnityEngine;
using UnityEngine.UI;

public class CoinsScore : MonoBehaviour
{
    // Start is called before the first frame update
   public void Start()
    {
        GetComponent< Text > ().text = PlayerPrefs.GetInt("Coins").ToString();
    }

    
}
