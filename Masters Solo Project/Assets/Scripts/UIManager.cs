using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private bool isPaused = false;

    [SerializeField] private GameObject hudcanvas = null;
    [SerializeField] private GameObject endcanvas = null;
    [SerializeField] private GameObject pausecanvas = null;

    //private MouseLook mouse = null;
    //private PlayerStats stats = null;

    private void Start()
    {
        SetActiveHud(true);

        //mouse.GetComponent<MouseLook>();
        //stats.GetComponent<PlayerStats>();

    }

    private void Update()
    {
        //shows pause menu on escape
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            SetActivePause(true);
            Cursor.lockState = CursorLockMode.None;
        }
            
        //closes pause menu on escpe again
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            SetActivePause(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
            
    }

    //sets default HUD at start
    public void SetActiveHud(bool state)
    {
        hudcanvas.SetActive(state);
        endcanvas.SetActive(!state);
        pausecanvas.SetActive(!state);
    }

    //sets visability of pause 
    public void SetActivePause(bool state)
    {
        pausecanvas.SetActive(state);
        hudcanvas.SetActive(!state);


        Time.timeScale = state ? 0 : 1;
        isPaused = state;

        //if (state)
        //    mouse.UnlockCursor();
        //else
        //    mouse.LockCursor();
        //isPaused = state;

    }

    //sets end canvas visable
    public void SetActiveEnd(bool state)
    {
        endcanvas.SetActive(state);
    }

    //quits game
    public void Quit()
    {
        Application.Quit();
    }

    //reloads scene
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    //goes back to main menu
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
