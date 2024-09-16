using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
        
    public CoinCountInLevel coinCountLevel;
    public TMP_Text coinText;

    // Start is called before the first frame update
    void Start()
    {
        coinCountLevel.resetCoins();
    }

    public void collectCoin(int coinValue)
    {
        coinCountLevel.currentCoinCount += coinValue;
        coinText.text = "Coins: " + coinCountLevel.currentCoinCount;
    }

    public int getCoinCount()
    {
        return coinCountLevel.currentCoinCount;
    }
}
