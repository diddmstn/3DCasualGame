using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnPoint : MonoBehaviour
{
    public float respawnDelay;
    public float percent;
    public float rotationY;

    void Start()
    {
        percent /=100f;
        StartCoroutine(Respawn(percent));
    }

    IEnumerator Respawn(float _percent)
    {
        if(percent>=Random.Range(0f,1f))
        {
            SpawnObject();
        }

        yield return new WaitForSeconds(respawnDelay);
        StartCoroutine(Respawn(percent));
    }

    void SpawnObject()
    {
        GameObject obj = GameManager.instance.objectPool.SpawnFromPool("Cars");
        obj.transform.position = this.transform.position;
        obj.transform.rotation = Quaternion.Euler(0,rotationY,0);

    }

    
}
