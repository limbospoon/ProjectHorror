using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Range(1.0f, 20.0f)]
    public float xSensitivity = 15.0f;
    [Range(1.0f, 20.0f)]
    public float ySensitivity = 15.0f;
    public enum Mode
    {
        XandY,
        XOnly,
        YOnly
    }
    public Mode mode;

    private float rotX = 0f;
    private float rotY = 0f;

    private Quaternion ogRot;

    // Start is called before the first frame update
    void Start()
    {
        ogRot = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        switch(mode)
        {
            case Mode.XandY:
                {

                    rotX += Input.GetAxis("Mouse X") * xSensitivity;
                    rotY += Input.GetAxis("Mouse Y") * ySensitivity;

                    rotX = ClampAngle(rotX, -360.0f, 360.0f);
                    rotY = ClampAngle(rotY, -60, 60);

                    Quaternion xQuat = Quaternion.AngleAxis(rotX, Vector3.up);
                    Quaternion yQuat = Quaternion.AngleAxis(rotY, -Vector3.right);

                    transform.localRotation = ogRot * xQuat * yQuat;
                    break;
                }
            case Mode.XOnly:
                {
                    rotX += Input.GetAxis("Mouse X") * xSensitivity;
                    
                    rotX = ClampAngle(rotX, -360.0f, 360.0f);
                    
                    Quaternion xQuat = Quaternion.AngleAxis(rotX, Vector3.up);
                    
                    transform.localRotation = ogRot * xQuat;
                    break;
                }
            case Mode.YOnly:
                {
                    rotY += Input.GetAxis("Mouse Y") * ySensitivity;
                    rotY = ClampAngle(rotY, -60, 60);

                    Quaternion yQuat = Quaternion.AngleAxis(rotY, -Vector3.right);

                    transform.localRotation = ogRot * yQuat;
                    break;
                }
        }
    }

    float ClampAngle(float angle, float min, float max)
    {
        if(angle < -360.0f)
        {
            angle += 360.0f;
        }
        else if(angle > 360.0f)
        {
            angle -= 360.0f;
        }
        return Mathf.Clamp(angle, min, max);
    }
}
