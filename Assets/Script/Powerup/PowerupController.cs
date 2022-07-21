using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PowerupController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public GameObject DragGameObject;
    public bool Draggable;
    private GameObject objectDragInstatiate;
    //public GameObject Game_Plant;
    public Canvas canvas;
    public GameManager gameManager;
    public int cost;
    private void Start()
    {
        gameManager = GameManager.instance;
    }

    public void OnDrag(PointerEventData eventData)
    {

        objectDragInstatiate.transform.position = Input.mousePosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (CoinSpawner.coin >= cost) { 
        objectDragInstatiate = Instantiate(DragGameObject, canvas.transform);
        objectDragInstatiate.transform.position = Input.mousePosition;
            CoinSpawner.coin -= cost;
        }
       

        //GameManager.instance.draggingGameobject = objectDragInstatiate;
        //objectDragInstatiate.GetComponent<ObjectDragging>().power = this;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
      
        //gameManager.pla();
        //same as plant but different
        Destroy(objectDragInstatiate);
    }





    // Start is called before the first frame update

}
