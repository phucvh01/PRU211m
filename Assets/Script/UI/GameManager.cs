using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject draggingGameobject;
    public GameObject containerGameobject;
    public GameObject powerupGameobject; 
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void placeContainer()
    {
        if (draggingGameobject != null && containerGameobject != null)
        {
            
            GameObject objectGame = Instantiate(draggingGameobject.GetComponent<ObjectDragging>().card.Game_Plant, containerGameobject.transform);
            objectGame.GetComponent<PlantScript>().zombies = containerGameobject.GetComponent<ContainerScript>().spawnPoint.zombies;
            containerGameobject.GetComponent<ContainerScript>().isFull = true;
        }
    }
    public void placePowerup()
    {

    }
}
