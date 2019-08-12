using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public enum CurrentWindow
    {
        None,
        Inventory
    }
    public CurrentWindow currentWindow;

    private void Awake()
    {
        currentWindow = CurrentWindow.None;
    }

    // Update is called once per frame
    void Update()
    {
               
    }

    private void OpenWindow(string windowName)
    {
        switch(windowName)
        {
            case "None":
                {
                    currentWindow = CurrentWindow.None;
                    break;
                }
            case "Inventory":
                {
                    currentWindow = CurrentWindow.Inventory;
                    break;
                }
        }

    }
}
