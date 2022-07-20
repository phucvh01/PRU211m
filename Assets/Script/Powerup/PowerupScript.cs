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
        if (collision.gameObject.layer == 8 && collision.GetComponent<PlantScript>().Ptype.ToString() == "Shooter")
        {
            if (Input.GetMouseButton(0))
            {

                Debug.Log("Hitsomethinghere");

                GameObject a = Instantiate(PlantObjectPower, collision.transform.parent);
                a.GetComponent<PlantScript>().zombies = collision.GetComponent<PlantScript>().zombies;
                

               

                Destroy(collision.gameObject);

            }
        }

    }


}
