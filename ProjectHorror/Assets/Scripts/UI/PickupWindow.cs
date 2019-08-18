using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class PickupWindow : UIWindow
{
    public HorrorCharacter playerRef;
    public UIHandler uiHandler;
    public GameObject pickupWindow;
    public MeshFilter currentDisplayObject;
    public GameObject yesButton;
    public GameObject noButton;
    public Text pickupText;

    public override void ToggleDisplay(bool show)
    {
        if(playerRef && show)
        {
            pickupText.text = "Take " + playerRef.interactable.GetComponent<Pickup>().item.name + " ?";
            UpdateDisplayWindow();
            uiHandler.currentWindow = UIHandler.CurrentWindow.Pickup;
        }
        else if(!show)
        {
            uiHandler.currentWindow = UIHandler.CurrentWindow.None;
        }
        pickupWindow.SetActive(show);
    }

    void UpdateDisplayWindow()
    {
        for (int i = 0; i < uiHandler.displayMeshes.Count; i++)
        {
            if (uiHandler.displayMeshes[i].name == playerRef.interactable.GetComponent<Pickup>().item.name)
            {
                currentDisplayObject.mesh = uiHandler.displayMeshes[i];
                break;
            }
        }
    }

    private void Start()
    {
        pickupText.text = "";
        yesButton.AddComponent<YesButton>();
        yesButton.GetComponent<YesButton>().pickupWindow = this;

        noButton.AddComponent<NoButton>();
        noButton.GetComponent<NoButton>().pickupWindow = this;
    }
}

public class YesButton : MonoBehaviour, IPointerClickHandler
{
    public PickupWindow pickupWindow;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(pickupWindow)
        {
            pickupWindow.playerRef.interactable.GetComponent<Pickup>().PickupItem();
            pickupWindow.ToggleDisplay(false);
            pickupWindow.playerRef.EnableControls();
            pickupWindow.currentDisplayObject.mesh = null;
        }
    }
}

public class NoButton : MonoBehaviour, IPointerClickHandler
{
    public PickupWindow pickupWindow;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (pickupWindow)
        {
            pickupWindow.ToggleDisplay(false);
            pickupWindow.playerRef.EnableControls();
            pickupWindow.currentDisplayObject.mesh = null;
        }
    }
}