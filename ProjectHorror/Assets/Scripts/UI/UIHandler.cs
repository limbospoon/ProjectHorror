using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public UIWindow[] uiWindows = new UIWindow[4];
    public List<Mesh> displayMeshes;

    public enum CurrentWindow
    {
        None,
        Inventory,
        Pickup
    }
    public CurrentWindow currentWindow;

    private void Awake()
    {
        currentWindow = CurrentWindow.None;
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentWindow)
        {
            case CurrentWindow.None:
                {
                    if(Input.GetKeyDown(KeyCode.I))
                    {
                        ToogleWindow(1, true);
                        currentWindow = CurrentWindow.Inventory;
                    }
                    break;
                }
            case CurrentWindow.Inventory:
                {
                    if (Input.GetKeyDown(KeyCode.I))
                    {
                        ToogleWindow(1, false);
                        currentWindow = CurrentWindow.None;
                    }
                    break;
                }
        }
    }

    public void ToogleWindow(int windowID, bool show)
    {
        foreach(UIWindow iw in uiWindows)
        {
            UIWindow iws = iw;
            if(iws.windowID == windowID)
            {
                iws.ToggleDisplay(show);
                break;
            }
        }
        if(show)
        {
            GameManager.UnLockCursor();
        }
        else
        {
            GameManager.LockCursor();
        }
    }
}

public class UIWindow : MonoBehaviour
{
    public int windowID;

    public virtual void ToggleDisplay(bool show)
    {

    }
}