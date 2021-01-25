using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public string username;
    public float time;

    public int snakesize = 3;

    private bool started = false;

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
        if (started)
        {
            time += Time.deltaTime;
        }
    }

    public void Started(bool start)
    {
        started = start;
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

    public void Restart()
    {
        username = "";
        time = 0;
        SceneManager.LoadScene("StartLevel");
    }
}
