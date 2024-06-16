using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnObjectManager : MonoBehaviour
{
    public List<GameObject> respawnObj = new List<GameObject>();
    int obstacleCount;
    int childNum;
    
    void Start()
    {
        childNum= transform.childCount;

        for(int i=0; i<childNum; i++)
        {
            SpawnObject(Random.Range(0,respawnObj.Count),transform.GetChild(i).transform);
        }
        //1. 각자의 위치(자식들의 위치에 따라) 리스트에 넣은 프리팹이 생성된다.
        //2. 스폰되는 프리팹은 나무, 코인, 또는 빈칸임
        //3. 나무가 설정한 스폰칸(자식들 수)-1보다 많이 생성되는 일은 없어야한다.
    }

    void SpawnObject(int random,Transform childTransform)
    {
        if(respawnObj[random]!=null)
        {
            if(respawnObj[random].CompareTag("Obstacle")&&obstacleCount<childNum)
            {
                obstacleCount++;
            }
            else if(respawnObj[random].CompareTag("Obstacle")&&obstacleCount>=childNum)
            return;
            
            Instantiate(respawnObj[random], childTransform);
        }
    }

    
}
