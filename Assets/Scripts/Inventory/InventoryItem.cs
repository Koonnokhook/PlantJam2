using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public ItemData item;

    [Header("UI")]
    public Image image;
    public string itemName;
    public Sprite itemIcon;

    [HideInInspector] public Transform parentAfterDrag;

    public void InitializeItem(ItemData newItem) 
    {
        item = newItem;
        image.sprite = newItem.itemIcon; 
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }
}
