using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    List<Vector3> trailList;
    Vector3 trailPosition;


    void Move()
    {
        if (transform.parent.GetChild(0).GetComponent<PlayerMove>())
        {
            trailList = transform.parent.GetChild(0).GetComponent<PlayerMove>().positions;
        }
        else
        {
            trailList = transform.parent.GetChild(0).GetComponent<AIMove>().GetPath();
        }


        if((trailList.Count - transform.GetSiblingIndex() + 1) <= 1)
        {
            trailPosition = new Vector3(100, 100, 0);
        }
        else
        {
            trailPosition = trailList[trailList.Count - (transform.GetSiblingIndex() + 1)];
        }

        transform.position = trailPosition;
    }

    private void Update()
    {
        Move();
    }
}
