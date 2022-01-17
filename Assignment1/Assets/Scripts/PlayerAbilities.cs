using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public bool[] mAttackButtons = new bool[3];
    public Animator characterAnimator;
    // Start is called before the first frame update

    void Start()
    {

    }

    public void Move()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire1"))
        {
            mAttackButtons[0] = true;
            mAttackButtons[1] = false;
            mAttackButtons[2] = false;
            characterAnimator.SetBool("Attack1", true);
        }
        else
        {
            mAttackButtons[0] = false;
            characterAnimator.SetBool("Attack1", false);
        }

        if (Input.GetButton("Fire2"))
        {
            mAttackButtons[0] = false;
            mAttackButtons[1] = true;
            mAttackButtons[2] = false;
            characterAnimator.SetBool("Attack2", true);
        }
        else
        {
            mAttackButtons[1] = false;
            characterAnimator.SetBool("Attack2", false);
        }

        if (Input.GetButton("Fire3"))
        {
            mAttackButtons[0] = false;
            mAttackButtons[1] = false;
            mAttackButtons[2] = true;
            characterAnimator.SetBool("Attack3", true);
        }
        else
        {
            mAttackButtons[2] = false;
            characterAnimator.SetBool("Attack3", false);
        }

    }
}
