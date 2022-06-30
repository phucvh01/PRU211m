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
    
    private GameObject getPlantHealth;
    private void Start()
    {
        

    }
    // Update is called once per frame
    void Update()
    {
        if (!isStopped)
        {
            transform.Translate(new Vector3(Speed * -1, 0, 0)*Time.deltaTime);
        }
        if (isAttack)
        {
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
            transform.parent.GetComponent<SpawnPoint>().zombies.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
        else
        {
            
            Health = Health - damage;
            //Debug.Log(Health);
        }
    }
    void AttackThePlant(GameObject plantHealth)
    {
        int healthh = plantHealth.GetComponent<PlantScript>().health;

        if (healthh - Damage <= 0)
        {
            Destroy(plantHealth.gameObject);

        }
        else
        {
            healthh = healthh - Damage;
            plantHealth.GetComponent<PlantScript>().health = healthh;
            //Debug.Log(healthh+"");
        }
    }
}
