using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScene : MonoBehaviour
{
    private CanvasGroup fadeGroup;
    private float fadeSpeed = 0.6f;
    // Start is called before the first frame update
    void Start()
    {
        fadeGroup = FindObjectOfType<CanvasGroup>();
        fadeGroup.alpha = 1;
    }

    // Update is called once per frame
    void Update()
    {
        fadeGroup.alpha = 1 - Time.timeSinceLevelLoad * fadeSpeed;
    }

    public void OnPlayClick() {
        Debug.Log("PlayButton callback");
        SceneManager.LoadScene("Demo");
    }

    public void OnSettingsClick() {
        Debug.Log("SettingsButton callback");
    }
}
