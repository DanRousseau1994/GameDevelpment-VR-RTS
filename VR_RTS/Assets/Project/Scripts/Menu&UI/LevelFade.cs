﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFade : MonoBehaviour
{
    public Animator Anim;

    public void FadeToLevel(string LevelName)
    {
      // SceneManager.LoadScene(LevelName);
       Anim.SetTrigger("FadeOut"); 
    }
}