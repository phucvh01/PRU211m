using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    // Start is called before the first frame update
    #region zombies variables

    public Vector3 finalDestination;
    public int Health;
    public int Damage;
    public float Speed;
    public float attackSpeed;
    private bool isAttack;
    #endregion
    private bool isStopped;
    private Animator anim;
    public AudioSource audio;
    public AudioSource ZombieRecieve_audio;

    private void Awake()
    {
        audio.Play();
        anim = GetComponent<Animator>();
    }
    private GameObject getPlantHealth;
    private void Start()
    {
        

    }
    // Update is called once per frame
    void Update()
    {
        if (!isStopped)
        {
            anim.SetBool("walker_attack", false);
            transform.Translate(new Vector3(Speed * -1, 0, 0)*Time.deltaTime);
        }
        if (isAttack)
        {
            anim.SetBool("walker_attack", true);
            attackSpeed -= Time.deltaTime;
            if (attackSpeed < 0)
            {
                AttackThePlant(getPlantHealth);
                attackSpeed = 1f;
            }

        }
        

        if (transform.localPosition.x <= finalDestination.x)
        {
            //Debug.Log(transform.position.x);
            //Debug.Log("have stopped");
            isStopped = true;
            GameStateManager.isLost = true;
            //lose game logic 

        }
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.layer == 8 &&collision.gameObject.tag!="Player")
        {
            Debug.Log("Collde");
            isStopped = true;
            isAttack = true;
            getPlantHealth = collision.gameObject;
        }
        
    }
   
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.layer == 8 && collision.gameObject.tag != "Player")
        {
            Debug.Log("Exist");
            isStopped = false;
            isAttack = false;
        }
    }



    public void receiveDamage(int damage)
    {
        if (Health - damage <= 0)
        {
            //anim.SetBool("walker_dead", true);
            transform.parent.GetComponent<SpawnPoint>().zombies.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
        else
        {
            
            Health = Health - damage;
            ZombieRecieve_audio.Play();
            //Debug.Log(Health);
        }
    }
    void AttackThePlant(GameObject plantHealth)
    {
        int healthh = plantHealth.GetComponent<PlantScript>().health;

        if (healthh - Damage <= 0)
        { 
            //might be false
            plantHealth.GetComponentInParent<ContainerScript>().isFull = false;
            Destroy(plantHealth.gameObject);
            //viet lai is full =false o day la dc

        }
        else
        {
            healthh = healthh - Damage;
            plantHealth.GetComponent<PlantScript>().health = healthh;
           
            //Debug.Log(healthh+"");
        }
    }
    IEnumerator die()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
    }
}
