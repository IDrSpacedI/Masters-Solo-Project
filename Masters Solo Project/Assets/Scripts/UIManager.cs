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
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
            SetActivePause(true);
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
            SetActivePause(false);
    }

    public void SetActiveHud(bool state)
    {
        hudcanvas.SetActive(state);
        endcanvas.SetActive(!state);
        pausecanvas.SetActive(!state);

    }

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

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
