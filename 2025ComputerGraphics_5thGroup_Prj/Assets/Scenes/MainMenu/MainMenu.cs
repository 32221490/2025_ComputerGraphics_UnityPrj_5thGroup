using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string openingSceneName = "Cinemachine";
    public Button startButton;
    public Button quitButton;

    public void OnClickStart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(openingSceneName, LoadSceneMode.Single);
    }

    public void OnClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }

    public void Awake()
    {
        if (startButton)
        {
            startButton.onClick.AddListener(OnClickStart);
        }

        if (quitButton)
        {
            quitButton.onClick.AddListener(OnClickQuit);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
