using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] public GameObject fireflies;
    [SerializeField] public GameObject fireflyDispurse;
    [SerializeField] private Collider collectCollider;
    [SerializeField] private AudioSource audioSauce;
    private void OnTriggerEnter(Collider other)
    {
        PlayerInvent playerInvent = other.GetComponent<PlayerInvent>();
        if(playerInvent != null)
        {
            Debug.Log("Collecting Crystal");
            playerInvent.CrystalCollected();
            collectCollider.enabled = false;

            Debug.Log("crystal has been colected");
            StartCoroutine(WaitingCoroutine()); 
        }
    }
    IEnumerator WaitingCoroutine()
    {
        fireflyDispurse.SetActive(true);
        fireflies.SetActive(false);
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
    }
}
