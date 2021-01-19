using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crash : MonoBehaviour
{
    [SerializeField] GameObject enemySnakeBody;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Dead")
        {
            print("HEllo");
            SceneManager.LoadScene("Level2");
        }
    }
}
