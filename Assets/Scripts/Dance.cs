using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dance : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        BeginDance();
    }
    void BeginDance()
    {
        animator.SetInteger("Animation_int", 7);
    }
}
