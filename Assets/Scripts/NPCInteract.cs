using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPCInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private string interactText;
    [SerializeField] private GameObject npcQuest;
    [SerializeField] private GameObject npcHelp;
    public bool hasQuest = false;

    public string GetInteractText()
    {
        return interactText;
    }

    public void Interact(Transform interactorTransform)
    {
        //PlayerInvent playerInvent = new PlayerInvent();
        if(hasQuest == false)
        {
            Time.timeScale = 0f;
            npcQuest.SetActive(true);
            hasQuest = true;
        }
        else if(hasQuest == true)
        {
            Time.timeScale = 0f;
            npcHelp.SetActive(true);
        } 
    }
    public Transform GetTransform()
    {
        return transform;
    }
}
