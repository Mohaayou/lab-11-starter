using UnityEngine;

public class PauseManager: MonoBehaviour 
{
    public GameObject pauseScreen;
    public GameObject player;

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (pauseScreen.activeSelf)
            {
                // We're paused, so unpause
                UnPause();
            }   
            else
            {
                // We're unpaused, so pause
                Pause();
            }
        }
    }
    public void Pause()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void UnPause()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Save()
    {
        PlayerPrefs.SetInt("Score", PlayerMovement)
    }

    public void Load()
    {
    }
}
