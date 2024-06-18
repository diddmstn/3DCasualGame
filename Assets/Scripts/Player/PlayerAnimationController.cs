using System;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    Animator animator;
    private int IsWalking= Animator.StringToHash("Walk");

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
        Invoke("MoveEnd",0.45f);
    }

    private void MoveEnd()
    {
        animator.SetBool(IsWalking,false);

    }
   

}