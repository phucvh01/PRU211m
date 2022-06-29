using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PowerupController : MonoBehaviour, IPointerDownHandler, IDragHandler
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


    

    // Start is called before the first frame update

}
