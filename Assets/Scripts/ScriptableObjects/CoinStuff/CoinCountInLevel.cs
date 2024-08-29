using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CoinCountInLevel", menuName = "ScriptableObjects/Levels/CoinCount", order = 1)]
public class CoinCountInLevel : ScriptableObject
{
    public int currentCoinCount;

    public void resetCoins()
    {
        currentCoinCount = 0;
    }
}
