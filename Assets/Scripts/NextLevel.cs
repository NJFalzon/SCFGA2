using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] Color active;
    [SerializeField] Color disabled;

    [SerializeField] string nextLevel;

    void Start()
    {
        GetComponent<SpriteRenderer>().color = disabled;
    }

    public void TurnOn()
    {
        GetComponent<SpriteRenderer>().color = active;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(GetComponent<SpriteRenderer>().color == active)
        {
            SceneManager.LoadScene(nextLevel);
        }
    }
}
