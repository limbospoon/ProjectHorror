using UnityEngine;

[System.Serializable]
public class Item : object
{
    public virtual void Use()
    {
        Debug.Log("Used!!");
    }
}
