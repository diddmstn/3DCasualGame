using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour,ICollidable
{
    public void OnCollide()
    {
        ItemEffect();
    }

    public virtual void ItemEffect()
    {
        
    }
}