using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CutSceneToMap : MonoBehaviour
{
    public PlayableDirector director;
    public string nextSceneName = "map";

    public KeyCode skipKey = KeyCode.Escape;
    bool loading;

    private void Awake()
    {
        if (director)
        {
            director.stopped += OnCutsceneStopped;
        }
        else
        {
            Debug.LogWarning("[CutSceneToMap] CAN NOT FIND PlayableDirector");
            LoadNext();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (director && director.state != PlayState.Playing)
        {
            director.Play();
        }
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(skipKey))
        {
            LoadNext();
        }
    }

    private void OnDestroy()
    {
        if (director)
        {
            director.stopped -= OnCutsceneStopped;
        }
    }

    void OnCutsceneStopped(PlayableDirector _)
    {
        LoadNext();
    }

    void LoadNext()
    {
        if (loading) 
        {
            return;
        }
        loading = true;
        SceneManager.LoadScene(nextSceneName, LoadSceneMode.Single);
    }
}
