using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;

    public void playbutton()
    {
        SceneManager.LoadScene("Zombie");
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
        
    }
}
