using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PutScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Text text = gameObject.GetComponent<Text>();
        if(!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", CarEngine.score);
        } else if(PlayerPrefs.GetInt("HighScore") < CarEngine.score)
        {
            PlayerPrefs.SetInt("HighScore", CarEngine.score);
        }
        text.text = "Congratulations!\nYou scored " + CarEngine.score + " points!\n The high score is\n" + PlayerPrefs.GetInt("HighScore") + " points!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
