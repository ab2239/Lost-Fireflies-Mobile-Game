using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    [SerializeField] GameObject fadeInScreen;
  
    public void FadeInTurnOff()
    {
        fadeInScreen.SetActive(false);
    }
}
