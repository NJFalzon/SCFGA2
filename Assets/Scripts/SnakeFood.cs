using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeFood : MonoBehaviour
{
    [SerializeField] GameObject pellets;
    [SerializeField] int size;
    void Start()
    {
        SpawnFood();
    }

    
    void SpawnFood()
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Vector3 location = new Vector3((-15.5f + (i * 8)), (16.5f - (j * 8)), 0);
                if (Physics2D.OverlapCircleAll(location, 1f).Length == 0) 
                {
                    Instantiate(pellets, location, new Quaternion(0, 0, 0.382683426f, 0.923879564f));
                }
            }
        }
    }
}
