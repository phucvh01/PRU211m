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

    #endregion
    private bool isStopped;
    private void Start()
    {
        

    }
    // Update is called once per frame
    void Update()
    {
        if (!isStopped)
        {
            transform.Translate(new Vector3(Speed * -1, 0, 0));
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8 &&collision.gameObject.tag!="Player")
        {
            Debug.Log("Collde");
            isStopped = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8 && collision.gameObject.tag != "Player")
        {
            Debug.Log("Collde");
            isStopped = false;
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
            Debug.Log(Health);
        }
    }
}
