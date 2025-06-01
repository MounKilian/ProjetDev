using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class ColumnElementContainRandom : MonoBehaviour
{
    [SerializeField] private GameObject[] elements;

    void Start()
    {
        RandomElementInGrid();
    }

    void RandomElementInGrid()
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

        if (elementChoose >= 0 && elementChoose <= 15)
        {
            elementName = "Ennemy 1";
        } else if (elementChoose > 15 && elementChoose <= 30)
        {
            elementName = "Ennemy 2";
        } else
        {
            elementName = "Coffre";
        }

        return elementName;
    }
}
