using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinprefab;
    public GameObject coinPool;
    public float timeLeft=10f;
    public Text coinText;
    public static int coin =1000;
    private void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            spawnCoin();
            timeLeft = 10f;
        }
        coinText.text = coin+ "";

    }
    void spawnCoin()
    {
        //Debug.Log("Spawm a coin");
        var a = Instantiate(coinprefab,new Vector2((float)Random.Range(400,1700),transform.position.y),coinprefab.transform.rotation,coinPool.transform);
       // Debug.Log(a.transform.position.x);
       
    }

    void OnBecameInvisible()
    {
         Destroy(this.gameObject);
    }

}
