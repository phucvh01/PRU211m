using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PowerupController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public GameObject DragGameObject;
    public bool Draggable;
    private GameObject objectDragInstatiate;
    
    public Canvas canvas;

   
    public void OnDrag(PointerEventData eventData)
    {
        objectDragInstatiate.transform.position = Input.mousePosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        objectDragInstatiate = Instantiate(DragGameObject, canvas.transform);
        objectDragInstatiate.transform.position = Input.mousePosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //same as plant but different
        Destroy(objectDragInstatiate);
    }





    // Start is called before the first frame update

}
