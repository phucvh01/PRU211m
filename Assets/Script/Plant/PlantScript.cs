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



        }
        else if (PowerUp == slot.Earth)
        {

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
        if (zombies.Count > 0 && isShoot == false)
        {
            //audio.Play();
            anim.SetBool("attack", true);
            timeLeft -= Time.deltaTime;
            //Debug.Log(timeLeft);
            if (timeLeft < 0)
            {
              
                timeLeft = waitTime;
                //spawn dan
                var a = Instantiate(bullet, this.transform.position, Quaternion.identity);
                a.transform.SetParent(transform);
                Debug.Log(transform.position+ " check for bullet");
                //Debug.Log("again");
                isShoot = false;
            }

        }
        else if (zombies.Count == 0 && isShoot == true)
        {
            anim.SetBool("attack", false);
            //Debug.Log(zombies.Count+"");
            Debug.Log(isShoot);
            isShoot = false;
            Debug.Log("Im out");

        }
        //audio.Stop();

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
