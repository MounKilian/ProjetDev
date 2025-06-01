using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections.Generic;
using static UnityEditor.Rendering.FilterWindow;
using System.Diagnostics.Tracing;

public class ColumnClickHandler : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private bool isSelected = false;
    [SerializeField] private List<GameObject> elements;

    [SerializeField] private Image backgroundImage;

    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color hoverColor = new Color(0.9f, 0.9f, 1f);

    public void OnPointerClick(PointerEventData eventData)
    {
        string elementPick;
        int index;
        (elementPick, index) = ElementPickRandom();
        Debug.Log(elementPick + " choisi ! et " + index);
        RemoveElement(elementPick, index);
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

        int chosenIndex = validIndices[Random.Range(0, validIndices.Count)];
        string chosenText = elements[chosenIndex].GetComponent<TextMeshProUGUI>().text;
        return (chosenText, chosenIndex);
    }

    public void RemoveElement(string elementPick, int index)
    {
        elements[index].GetComponent<TextMeshProUGUI>().text = "";
    }
}
