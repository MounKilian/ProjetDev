using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Text.RegularExpressions;

public class ColumnClickHandler : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private bool isSelected = false;
    [SerializeField] private List<GameObject> elements;

    [SerializeField] private Image backgroundImage;
    [SerializeField] private Porte porteScript;
    [SerializeField] private GameObject playerText;
    [SerializeField] private Player player; 

    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color hoverColor = new Color(0.9f, 0.9f, 1f);

    public void OnPointerClick(PointerEventData eventData)
    {
        string elementPick;
        int index;
        (elementPick, index) = ElementPickRandom();
        if (elementPick != null)
        {
            ActionEvent(elementPick);
            RemoveElement(elementPick, index);
            porteScript.IncrementCompteur();
            playerText.transform.position = elements[index].transform.position;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isSelected && backgroundImage != null)
        {
            backgroundImage.color = hoverColor;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isSelected && backgroundImage != null)
        {
            backgroundImage.color = normalColor;
        }
    }

    public (string, int) ElementPickRandom()
    {
        List<int> validIndices = new List<int>();

        for (int i = 0; i < elements.Count; i++)
        {
            if (elements[i].GetComponent<TextMeshProUGUI>().text != "")
            {
                validIndices.Add(i); 
            }
        }

        if (validIndices.Count > 0)
        {
            int chosenIndex = validIndices[Random.Range(0, validIndices.Count)];
            string chosenText = elements[chosenIndex].GetComponent<TextMeshProUGUI>().text;
            return (chosenText, chosenIndex);
        } else {
            return (null, 0);
        }
    }

    public void RemoveElement(string elementPick, int index)
    {
        elements[index].GetComponent<TextMeshProUGUI>().text = "";
    }

    public void ActionEvent(string elementPick)
    {
        if (elementPick.StartsWith("EnnemyPhysique"))
        {
            if (player.Force < ExtractNumber(elementPick))
            {
                player.RemoveLife();
            }
        } 
        else if (elementPick.StartsWith("EnnemyMage"))
        {
            if (player.Magie < ExtractNumber(elementPick))
            {
                player.RemoveLife();
            }
        } 
    }

    public int ExtractNumber(string input)
    {
        Match match = Regex.Match(input, @"\d+");
        if (match.Success)
        {
            return int.Parse(match.Value);
        }
        return -1;
    }
}
