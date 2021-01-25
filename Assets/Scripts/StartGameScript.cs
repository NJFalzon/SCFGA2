using UnityEngine;
using UnityEngine.UI;

public class StartGameScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void UserName()
    {
        string name = GetComponentInChildren<InputField>().text;
        GameObject.Find("GameManager").GetComponent<GameManager>().SetUsername(name);

        if (name.Length < 3 || name.Length >= 10)
        {
            GetComponentInChildren<Button>().interactable = false;
        }
        else
        {
            GetComponentInChildren<Button>().interactable = true;
        }
    }
}
