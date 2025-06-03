using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Porte : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int compteurPorte = 0;
    [SerializeField] private GameObject porte;
    [SerializeField] private ColumnElementContainRandom[] columnElementContainRandom;
    [SerializeField] private Player player;
    [SerializeField] private GameObject playerText;
    [SerializeField] private Sprite imagePorteOuverte;
    [SerializeField] private Sprite imagePorteFerme;
    [SerializeField] private GameObject popUp;
    [SerializeField] private GameObject game;

    private void Start()
    {
        porte.GetComponent<Image>().sprite = imagePorteFerme;

    }

    void Update()
    {
        if (compteurPorte >= 5)
        {
            porte.GetComponent<Image>().sprite = imagePorteOuverte;
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

            if (player.Level % 10 == 0)
            {
                PrintPopup();
            }
        }
    }

    public void Reset()
    {
        porte.GetComponent<Image>().sprite = imagePorteFerme;
        compteurPorte = 0;
    }

    public void IncrementCompteur()
    {
        compteurPorte++;
    }

    public void PrintPopup()
    {
        popUp.SetActive(true);
        game.GetComponent<CanvasGroup>().interactable = false;
        game.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void HidePopup()
    {
        popUp.SetActive(false);
        game.GetComponent<CanvasGroup>().interactable = true;
        game.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
