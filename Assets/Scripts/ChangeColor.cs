using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeColor : MonoBehaviour
{

    public void Red()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    public void Blue()
    {
        GetComponent<Renderer>().material.color = Color.blue;
    }

    public void Black()
    {
        GetComponent<Renderer>().material.color = Color.black;
    }

    public void Green()
    {
        GetComponent<Renderer>().material.color = Color.green;
    }

    public void Die()
    {
        GetComponent<Renderer>().enabled = false;
        CarEngine.score += 500;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("scene");
    }
}
