﻿using UnityEngine;

public class DubiousFood : MonoBehaviour
{
    LayerMask layerMask = 1 << 9;

    [SerializeField] float spawnTimer = 3f;

    bool passed = false;

    [SerializeField] GameObject EnemyAi;
    void Update()
    {
        DidPlayerPass();
        SpawnEnemySnake();
    }

    // Update is called once per frame
    void DidPlayerPass()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.up) * 20, Color.red);
        RaycastHit2D hitUp = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 20, layerMask);

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.left) * 20, Color.red);
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), 20, layerMask);


        if (hitLeft  || hitUp)
        {
            passed = true;
        }
    }

    void SpawnEnemySnake()
    {
        if (passed)
        {
            if((spawnTimer -= Time.deltaTime) <= 0)
            {
                GameObject parent = Instantiate(new GameObject("EnemySnake"), new Vector3(0,0,0), Quaternion.identity);
                GameObject enemySnake = Instantiate(EnemyAi, transform.position, Quaternion.identity);
                enemySnake.transform.parent = parent.transform;
                enemySnake.GetComponent<AIMove>().FindTargets(GameObject.Find("SnakeHead"));
                Destroy(gameObject);
            }
        }
    }
}
