using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneManager : MonoBehaviour
{
    private static ChangeSceneManager instance;
    private void Start()
    {
        initSingletionInstance();
    }

    void initSingletionInstance()
    {
        if (instance == null) // This is first object, set the static reference
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            return;
        }
        Destroy(this.gameObject);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
