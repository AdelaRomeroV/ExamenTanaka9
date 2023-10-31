using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifeUi : MonoBehaviour
{
    public TMP_Text lifeText;
    void Awake()
    {
        lifeText = GetComponent<TMP_Text>();
    }

    public void UpdateText(int value)
    {
        lifeText.text = "Life: " + value;

    }
}
