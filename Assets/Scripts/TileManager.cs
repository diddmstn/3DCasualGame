using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float spawn=0;
    public float tileLength=30;
    public float numberOfTiles=5f;
    private List<GameObject> actuveTiles= new List<GameObject>();

    public Transform playerTransform;
    
    private void Start() 
    {
        for(int i=0; i<numberOfTiles; i++)
        {
            if(i==0)
            SpawnTile(0);
            else
            SpawnTile(Random.Range(0,tilePrefabs.Length));
        }
    }

    private void Update() 
    {
        if(playerTransform.position.z -35>spawn-(numberOfTiles*tileLength))
        {
            SpawnTile(Random.Range(0,tilePrefabs.Length));
            DeleteTile();
        }
    }

    public void SpawnTile(int tileIndex)
    {
        GameObject go = Instantiate(tilePrefabs[tileIndex], transform.forward*spawn ,transform.rotation);
        actuveTiles.Add(go);
        spawn+=tileLength;
    }

    private void DeleteTile()
    {
        Destroy(actuveTiles[0]);
        actuveTiles.RemoveAt(0);
    }
}
