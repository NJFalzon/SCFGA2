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
            SpawnBody();
            GoToEnd();
            timer = timerMax;
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.transform.tag == "Target")
        {
            snakeSize++;
            GetComponent<AIMove>().ClosestFood();
            Destroy(target.gameObject);
        }
    }

    void SpawnBody()
    {
        if(transform.parent.childCount < snakeSize)
        {
            Instantiate(snakeBody).transform.parent = transform.parent;
        }
    }

    void GoToEnd()
    {
        if(snakeSize == 6)
        {
            GetComponent<AIMove>().FindTargets(GameObject.Find("EndTarget"));
        }
    }

    public void setTarget(GameObject target)
    {
        this.target = target;
    }
}
