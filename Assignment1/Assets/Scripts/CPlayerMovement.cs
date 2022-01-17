using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerMovement : MonoBehaviour
{
    [SerializeField]
    CharacterController characterController;
    [SerializeField]
    Animator animator;

    public float walkSpeed = .5f;
    public float rotationalSpeed = 50.0f;

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
        float speed = walkSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = walkSpeed * 2.0f;
        }
        if (animator == null) return;

        transform.Rotate(0.0f, hInput * rotationalSpeed * Time.deltaTime, 0.0f);
        Vector3 forward = transform.TransformDirection(Vector3.forward).normalized;
        forward.y = 0.0f;
        characterController.Move(forward * vInput * speed * Time.deltaTime);

        animator.SetFloat("PosX", 0);
        animator.SetFloat("PosZ", vInput * speed / 2.0f * walkSpeed);
    }
}
