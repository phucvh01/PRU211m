using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CoinScript : MonoBehaviour, IPointerDownHandler
{
    // Start is called before the first frame update
    public float speedFall;
    public GameObject destination;

    public void OnPointerDown(PointerEventData eventData)
    {
        CoinSpawner.coin++;
     
        Destroy(gameObject);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down*speedFall*Time.deltaTime);
    }
}
