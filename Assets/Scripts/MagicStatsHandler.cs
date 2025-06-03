using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MagicStatsHandler : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject MagicStatUI;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (player.PtsAmelioration > 0)
        {
            player.IncrementMagie();
            player.DecrementPtsAmelioration();
            MagicStatUI.GetComponent<TextMeshProUGUI>().text = player.Magie.ToString();
        }
    }
}
