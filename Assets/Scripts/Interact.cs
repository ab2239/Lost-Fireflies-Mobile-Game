using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interact : MonoBehaviour
{
    public Button interact;
    public Button invent;
    public Button closeWindow;
    public Button closeGame;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = interact.GetComponent<Button>();
        btn.onClick.AddListener(Interacting);
        Button butn = invent.GetComponent<Button>();
        butn.onClick.AddListener(Inventory);
        Button close = closeWindow.GetComponent<Button>();
        close.onClick.AddListener(Close);
        Button quitGame = closeGame.GetComponent<Button>();
        quitGame.onClick.AddListener(QuitGame);
    }
    void Interacting()
    {
        IInteractable interactable = GetInteractableObject();
        if(interactable != null)
        {
            interactable.Interact(transform);           
        }
    }
    void Inventory()
    {
        Time.timeScale = 0f;
        Debug.Log("InventoryOpened.");
    }
    void Close()
    {
        Time.timeScale = 1f;
        Debug.Log("Window Closed");
    }

    public IInteractable GetInteractableObject()
    {
        List<IInteractable> interactableList = new List<IInteractable>();
        float interactRange = 4f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach(Collider collider in colliderArray)
        {
            if(collider.TryGetComponent(out IInteractable interactable))
            {
                interactableList.Add(interactable);
            }
        }
        IInteractable closestInteract = null;
        foreach(IInteractable interactable in interactableList)
        {
            if(closestInteract == null)
            {
                closestInteract = interactable;
            }
            else
            {
                if(Vector3.Distance(transform.position, interactable.GetTransform().position) < Vector3.Distance(transform.position, closestInteract.GetTransform().position))
                {
                    closestInteract = interactable;
                }
            }
        }
        return closestInteract;
    }

    void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Game Closed");
    }
}
