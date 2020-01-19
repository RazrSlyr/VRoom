using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeText : MonoBehaviour
{

    public TextMesh text;
   

    public void StartGame()
    {
        SceneManager.LoadScene("sample", LoadSceneMode.Single);
    }

    public void GoText()
    {
        text = GetComponent<TextMesh>();
        text.text = "Go!";
    }

    public void ReadyText()
    {
        text = GetComponent<TextMesh>();
        text.text = "Ready?";
    }
}
