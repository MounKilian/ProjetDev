using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PopUp : MonoBehaviour
{
    [SerializeField] private GameObject popUp;
    [SerializeField] private GameObject passer;

    void Start()
    {
        popUp.SetActive(false);
    }

    void Update()
    {
        
    }
}
