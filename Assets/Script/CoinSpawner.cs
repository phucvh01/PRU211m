using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinprefab;
    public GameObject coinPool;
    public float timeLeft=5;
    public Text coinText;
    public static int coin = 0;
    private void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            spawnCoin();
            timeLeft = 5f;
        }
        coinText.text = coin+ "";

    }
    void spawnCoin()
    {
        //Debug.Log("Spawm a coin");
        var a = Instantiate(coinprefab, transform.position,coinprefab.transform.rotation,coinPool.transform);
        
       
    }

}
