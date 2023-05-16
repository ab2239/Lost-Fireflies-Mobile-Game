using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.SceneManagement;

public class CrystalPlacing : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject crystalLight;
    [SerializeField] private GameObject firefliesSpawn;
    [SerializeField] private GameObject lastCrystal;
    public string interactText;
    //public GameObject[] crystalObject;
    //private int particleCount = 2;
    public int amountOfCrystals;
    //public int heldCrystal = 0;
    //public GameObject crystal;
    [SerializeField] private AudioSource audioSource;
    
    public List<GameObject> crystalList = new List<GameObject>(); 

    public string GetInteractText()
    {
        return interactText;
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void Interact(Transform interactorTransform)
    {

        if(amountOfCrystals <=0)
        {
            Debug.Log("No Crystals Collected");
        }
        else 
        {
            Debug.Log(amountOfCrystals + " crystals can be placed");
            audioSource.Play();
            for (int i = 0; i < amountOfCrystals; i++) //placing of the crystals
            {
                crystalList[i].gameObject.SetActive(true);
                crystalLight.SetActive(true);
            }
            firefliesSpawn.SetActive(true); //turns on the fireflies at the stones adn increases the amount of fireflies
            firefliesSpawn.GetComponent<VisualEffect>().SetFloat("Count", amountOfCrystals * 2);

            if(lastCrystal.activeSelf == true)
            {
                //Debug.Log("Win Scene");
                SceneManager.LoadScene("WinScene");
            }
        }
    }
}
