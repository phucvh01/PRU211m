using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 1;
    public bool isShoot = false;
    public GameObject bullet;
   

    void Start()
    {
        isShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        //shootbullet();
    }
    void shootbullet()
    {
        if (isShoot == true) {
        StartCoroutine(bulletshoot(1)); }
    }

    IEnumerator bulletshoot(float duration)
    {
        float normalizedTime = 0;
        while (normalizedTime <= 1f)
        {
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }

        //thoat while la ket thuc timer
        isShoot = true;
      
    }
}
