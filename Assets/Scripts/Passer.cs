using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Passer : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Porte porteScript;

    public void OnPointerClick(PointerEventData eventData)
    {
        porteScript.HidePopup();
    }
}
