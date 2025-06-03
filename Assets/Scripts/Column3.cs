using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Column3 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject[] GameObject;
    [SerializeField] private Sprite nothing;
    [SerializeField] private Sprite open;
    void Start()
    {
        for (int i = 0; i < GameObject.Length; i++)
        {
            GameObject[i].GetComponent<Image>().sprite = nothing;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        for (int i = 0; i < GameObject.Length; i++)
        {
            GameObject[i].GetComponent<Image>().sprite = open;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        for (int i = 0; i < GameObject.Length; i++)
        {
            GameObject[i].GetComponent<Image>().sprite = nothing;
        }
    }
}
