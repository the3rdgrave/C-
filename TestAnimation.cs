﻿using UnityEngine;
using System.Collections;

public class TestAnimation : MonoBehaviour
{

    Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("moveSpeed", 8f);
    }
}
