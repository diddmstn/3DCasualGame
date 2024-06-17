using System;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    Animator animator;
    private int IsWalking= Animator.StringToHash("jump");

    private void Awake() 
    {
        animator = GetComponentInChildren<Animator>();
    }
    private void Start() 
    {
        CharacterManager.Instance.Player.OnMoveEvent += Move;
    }

    private void Move()
    {
        animator.SetBool(IsWalking,true);
    }

}