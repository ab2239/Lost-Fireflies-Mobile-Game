using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerInvent : MonoBehaviour
{
    [SerializeField] public int _numOfCrystals { get; private set; }
    [SerializeField] public GameObject crystal = null;
    public Image[] crystals;
    public CrystalPlacing crystalPlaced;
    public GameObject inventImage;
    public float tweenTime;

    public void CrystalCollected()
    {
        _numOfCrystals++;
        Debug.Log("crystal added to playerInvent " + _numOfCrystals);
       
        for (int i = 0; i < crystals.Length; i++)
        {
            Debug.Log("Entered collection forloop");
            crystals[_numOfCrystals - 1].gameObject.SetActive(true);
            StartCoroutine(CrystalAdding());
        }
        crystalPlaced.amountOfCrystals++;
        Debug.Log(crystalPlaced.amountOfCrystals + " = crystals that can be placed");
    }
    public IEnumerator CrystalAdding()
    {
        crystal.SetActive(true);
        yield return new WaitForSeconds(0.95f);
        crystal.SetActive(false);
        LeanTween.scale(inventImage, new Vector2(1.2f, 1.2f), tweenTime);
        LeanTween.scale(inventImage, new Vector2(1f, 1f), tweenTime);
    }
}
