using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject EndMenu;
    public GameObject ObjectiveMenu;

    public static bool GamePause = false;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GamePause)
            {
                resume();
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                pause();
                Cursor.lockState = CursorLockMode.None;
            }
        }
        else if (Input.GetKeyDown("m"))
        {
            if (GamePause)
            {
                removeobjective();
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                objective();
                Cursor.lockState= CursorLockMode.None;
            }
        }
    }
    public void objective()
    {
        ObjectiveMenu.SetActive(true);
        Time.timeScale = 0f;
        GamePause = true;
    }
    public void removeobjective()
    {
        ObjectiveMenu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        GamePause = false;
    }
    public void pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale=0f;
        GamePause=true;
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
    public void resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale=1f;
        Cursor.lockState= CursorLockMode.Locked;
        GamePause=false;
    }
}
