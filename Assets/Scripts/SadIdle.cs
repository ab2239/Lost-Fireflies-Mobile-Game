using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SadIdle : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        SadAnim();
    }
    void SadAnim()
    {
        animator.SetInteger("Animation_int", 8);
    }
}
