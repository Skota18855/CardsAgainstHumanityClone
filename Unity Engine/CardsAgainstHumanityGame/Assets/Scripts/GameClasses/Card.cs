using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Card : MonoBehaviour
{
    public string CardText { get; set; } = "";

    TextMeshProUGUI textElement = null;

    private void Start()
    {
        textElement = GetComponentInChildren<TextMeshProUGUI>();
    }
}
