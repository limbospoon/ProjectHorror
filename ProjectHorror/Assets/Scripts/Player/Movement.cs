using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    public float speed;
    public float gravity;

    private Vector3 moveDir = Vector3.zero;
    private CharacterController cc;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrounded())
        {
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDir = transform.TransformDirection(moveDir);
            moveDir *= speed;

        }

        moveDir.y -= gravity * Time.deltaTime;

        cc.Move(moveDir * Time.deltaTime);
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
