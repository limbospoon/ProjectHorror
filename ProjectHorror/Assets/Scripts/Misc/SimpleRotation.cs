using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotation : MonoBehaviour
{
    public float speed = 5.0f;

    private float angle = 0;
    private Quaternion startRot;

    private void Awake()
    {
        startRot = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        angle += speed * Time.deltaTime;
        angle = AngleClamp.ClampAngle(angle, -360.0f, 360.0f);

        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.localRotation = startRot * q;
    }

    public void ResetRotation()
    {
        transform.localRotation = Quaternion.identity;
    }
}
