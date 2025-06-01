using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Porte : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int compteurPorte = 0;
    [SerializeField] private GameObject porte;
    [SerializeField] private ColumnElementContainRandom[] columnElementContainRandom;
    [SerializeField] private Player player;
    [SerializeField] private GameObject playerText;

    private void Start()
    {
        porte.GetComponent<TextMeshProUGUI>().text = "Porte Fermé";

    }

    void Update()
    {
        if (compteurPorte >= 5)
        {
            porte.GetComponent<TextMeshProUGUI>().text = "Porte Ouverte";
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (compteurPorte >= 5)
        {
            Reset();
            foreach (var columnElement in columnElementContainRandom)
            {
                columnElement.RandomElementInGrid();
            }
            player.IncrementLevel();
            playerText.transform.position = new Vector2(1495, 29);
            player.IncrementPtsAmelioration();
        }
    }

    public void Reset()
    {
        porte.GetComponent<TextMeshProUGUI>().text = "Porte Fermé";
        compteurPorte = 0;
    }

    public void IncrementCompteur()
    {
        compteurPorte++;
    }
}
