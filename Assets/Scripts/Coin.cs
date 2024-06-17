using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    public override void  ItemEffect()
    {
        GameManager.instance.IncreaseCoin();
        Destroy(gameObject);
    }
}
