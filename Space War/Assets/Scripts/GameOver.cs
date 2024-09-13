using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameOver : MonoBehaviour
{
    [Header ("GAme Over")]
    public GameObject gameOverPanel;

    [SerializeField] private AudioClip gameOverSound;

    [Header("Pause")]
    [SerializeField] private GameObject pausePanel;

    private void Awake()
    {
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
    }

    

    #region Game Over
    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            gameOverPanel.SetActive(true);
            SoundManager.instance.PlaySound(gameOverSound);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // If pause scree already activr unpause and viceversa
            if (pausePanel.activeInHierarchy)
                PauseGame(false);
            else PauseGame(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit(); //Quits the game (Only works on build)

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;// Exits play mode (will only be executed inside unity)
        #endif 
    }
    #endregion

    #region Pause
    public void PauseGame(bool status)
    {
        // If Status == true pause | if status == false unpause
        pausePanel.SetActive(status);

        //When pause status is true change timescale to 0 (time stops)
        // When it's false change it back to 1 ( time goes by normally)
        if (status)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void SoundVolume()
    {
        SoundManager.instance.ChangeSoundVolume(0.2f);
    }

    public void MusicVolume()
    {
        SoundManager.instance.ChangeMusicVolume(0.2f);
    }
    #endregion
}
