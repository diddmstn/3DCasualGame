using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float speed;
    Vector3 direction;
    public Transform player;
    void Start ()
    {
        direction=new Vector3(0,0,speed);
    }

    private void FixedUpdate() 
    {
        if(Time.timeScale!=0)
        transform.position +=direction;

        //2.7
        if(transform.position.z-player.position.z>2.7)
        {
            GameManager.instance.GameOver();
        }
    }
  
}
