using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Awaake is called before start
    /// </summary>
    private void Awake()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

    }
    /// <summary>
    /// Load the first screen
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    /// <summary>
    /// Quits the game to the desktop
    /// </summary>
    public void QuittoDesktop()
    {
        Application.Quit();
    }
}
