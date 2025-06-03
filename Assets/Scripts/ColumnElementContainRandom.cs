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

    int GetEnemySpawnChance(int level)
    {
        int baseChance = 30;
        int chancePer5Levels = (level / 5) * 5;

        return Mathf.Clamp(baseChance + (chancePer5Levels / 5) * 5, 30, 80);
    }


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
        int level = player.Level;
        int enemyChance = GetEnemySpawnChance(level);
        int min = Mathf.Max(0, level - 3);
        int fightPoint = Random.Range(min, level + 1);

        Sprite elementName;

        if (elementChoose < enemyChance / 2)
        {
            elementName = ennemieForce;
            return (elementName, fightPoint.ToString());
        }
        else if (elementChoose < enemyChance)
        {
            elementName = ennemieMage;
            return (elementName, fightPoint.ToString());
        }
        else
        {
            elementName = coffre;
            return (elementName, "");
        }
    }

}
