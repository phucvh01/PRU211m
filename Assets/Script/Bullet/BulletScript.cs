using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float bulletSpeed=1f;
    public int bulletDamage=1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(bulletSpeed, 0, 0));
    }
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
         Debug.Log("Hit");
            
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("HIt");
        collision.gameObject.GetComponent<ZombieController>().receiveDamage(bulletDamage);
        
        Destroy(this.gameObject);
    }
}
