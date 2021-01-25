using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetText : MonoBehaviour
{
    [SerializeField] Text username;
    [SerializeField] Text time;
    void Start()
    {
        username.text = GameManager.Instance.username;
        time.text = GameManager.Instance.time.ToString("00.00");
    }
}
