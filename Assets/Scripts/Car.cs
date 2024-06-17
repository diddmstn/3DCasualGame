using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
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
}
