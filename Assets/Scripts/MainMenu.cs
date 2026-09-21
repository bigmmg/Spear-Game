using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Toggle easy;
    public Toggle medium;
    public Toggle hard;

    public Toggle red;
    public Toggle blue;
    public Toggle yellow;
    public Toggle green;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        if (easy != null && easy.isOn)
        {
            PlayerPrefs.SetInt("SelectedDifficulty", 0);
        }

        else if (medium != null && medium.isOn)
        {
            PlayerPrefs.SetInt("SelectedDifficulty", 1);
        }

        else if (hard != null && hard.isOn)
        {
            PlayerPrefs.SetInt("SelectedDifficulty", 2);
        }

        if (red != null && red.isOn) PlayerPrefs.SetInt("ShieldColor", 0);
        else if (green != null && green.isOn) PlayerPrefs.SetInt("ShieldColor", 1);
        else if (yellow != null && yellow.isOn) PlayerPrefs.SetInt("ShieldColor", 2);
        else if (blue != null && blue.isOn) PlayerPrefs.SetInt("ShieldColor", 3);

        PlayerPrefs.Save();

        Time.timeScale = 1f;

        SceneManager.LoadScene("MainGame");
    }
}
