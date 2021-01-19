using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBody : MonoBehaviour
{
    [SerializeField] int snakeSize = 3;
    [SerializeField] GameObject snakeBody;
    [SerializeField] GameObject target;

    float timer = 0;
    readonly float timerMax = 0.5f;

    void Update()
    {
        if ((timer -= Time.deltaTime) <= 0)
        {
            Eat();
            SpawnBody();
            timer = timerMax;
        }
    }

    void Eat()
    {
        if (target != null && Vector3.Distance(target.transform.position, transform.position) < 0.5f)
        {
            snakeSize++;
            GetComponent<AIMove>().ClosestFood();
            Destroy(target);
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
