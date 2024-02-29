using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;


public class ItemSlot : MonoBehaviour,IDropHandler
{
    [SerializeField] private GameObject slot;
    public static int animalCount;

    public void Start()
    {
        animalCount = 15;              //total animals in the scene
    }
    public void OnDrop(PointerEventData eventData)
    {
        //checking if the animals are being dropped in right slot
        if(eventData.pointerDrag != null && eventData.pointerDrag.CompareTag(slot.tag))
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.SetActive(false);
            animalCount--;
        }
    }
}
