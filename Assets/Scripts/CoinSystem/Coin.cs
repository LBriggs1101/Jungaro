using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public int coinValue;
    private CoinManager coinManager;

    private void Awake() 
    {
        coinManager = GameObject.Find("CoinManager").GetComponent<CoinManager>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            coinManager.collectCoin(coinValue);
            Destroy(gameObject);
        }    
    }
}
