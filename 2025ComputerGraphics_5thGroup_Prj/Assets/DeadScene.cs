using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeadScene : MonoBehaviour
{
    public Button retryButton;
    public Button quitButton;

    public string mapScene = "map";
    public string mianMenuScene = "MainMenu";

    private void Awake()
    {
        Time.timeScale = 1.0f;
        AudioListener.pause = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if (retryButton)
        {
            retryButton.onClick.AddListener(onClickRetry);
        }

        if (quitButton)
        {
            quitButton.onClick.AddListener(onClickQuit);
        }
    }

    public void onClickRetry()
    {
        SceneManager.LoadScene(mapScene, LoadSceneMode.Single);
    }

    public void onClickQuit()
    {
        SceneManager.LoadScene(mianMenuScene, LoadSceneMode.Single);
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
