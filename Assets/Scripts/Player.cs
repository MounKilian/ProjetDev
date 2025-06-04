using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    [SerializeField] private int magie = 1;
    [SerializeField] private int force = 1;
    [SerializeField] private int vie = 3;
    [SerializeField] private int level = 1;
    [SerializeField] private int ptsAmelioration = 0;
    [SerializeField] private int or = 0;
    [SerializeField] private GameObject UIPtsAmelioration;
    [SerializeField] private GameObject UIVie;
    [SerializeField] private GameObject UILevel;
    [SerializeField] private GameObject UIForce;
    [SerializeField] private GameObject UIMagie;

    public int Level { get => level; set => level = value; }

    public int Force { get => force; set => force = value; }

    public int Magie { get => magie; set => magie = value; }

    public int Or { get => or; set => or = value; }

    public int PtsAmelioration { get => ptsAmelioration; set => ptsAmelioration = value; }

    public void IncrementLevel()
    {
        Level++;
    }

    public void IncrementMagie()
    {
        Magie++;
    }

    public void IncrementForce()
    {
        Force++;
    }

    public void IncrementPtsAmelioration()
    {
        PtsAmelioration++;
    }

    public void DecrementPtsAmelioration()
    {
        PtsAmelioration--;
    }

    public void RemoveLife()
    {
        vie--;
    }

    public void IncrementOr()
    {
        or++;
    }

    public void IncrementLife()
    {
        vie++;
    }

    public void DecrementOr(int value)
    {
        or = or - value;
    }

    public void Update()
    {
        if (vie == 0)
        {
            print("Perdu");
        }

        UIPtsAmelioration.GetComponent<TextMeshProUGUI>().text = "Point Amélioration : " + PtsAmelioration;
        UIVie.GetComponent<TextMeshProUGUI>().text = vie.ToString();
        UILevel.GetComponent<TextMeshProUGUI>().text = level.ToString();
        UIMagie.GetComponent<TextMeshProUGUI>().text = magie.ToString();
        UIForce.GetComponent<TextMeshProUGUI>().text = force.ToString();
    }

}

