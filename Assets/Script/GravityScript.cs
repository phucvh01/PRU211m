using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityScript : MonoBehaviour
{
     public bool isgrounded = true;
    private Rigidbody rb;
    private Rigidbody ForceMode;
    void Update()
    {
        if (isgrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                rb.AddForce(Vector3.left * 1);
                rb.AddForce(Vector3.forward * 1);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                rb.AddForce(Vector3.right * 1);
                rb.AddForce(Vector3.forward * 1);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                Vector3 dir = new Vector3(-10f, 15f, 0f);
                dir.Normalize();
                this.gameObject.GetComponent<Rigidbody>().AddForce(dir * 50);
                rb.AddForce(Vector3.forward * 1);

            }
        }
    }
    //make sure u replace "floor" with your gameobject name.on which player is standing
    //void OnCollisionEnter(theCollision : Collision)
    //{
    //    if (theCollision.gameObject.name == "floor")
    //    {
    //        isgrounded = true;
    //    }
    //}

    ////consider when character is jumping .. it will exit collision.
    //void OnCollisionExit(theCollision : Collision)
    //{
    //    if (theCollision.gameObject.name == "floor")
    //    {
    //        isgrounded = false;
    //    }
    //}
}
