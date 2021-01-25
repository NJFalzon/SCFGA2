using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBody : MonoBehaviour
{
    public int snakeSize = 3;
    [SerializeField] GameObject snakeBody;
    [SerializeField] GameObject target;

    float timer = 0;
    readonly float timerMax = 0.2f;

    void Update()
    {
        if ((timer -= Time.deltaTime) <= 0)
        {
            SpawnBody();
            timer = timerMax;
        }
    }

    void SpawnBody()
    {
        if(transform.parent.childCount < snakeSize)
        {
            Instantiate(snakeBody).transform.parent = transform.parent;
        }
    }

    public void setTarget(GameObject target)
    {
        this.target = target;
    }
}
