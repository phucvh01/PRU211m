using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 1;
    public bool isShoot;
    public GameObject bullet;
    public enum plantType { Shooter, Bomber, Money }
    public plantType Ptype;

    public float plantShootSpeed;

    public GameObject coinPrefabs;

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
        if (Ptype == plantType.Shooter)
        {
            //shoot ahead

            isShoot = true;

        }
        else if (Ptype == plantType.Bomber)
        {
            //destroy all zombie tag
        }
        else if (Ptype == plantType.Money)
        {
            //spawn money here
        }
    }
    void shootbullet()
    {
        if (isShoot == true)
        {
            StartCoroutine(bulletshoot(1));
        }
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
        isShoot = false;
        Debug.Log("wait");

    }
}
