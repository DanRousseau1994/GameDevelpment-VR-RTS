using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject LoadScreen;
    public Slider LoadBar;
    
    public void LoadLevel(string levelToLoad)
    {
        StartCoroutine(LoadLevelAsync(levelToLoad));
    }

    private IEnumerator LoadLevelAsync(string levelToLoad)
    {
        var op = SceneManager.LoadSceneAsync(levelToLoad);

        LoadScreen.SetActive(true);
        while (!op.isDone)
        {
            var prog = Mathf.Clamp01(op.progress / 0.9f);

            LoadBar.value = prog;

            yield return null;
        }
    }
}
