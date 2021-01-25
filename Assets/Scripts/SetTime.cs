using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTime : MonoBehaviour
{
    void Update()
    {
        GetComponent<Text>().text = "Time: " + GameManager.Instance.time.ToString("00.00");
    }
}
