using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Covered : MonoBehaviour
{

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.GetContact(0).normal.y <= -0.9)
            {
                animator.SetTrigger("Golpe");
                other.gameObject.GetComponent<MovePlayer>().Rebote();
            }
        }
    }


}
