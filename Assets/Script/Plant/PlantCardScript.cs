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

    public int cost;
    public float coolDown = 2f;

    public RectTransform panelImg;

    public bool plantDrop ;
    public int Price;
    private GameObject objectDragInstatiate;
    private string plantType;
    public GameManager gameManager;
    public Canvas canvas;
    
    private void Start()
    {
        gameManager = GameManager.instance;
        plantType = Game_Plant.GetComponent<PlantScript>().Ptype.ToString();
        //Debug.Log(plantType);
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
        //neu plant sale truoc thi khong co cooldown
        //plant sale sau thi co cooldown nhung lai khong co tru tiewn
        plantSale();
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

        //check to make poiter different
        if (plantDrop == true && gameManager.draggingGameobject != null && gameManager.containerGameobject != null)
        {
            CoinSpawner.coin = CoinSpawner.coin - cost;
            gameManager.placeContainer();
            this.GetComponent<CanvasGroup>().alpha = 0.6f;
            loadingCooldown.enabled = true;
            //courontine here
            //dont let anyone place plant
            plantDrop = false;
            StartCoroutine(cooldownPlant(coolDown));
            gameManager.draggingGameobject = null;
            //dat dung cung destroy
            Destroy(objectDragInstatiate);

        }
        else
        {
            //dat sai thi destroy ma ko co cooldown
            Destroy(objectDragInstatiate);
        }
    }
    private IEnumerator cooldownPlant(float duration)
    {
        plantDrop = false;
        float normalizedTime = 0;
        while (normalizedTime <= 1f)
        {
            loadingCooldown.fillAmount = normalizedTime;
            normalizedTime += Time.deltaTime / duration;
            yield return null;

        }

        //thoat while la ket thuc timer
        //Debug.Log("outt");
        plantDrop = true;
        this.GetComponent<CanvasGroup>().alpha = 1f;
        loadingCooldown.enabled = false;

    }
    //do logic o day sai
    void plantSale()
    {
        if (plantType == "Shooter")
        {
            cost = 15;
            if (CoinSpawner.coin >= cost)
            {
                plantDrop = true;

                //CoinSpawner.coin= CoinSpawner.coin - cost;
                
            }
            else
            {
                plantDrop = false;
            }
        }
        if (plantType == "Bomber")
        {
            cost = 20;
            if (CoinSpawner.coin >= cost)
            {
                plantDrop = true;
                //CoinSpawner.coin = CoinSpawner.coin - cost;

            }
            else
            {
                plantDrop = false;
            }
        }
        if (plantType == "Money")
        {
            cost = 10;
            if (CoinSpawner.coin >= cost)
            {
                plantDrop = true;
                //CoinSpawner.coin = CoinSpawner.coin - cost;

            }
            else
            {
                plantDrop = false;
            }
        }
    }


}
