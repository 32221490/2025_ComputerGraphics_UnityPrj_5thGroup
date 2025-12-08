using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverWatcher : MonoBehaviour
{
    public TriggerGameOver trigger;

    public string deadSceneName = "DeadScene";
    public float loadDelay = 1.5f;

    public UnityEngine.UI.Image overlay;

    bool loading;

    private void Awake()
    {
        if (!trigger)
        {
            trigger = GetComponent<TriggerGameOver>();
        }

        if (overlay != null)
        {
            var c = overlay.color;
            c.a = 0f;
            overlay.color = c;
            overlay.raycastTarget = false;
            overlay.enabled = true;
        }

        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
        AudioListener.pause = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        ;        
    }

    // Update is called once per frame
    void Update()
    {
        if (loading || trigger == null)
        {
            return;
        }
        
        if (trigger.hasTriggered)
        {
            StartCoroutine(LoadDeadScene());
        }
    }

    IEnumerator LoadDeadScene()
    {
        loading = true;

        if (overlay)
        {
            var c = overlay.color;
            c.a = 1f;
            overlay.color = c;
        }

        if (loadDelay > 0f)
        {
            yield return new WaitForSeconds(loadDelay);
        }

        SceneManager.LoadScene(deadSceneName, LoadSceneMode.Single);
    }
}
