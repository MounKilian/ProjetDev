using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Text.RegularExpressions;

public class ColumnClickHandler : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private List<GameObject> elements;
    [SerializeField] private GameObject[] pointDmg;

    [SerializeField] private Image backgroundImage;
    [SerializeField] private Porte porteScript;
    [SerializeField] private GameObject playerText;
    [SerializeField] private Player player;
    [SerializeField] private Sprite ennemieForce;
    [SerializeField] private Sprite ennemieMage;
    [SerializeField] private Sprite coffre;
    [SerializeField] private Sprite nothing;

    public void OnPointerClick(PointerEventData eventData)
    {
        Sprite elementPick;
        int index;
        (elementPick, index) = ElementPickRandom();
        if (elementPick != null)
        {
            ActionEvent(elementPick, pointDmg[index].GetComponent<TextMeshProUGUI>().text);
            RemoveElement(index);
            porteScript.IncrementCompteur();
            playerText.transform.position = elements[index].transform.position;
        }
    }

    public (Sprite, int) ElementPickRandom()
    {
        List<int> validIndices = new List<int>();

        for (int i = 0; i < elements.Count; i++)
        {
            if (elements[i].GetComponent<Image>().sprite != nothing)
            {
                validIndices.Add(i); 
            }
        }

        if (validIndices.Count > 0)
        {
            int chosenIndex = validIndices[Random.Range(0, validIndices.Count)];
            Sprite chosenText = elements[chosenIndex].GetComponent<Image>().sprite;
            return (chosenText, chosenIndex);
        } else {
            return (null, 0);
        }
    }

    public void RemoveElement(int index)
    {
        elements[index].GetComponent<Image>().sprite = nothing;
        pointDmg[index].GetComponent<TextMeshProUGUI>().text = "";
    }

    public void ActionEvent(Sprite elementPick, string point)
    {
        if (elementPick == ennemieForce)
        {
            if (player.Force < ExtractNumber(point))
            {
                player.RemoveLife();
            }
        }
        else if (elementPick == ennemieMage)
        {
            if (player.Magie < ExtractNumber(point))
            {
                player.RemoveLife();
            }
        }
        else if (elementPick == coffre)
        {
            player.IncrementOr();
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
