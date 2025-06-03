using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ColumnElementContainRandom : MonoBehaviour
{
    [SerializeField] private GameObject[] elements;
    [SerializeField] private GameObject[] pointDmg;
    [SerializeField] private Player player;
    [SerializeField] private Sprite ennemieForce;
    [SerializeField] private Sprite ennemieMage;
    [SerializeField] private Sprite coffre;


    void Start()
    {
        RandomElementInGrid();
    }

    public void RandomElementInGrid()
    {
        for (int i = 0; i < 4; i++)
        {
            int elementIndex = i;
            int elementChoose = Random.Range(0, 100);
            (Sprite elementChooseName, string point) = AssignElementInGrid(elementChoose);
            elements[elementIndex].GetComponent<Image>().sprite = elementChooseName;
            pointDmg[elementIndex].GetComponent<TextMeshProUGUI>().text = point;
        }

    }

    private (Sprite, string) AssignElementInGrid(int elementChoose)
    {
        Sprite elementName;
        int currentLevel = player.Level + 1;
        int fightPoint = Random.Range(0, currentLevel);

        if (elementChoose >= 0 && elementChoose <= 15) 
        {
            elementName = ennemieForce;
            return (elementName, fightPoint.ToString());
        } 
        else if (elementChoose > 15 && elementChoose <= 30)
        {
            elementName = ennemieMage;
            return (elementName, fightPoint.ToString());
        } else
        {
            elementName = coffre;
            return (elementName, "");
        }
    }
}
