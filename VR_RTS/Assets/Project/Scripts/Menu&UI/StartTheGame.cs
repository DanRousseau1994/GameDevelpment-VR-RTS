using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTheGame : MonoBehaviour
{
    public LevelLoader LoadLevel;

    private void Awake()
    {
        LoadLevel.LoadLevel("Menu");
    }
}
