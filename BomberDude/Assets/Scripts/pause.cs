using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject pauseMenuPrefab;
    public string backgroundMusicObjectName = "Bgm";
    public AudioSource backgroundMusic; 
    private bool isGamePaused = false;
    private float previousTimeScale = 1f;

    void Start()
    {
        if (pauseMenuPrefab != null)
        {
            pauseMenuUI = Instantiate(pauseMenuPrefab); 

            
            Camera mainCamera = Camera.main;
            if (mainCamera != null && pauseMenuUI != null)
            {
                Canvas canvas = pauseMenuUI.GetComponent<Canvas>();
                if (canvas != null)
                {
                    canvas.worldCamera = mainCamera;
                }
            }

            pauseMenuUI.SetActive(false);
        }
         GameObject bgmObject = GameObject.Find(backgroundMusicObjectName);
        if (bgmObject != null)
        {
            backgroundMusic = bgmObject.GetComponent<AudioSource>();
        }
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            TogglePauseMenu();
        }
    }

    public void OnPause(){
        TogglePauseMenu();
    }

    void TogglePauseMenu()
    {
        if (pauseMenuUI != null)
        {
            isGamePaused = !isGamePaused;
            pauseMenuUI.SetActive(isGamePaused);

            if (isGamePaused)
            {
                previousTimeScale = Time.timeScale;
                Time.timeScale = 0f;

                if (backgroundMusic != null && backgroundMusic.isPlaying)
                {
                    backgroundMusic.Pause();
                }
            }
            else
            {
                Time.timeScale = previousTimeScale;

                if (backgroundMusic != null && !backgroundMusic.isPlaying)
                {
                    backgroundMusic.UnPause();
                }
            }
        }
    }

    
    public void ResumeGame()
    {
        if (pauseMenuUI != null)
        {
            isGamePaused = false;
            pauseMenuUI.SetActive(false);
            Time.timeScale = previousTimeScale;

            if (backgroundMusic != null && !backgroundMusic.isPlaying)
            {
                backgroundMusic.UnPause();
            }
        }
    }

    
}
