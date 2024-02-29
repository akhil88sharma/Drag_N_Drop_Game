using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour,IPointerClickHandler,IBeginDragHandler,IEndDragHandler,IDragHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject description;


    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 loc;       //variable to store initial location

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        loc = rectTransform.anchoredPosition;          //saving initial position
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = .5f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;  //moving along with mouse pointer
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        rectTransform.anchoredPosition = loc;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        description.SetActive(true);                  //To check the description of the animal on click
    }
}
