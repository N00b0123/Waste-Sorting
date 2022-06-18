using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoHide : MonoBehaviour
{

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Hide()
    {
        animator.SetBool("animateLigth", false);
        gameObject.SetActive(false);
    }
}
