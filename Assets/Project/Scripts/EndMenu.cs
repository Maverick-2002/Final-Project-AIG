using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public GameObject EndM;
    public void restart()
    {
        SceneManager.LoadScene(1);
    }
    public void loadmenu()
    {
        SceneManager.LoadScene(0);
    }

    public void quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
