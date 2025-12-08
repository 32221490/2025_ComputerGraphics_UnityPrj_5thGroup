using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject menuRoot;
    public Button continueButton;
    public Button quitButton;

    public string mainMenuSceneName = "MainMenu";
    public bool showCursorWhilePaused = true;

    public static bool IsPaused {
        get;
        private set;
    }

    private void Awake()
    {
        if (menuRoot)
        {
            menuRoot.SetActive(false);
        }

        if (continueButton)
        {
            continueButton.onClick.AddListener(Resume);
        }

        if (quitButton)
        {
            quitButton.onClick.AddListener(QuitToMainMenu);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        if (IsPaused)
        {
            return;
        }
        IsPaused = true;

        Time.timeScale = 0f;
        AudioListener.pause = true;

        if (menuRoot) { 
            menuRoot.SetActive (true);
        }

        if (continueButton && EventSystem.current)
        {
            EventSystem.current.SetSelectedGameObject(continueButton.gameObject);
        }

        if (showCursorWhilePaused)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void Resume()
    {
        if (!IsPaused)
        {
            return;
        }
        IsPaused = false;

        Time.timeScale = 1f;
        AudioListener.pause = false;

        if (menuRoot)
        {
            menuRoot.SetActive(false);
        }
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false ;

        if (!string.IsNullOrEmpty(mainMenuSceneName))
        {
            SceneManager.LoadScene(mainMenuSceneName);
        }
        else
        {
            Debug.LogWarning("[PauseMenu] mainMenuSceneName is Empty.");
        }
    }

    private void OnDisable()
    {
        if (IsPaused)
        {
            Time.timeScale = 1f;
            AudioListener.pause = false;
            IsPaused = false;
        }
    }
}
