using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _textHealth;
    [SerializeField] TextMeshProUGUI _textCoin;

    void Start()
    {
        EventManager.onHealth.AddListener(UpdateHealth);
        EventManager.onSumCoin.AddListener(UpdateCoin);
    }
    void UpdateHealth (int health)
    {
        _textHealth.text = ("Hp:"+ health.ToString());
    }
     void UpdateCoin (int coin)
    {
        _textCoin.text = ("Coin:"+coin.ToString());
    }

    private void OnDisable()
    {
        EventManager.onHealth.RemoveListener(UpdateHealth);
        EventManager.onSumCoin.RemoveListener(UpdateCoin);
        
    }
}
