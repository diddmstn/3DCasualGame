using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public PlayerController controller;
    public Action OnMoveEvent;

    private void Awake()
    {
        CharacterManager.Instance.Player=this;
        controller= GetComponent<PlayerController>();
    }
}
