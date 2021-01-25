using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveScore : MonoBehaviour
{
    int count = 0;
    List<Data> data;
    void Start()
    {
        data = new List<Data>();

        while (PlayerPrefs.HasKey("Username" + count))
        {
            data.Add(new Data(PlayerPrefs.GetString("Username" + count), PlayerPrefs.GetFloat("Time" + count)));
            count++;
        }

        PlayerPrefs.SetString("Username"+count, GameManager.Instance.username);
        PlayerPrefs.SetFloat("Time"+count, GameManager.Instance.time);
        PlayerPrefs.Save();

        data.Add(new Data(GameManager.Instance.username, GameManager.Instance.time));

        transform.GetChild(1).GetComponent<Text>().text = GameManager.Instance.username;
        transform.GetChild(2).GetComponent<Text>().text = GameManager.Instance.time.ToString("00.00");
        
        data.Sort((p1, p2)=>p1.time.CompareTo(p2.time));

        for (int i = 0; i < 3; i++)
        {
            if (data[i] != null)
            {
                transform.GetChild(4).GetChild(i).gameObject.SetActive(true);
                transform.GetChild(4).GetChild(i).GetComponent<Text>().text = data[i].name + ": " + data[i].time.ToString("00.00");
            }
        }
    }
}

public class Data
{
    public string name;
    public float time;

    public Data()
    {
        name = "";
        time = 0;
    }

    public Data(string name, float time)
    {
        this.name = name;
        this.time = time;
    }
}
