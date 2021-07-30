using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerificationSound : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.GetString("NoAds") == "yes")
            Destroy(gameObject);
    }


    void Update()
    {
        if (PlayerPrefs.GetString("NoAds") == "yes")
            Destroy(gameObject);
    }
}
