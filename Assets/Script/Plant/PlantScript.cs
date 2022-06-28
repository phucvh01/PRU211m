using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 10;
    public bool isShoot;
    public float Damage;
    public float attackCooldown;
    public float attackTime;

    public enum plantType { Shooter, Bomber, Money }
    public plantType Ptype;


    public GameObject bullet;
    public GameObject coinPrefabs;
    public List<GameObject> zombies;

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        if (Ptype == plantType.Shooter)
        {
            //shoot ahead
            shootbullet();
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
        if (zombies.Count > 0 && isShoot == false)
        {
            Debug.Log("Im here");
            isShoot = true;
            if (attackTime <= Time.time)
            {
                Debug.Log("Im also here");
                var a= Instantiate(bullet, transform);
                Debug.Log(a.transform.name.ToString());
                attackTime = Time.time + attackCooldown;
                isShoot = false;
            }

        }
        else if (zombies.Count == 0 && isShoot == true)
        {
            isShoot = false;
            Debug.Log("Im out");
        }
        else
        {
            isShoot = false;
        }

    }


}
