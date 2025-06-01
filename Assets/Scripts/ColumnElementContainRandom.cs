using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class ColumnElementContainRandom : MonoBehaviour
{
    [SerializeField] private GameObject[] elements;
    [SerializeField] private Player player;

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
            string elementChooseName = AssignElementInGrid(elementChoose);


            TextMeshProUGUI textComponent = elements[elementIndex].GetComponent<TextMeshProUGUI>();
            textComponent.text = elementChooseName;
        }

    }

    string AssignElementInGrid(int elementChoose)
    {
        string elementName;
        int currentLevel = player.Level + 1;
        int fightPoint = Random.Range(0, currentLevel);

        if (elementChoose >= 0 && elementChoose <= 15) 
        {
            elementName = "EnnemyPhysique : " + fightPoint;
        } 
        else if (elementChoose > 15 && elementChoose <= 30)
        {
            elementName = "EnnemyMage : " + fightPoint;
        } else
        {
            elementName = "Coffre";
        }

        return elementName;
    }
}
