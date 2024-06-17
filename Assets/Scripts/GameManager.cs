using UnityEngine;


public class GameManager:MonoBehaviour
{
    public static GameManager instance;
    public ObjectPool objectPool{get; private set;}

    private void Awake() 
    {
        instance = this;
        objectPool= GetComponent<ObjectPool>();
    }
}