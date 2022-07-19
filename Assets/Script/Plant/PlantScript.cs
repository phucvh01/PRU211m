using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    public bool isShoot;
    public float Damage;

    public float timeLeft = 10f;
    public float waitTime = 10f;
    public enum plantType { Shooter, Bomber, Money }
    public plantType Ptype;

    //need power type here

    public GameObject bullet;
    public GameObject coinPrefabs;
    public enum slot { Non, Fire, Ice, Earth };
    public slot PowerUp;
    public slot SecretPowerUp;
    //public AudioSource audio;
    public List<GameObject> zombies;

    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {


        if (Ptype == plantType.Shooter)
        {
            //shoot ahead
            health = 10;
            Damage = 10;
            timeLeft = 3f;
            waitTime = 3f;


        }
        else if (Ptype == plantType.Bomber)
        {
            health = 100;


        }
        else if (Ptype == plantType.Money)
        {
            health = 5;
            timeLeft = 3f;
            waitTime = 3f;

            //spawn money here
        }

        if (PowerUp == slot.Fire)
        {
            //add hieu ung chay vao day?
            bullet.GetComponent<BulletScript>().bulletDamage = 2;
            bullet.GetComponent<BulletScript>().bulletSpeed = 2;
        
        }
        else if (PowerUp == slot.Ice)
        {
            bullet.GetComponent<BulletScript>().bulletDamage = 2;
            bullet.GetComponent<BulletScript>().bulletSpeed = 2;


        }
        else if (PowerUp == slot.Earth)
        {
            bullet.GetComponent<BulletScript>().bulletDamage = 2;
            bullet.GetComponent<BulletScript>().bulletSpeed = 2;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (Ptype == plantType.Shooter)
        {
            //shoot ahead
            shootbullet();


        }
        else if (Ptype == plantType.Bomber)
        {

        }
        else if (Ptype == plantType.Money)
        {
            spawnCoin();
        }
    }
    void shootbullet()
    {

        //need sound and vfx here
        if (zombies.Count > 0)
        {
            //audio.Play();
            anim.SetBool("attack", true);
            timeLeft -= Time.deltaTime;
            //Debug.Log(timeLeft);
            if (timeLeft < 0)
            {
              
                timeLeft = waitTime;
                var a = Instantiate(bullet, this.transform.position, Quaternion.identity);
                a.transform.SetParent(transform);
               
            }

        }
        else if (zombies.Count == 0)
        {
            anim.SetBool("attack", false);
        }

    }
    void spawnCoin()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {

            timeLeft = waitTime;
            var a = Instantiate(coinPrefabs, transform.position, coinPrefabs.transform.rotation, this.transform);
            a.GetComponent<CoinScript>().speedFall = 1f;

        }

    }


}
