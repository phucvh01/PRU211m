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
    private void OnCollisonEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10) { 
            Debug.Log("Hit");
            collision.gameObject.GetComponent<ZombieController>().receiveDamage(bulletDamage);
            Destroy(this.gameObject);
            
}
        
    }
    
}
