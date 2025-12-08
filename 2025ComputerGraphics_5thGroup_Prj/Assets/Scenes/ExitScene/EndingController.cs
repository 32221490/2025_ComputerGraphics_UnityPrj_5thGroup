using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class EndingController : MonoBehaviour
{
    public float endTime = 10f;
    public string mainMenuSceneName = "MainMenu";
    public PlayableDirector director;

    public bool allowSkipWithEsc = true;
    public KeyCode skipKey = KeyCode.Escape;

    bool transitioning;

    private void Awake()
    {
        Time.timeScale = 1.0f;  
        AudioListener.pause = false;
    }

    private void OnEnable()
    {
        if (director)
        {
            director.stopped += OnCutSceneStopped;
        }
    }

    private void OnDisable()
    {
        if (director)
        {
            director.stopped -= OnCutSceneStopped;
        }
    }

    void Start()
    {
        if (director)
        {
            if (director.state != PlayState.Playing)
            {
                director.Play();
            }
        }
        else
        {
            Invoke(nameof(GoToMenu), endTime);
        }
    }

    private void Update()
    {
        if (allowSkipWithEsc && Input.GetKeyDown(skipKey))
        {
            GoToMenu();
        }
    }

    private void OnCutSceneStopped(PlayableDirector _)
    {
        GoToMenu();
    }

    public void GoToMenu()
    {
        if (transitioning)
        {
            return;
        }
        transitioning = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        SceneManager.LoadScene(mainMenuSceneName, LoadSceneMode.Single);
    }
}
