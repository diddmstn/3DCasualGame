using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ICollidable
{
    public void OnCollide();
}

public class Car : MonoBehaviour, ICollidable
{
    Rigidbody rb;
    public float speed;
    private void Awake() 
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() 
    {
        rb.velocity=transform.forward*speed;
        
    }
    private void OnTriggerEnter(Collider other) 
    {
        this.gameObject.SetActive(false);
    }

    public void OnCollide()
    {
        //게임매니저에서 게임오버 가져오기
        GameManager.instance.GameOver();
    }
}
