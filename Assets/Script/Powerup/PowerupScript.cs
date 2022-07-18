using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PlantObjectPower;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Hitsomething");
        if (collision.gameObject.layer == 8)
        {
            Debug.Log("hit");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //shooterclass only
        if (collision.gameObject.layer == 8)
        {
            //Debug.Log("Hitsomethinghere");
          
            if (Input.GetMouseButtonUp(0))
            {
                
                GameObject a= Instantiate(PlantObjectPower, collision.transform.parent);
                a.GetComponent<PlantScript>().zombies=collision.GetComponent<PlantScript>().zombies;
                
                Debug.Log(a.transform.position);
                Debug.Log("here release");
                Destroy(collision.gameObject);
                Destroy(this);
            }
        }

    }

}
