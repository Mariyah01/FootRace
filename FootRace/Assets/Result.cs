using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Result : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI p1Result;
    [SerializeField] private TextMeshProUGUI p2Result;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            p1Result.text = "You won!";
            p2Result.text = "Try again";
        } else if (other.gameObject.CompareTag("Player2"))
        {
            p1Result.text = "Try again";
            p2Result.text = "You won!";
        }
            
            
    }
}
