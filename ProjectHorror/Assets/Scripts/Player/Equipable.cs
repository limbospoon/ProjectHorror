using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipable : MonoBehaviour
{
    public GameObject model;

    public void Equip(Transform attachPoint)
    {
        GameObject go = Instantiate(model, Vector3.zero, Quaternion.identity);
        go.transform.parent = attachPoint;
        go.transform.position = attachPoint.position;
    }
}
