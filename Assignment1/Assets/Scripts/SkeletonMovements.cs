using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMovements : MonoBehaviour
{
    [SerializeField]
    CharacterController characterController;
    [SerializeField]
    Animator animator;

    public float walkSpeed = .5f;
    public float rotationalSpeed = 50.0f;

    public AudioSource walking;
    public AudioSource running;


    // Update is called once per frame
    void Update()
    {
        HandleInputs();
        Move();

    }

    void HandleInputs()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            Skill();
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack1();
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            StopAttack1();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Die();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Run();
            StopWalk();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            StopRun();
        }


        if (Input.GetKeyDown(KeyCode.W))
        {
            Walk();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Walk();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Walk();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Walk();
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            StopWalk();
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            StopWalk();
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            StopWalk();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            StopWalk();
        }

    }

    void Walk()
    {
        walking.Play();
    }

    void StopWalk()
    {
        walking.Stop();
    }

    void Run()
    {
        running.Play();
    }
    void StopRun()
    {
        running.Stop();
    }

    void Move()
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

    void Jump()
    {
        animator.SetTrigger("Jump");
    }

    void Attack1()
    {
        animator.SetBool("Attack1", true);
    }
    void StopAttack1()
    {
        animator.SetBool("Attack1", false);
    }

    void Skill()
    {
        animator.SetTrigger("Skill");
    }

    void Die()
    {
        animator.SetTrigger("Die");
    }
}
