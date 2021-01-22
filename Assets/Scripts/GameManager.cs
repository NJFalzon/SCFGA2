using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private string username;
    [SerializeField] private float time;

    private bool started = false;
    private bool ended = false;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        Timer();
    }


    void Timer()
    {
        if (started && !ended)
        {
            time += Time.deltaTime;
        }
    }



    public void SetUsername(string username)
    {
        this.username = username;
    }

    public string GetUsername()
    {
        return username;
    }

    public void StartTimer()
    {
        started = true;
        SceneManager.LoadScene("Level1");
    }

    public float GetTime()
    {
        return time;
    }
}
