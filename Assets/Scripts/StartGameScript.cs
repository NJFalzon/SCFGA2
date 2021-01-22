using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void UserName()
    {
        string name = GetComponentInChildren<InputField>().text;
        GameObject.Find("GameManager").GetComponent<GameManager>().SetUsername(name);

        if (name.Length < 3)
        {
            GetComponentInChildren<Button>().interactable = false;
        }
        else
        {
            GetComponentInChildren<Button>().interactable = true;
        }
    }
}
