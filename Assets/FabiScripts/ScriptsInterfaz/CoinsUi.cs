using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsUi : MonoBehaviour
{
    public TMP_Text coinText;
    void Awake()
    {
        coinText = GetComponent<TMP_Text>();
    }

    void UpdateText(int value)
    {
        coinText.text = "Coin: " + value;
    }
}
