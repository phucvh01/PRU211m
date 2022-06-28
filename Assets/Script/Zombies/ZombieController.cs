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
        if (collision.gameObject.layer == 8)
        {
            Debug.Log("Collde");
            isStopped = true;
        }
    }
}
