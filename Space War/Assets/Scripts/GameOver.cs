using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;

    [SerializeField] private AudioClip gameOverSound;
    

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            gameOverPanel.SetActive(true);
            SoundManager.instance.PlaySound(gameOverSound);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
