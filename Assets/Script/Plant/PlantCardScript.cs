using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlantCardScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    // Start is called before the first frame update
    public GameObject Game_Plant;
    public GameObject Drag_Plant;

    public Image loadingCooldown;

    public float cost = 1f;
    public float coolDown = 2f;

    public RectTransform panelImg;

    public bool plantDrop = true;

    private GameObject objectDragInstatiate;

    public GameManager gameManager;
    public Canvas canvas;

    private void Start()
    {
        gameManager = GameManager.instance;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (plantDrop == true)
        {
            objectDragInstatiate.transform.position = Input.mousePosition;
            objectDragInstatiate.GetComponent<CanvasGroup>().alpha = 0.6f;
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (plantDrop == true)
        {
          
            objectDragInstatiate = Instantiate(Drag_Plant, canvas.transform);
            objectDragInstatiate.transform.position = Input.mousePosition;
            //insert the plant game information here
            GameManager.instance.draggingGameobject = objectDragInstatiate;
            objectDragInstatiate.GetComponent<ObjectDragging>().card = this;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        gameManager.placeContainer();  
        gameManager.draggingGameobject = null;
        
        Destroy(objectDragInstatiate);
      
        if (plantDrop == true)
        {
            this.GetComponent<CanvasGroup>().alpha = 0.6f;
            loadingCooldown.enabled = true;
            //courontine here
            plantDrop = false;
            StartCoroutine(cooldownPlant(coolDown));
            
        }
    }
    private IEnumerator cooldownPlant(float duration)
    {

        float normalizedTime = 0;
        while (normalizedTime <= 1f)
        {
            loadingCooldown.fillAmount = normalizedTime;
            normalizedTime += Time.deltaTime / duration;
            yield return null;
          
        }

        //thoat while la ket thuc timer

        plantDrop = true;
        this.GetComponent<CanvasGroup>().alpha = 1f;
        loadingCooldown.enabled = false;

    }


}
