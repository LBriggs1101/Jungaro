using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
        
    public CoinCountInLevel coinCountLevel;

    // Start is called before the first frame update
    void Start()
    {
        coinCountLevel.resetCoins();
    }

    public void collectCoin(int coinValue)
    {
        coinCountLevel.currentCoinCount += coinValue;
    }
}
