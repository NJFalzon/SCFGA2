using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanning : MonoBehaviour
{
    float timer = 0;
    readonly float maxTimer = 0.1f;
    
    void Update()
    {
        if ((timer -= Time.deltaTime) <= 0)
        {
            GameObject.Find("PathFindingGrid").GetComponent<AstarPath>().Scan();
            timer = maxTimer;
        }
    }
}
