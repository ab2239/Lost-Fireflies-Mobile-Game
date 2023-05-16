using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteractUI : MonoBehaviour
{

    [SerializeField] private GameObject InteractUI, crystalPlaceUI;
    [SerializeField] private Interact playerInteract;
    [SerializeField] private TextMeshProUGUI interactTextMesh, crystalTextMesh;

    private void Update()
    {
        if(playerInteract.GetInteractableObject() != null)
        {
            Show(playerInteract.GetInteractableObject());
        }
        else
        {
            Hide();
        }
    }

    private void Show(IInteractable interactable)
    {
        InteractUI.SetActive(true);
        interactTextMesh.text = interactable.GetInteractText();
    }
    private void Hide()
    {
        InteractUI.SetActive(false);
        crystalPlaceUI.SetActive(false);
    }
}
