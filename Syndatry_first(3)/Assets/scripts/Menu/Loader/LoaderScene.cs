using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoaderScene : MonoBehaviour
{
    private bool loadScene = false;
    public string sceneName;
    private TextMeshProUGUI loadingText;

    void Start()
    {
        loadingText = FindObjectOfType<TextMeshProUGUI>();
    }

    void Update()
    {
        if (!loadScene) {
            loadScene = true;

            StartCoroutine(AsyncLoader());
        }

        if (loadScene) {
            loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));
        }
    }

    private IEnumerator AsyncLoader() {

        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        while (!async.isDone) {
            yield return null;
        }

        Debug.Log("Loader completed callback");
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    }
}
