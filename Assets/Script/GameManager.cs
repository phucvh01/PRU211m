using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject draggingGameobject;
    public GameObject containerGameobject;
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void placeContainer()
    {
        if (draggingGameobject != null && containerGameobject != null)
        {
            Debug.Log(draggingGameobject.GetComponent<ObjectDragging>().card.Game_Plant.name.ToString());
            Instantiate(draggingGameobject.GetComponent<ObjectDragging>().card.Game_Plant, containerGameobject.transform);
            containerGameobject.GetComponent<ContainerScript>().isFull = true;
        }
    }
}
