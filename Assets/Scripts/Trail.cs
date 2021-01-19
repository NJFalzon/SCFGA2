using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    List<Vector3> trailList;
    Vector3 trailPosition;


    void Move()
    {
        trailList = transform.parent.GetChild(0).GetComponent<AIMove>().GetPath();
        trailPosition = trailList[trailList.Count - (transform.GetSiblingIndex() + 1)];
        transform.position = trailPosition;
    }

    private void Update()
    {
        Move();
    }
}
