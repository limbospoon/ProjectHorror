using UnityEngine.EventSystems;
using UnityEngine;

public class UseButton : MonoBehaviour, IPointerClickHandler
{
    public InventoryWindow inventoryWindow;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(inventoryWindow)
        {
            if(inventoryWindow.currentItem.name != "")
            {
                inventoryWindow.currentItem.itemClass.Use();
            }
        }
    }
}
