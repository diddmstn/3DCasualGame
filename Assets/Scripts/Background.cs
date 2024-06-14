using UnityEngine;
using System;

public class Background : MonoBehaviour
{
    public float speed;
    public int startIndex;
    public int endIndex;
    public Transform[] maps;
    float viewHeight;

    private void Awake() 
    {
        viewHeight=Camera.main.orthographicSize*2;
    }

    private void Update() 
    {
        Vector3 curPos = transform.position;
        Vector3 nextPos = Vector3.down *speed*Time.deltaTime;
        transform.position =curPos +nextPos;

        if(maps[endIndex].position.y<viewHeight)
        {
            Vector3 backPos= maps[startIndex].localPosition;
            Vector3 frontPos= maps[endIndex].localPosition;
            maps[endIndex].transform.localPosition = backPos+Vector3.forward*viewHeight;

            int startIndexSave =startIndex;
            startIndex = endIndex;
            endIndex=startIndex-1==-1?maps.Length-1:startIndex-1;
        }
    }
}
