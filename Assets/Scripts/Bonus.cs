using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bonus : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Player player;
    [SerializeField] private Porte porte;
    [SerializeField] private string bonus;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (bonus == "force" && player.Or >= 40)
        {
            player.IncrementForce();
            porte.HidePopup();
            player.DecrementOr(40);
        } 
        else if (bonus == "magie" && player.Or >= 40)
        {
            player.IncrementMagie();
            porte.HidePopup();
            player.DecrementOr(40);
        }
        else if (bonus == "vie" && player.Or >= 120)
        {
            player.IncrementLife();
            porte.HidePopup();
            player.DecrementOr(120);
        }
    }
}
