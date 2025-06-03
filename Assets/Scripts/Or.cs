using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Or : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject UIOr;

    void Start()
    {
        
    }

    void Update()
    {
        UIOr.GetComponent<TextMeshProUGUI>().text = player.Or.ToString();
    }
}
