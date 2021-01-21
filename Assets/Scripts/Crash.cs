using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crash : MonoBehaviour
{
    [SerializeField] string thisLevel;
    private void Start()
    {
        tag = transform.tag;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Dead" )
        {
            if (transform.tag == "Dead")
            {
                Destroy(transform.parent.gameObject);
            }
            else
            {
                SceneManager.LoadScene(thisLevel);
            }
        }

        if (collision.transform.tag == "Target")
        {
            if (transform.tag == "Dead")
            {
                GetComponent<AIBody>().snakeSize++;
                GetComponent<AIMove>().ClosestFood();
                Destroy(collision.gameObject);
            }
            else
            {
                GetComponent<PlayerMove>().snakeSize++;
            }
            Destroy(collision.gameObject);
        }
    }
}
