using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MM_LeanTween_Anims : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float tweenTime;
    public Vector2 scale;

    public void OnPointerEnter(PointerEventData eventData)
    {
        LeanTween.scale(gameObject, scale, tweenTime);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        LeanTween.scale(gameObject, new Vector2(1f, 1f), tweenTime);
    }
    public void OnClick()
    {
        LeanTween.scale(gameObject, scale, tweenTime);
    }
}
