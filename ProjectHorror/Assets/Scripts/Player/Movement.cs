using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    public float gravity;

    private CharacterController cc;
    private float turnAxis;
    private Quaternion ogRot;

    // Start is called before the first frame update
    void Start()
    {
        ogRot = transform.localRotation;
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    public void Move(Vector3 direction)
    {
        if(isGrounded())
        {
            turnAxis += Input.GetAxisRaw("Horizontal") * turnSpeed;

            turnAxis = AngleClamp.ClampAngle(turnAxis, -360.0f, 360.0f);

            Quaternion xQuat = Quaternion.AngleAxis(turnAxis, Vector3.up);

            transform.localRotation = ogRot * xQuat;

            direction = transform.TransformDirection(direction);
            direction *= speed;
        }

        direction.y -= gravity * Time.deltaTime;

        cc.Move(direction * Time.deltaTime);
    }

    bool isGrounded()
    {
        if(cc.isGrounded)
        {
            return true;
        }

        Vector3 bottom = cc.transform.position - new Vector3(0, cc.height / 2, 0);

        RaycastHit hit;

        if(Physics.Raycast(bottom, -Vector3.up, out hit, 0.5f))
        {
            cc.Move(new Vector3(0, -hit.distance, 0));
            return true;
        }

        return false;
    }


}
