using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ForceStatsHandler : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject ForceStatUI;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (player.PtsAmelioration > 0)
        {
            player.IncrementForce();
            player.DecrementPtsAmelioration();
            ForceStatUI.GetComponent<TextMeshProUGUI>().text = player.Force.ToString();
        }
    }
}
