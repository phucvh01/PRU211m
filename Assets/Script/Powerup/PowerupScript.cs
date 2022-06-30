using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScript : MonoBehaviour
{
    // Start is called before the first frame update
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
        if (collision.gameObject.layer == 8)
        {
            //Debug.Log("Hitsomethinghere");

            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("here release");
                Destroy(this);
            }
        }

    }

}
