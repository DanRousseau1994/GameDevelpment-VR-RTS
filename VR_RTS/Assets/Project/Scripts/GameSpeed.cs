using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeed : MonoBehaviour
{
    private int SpeedInt;

    public enum GameSpeedSettings
    {
        Fast,
        Normal,
        Slow
    }

    [SerializeField] private GameSpeedSettings _currentGameSpeed;

    public void SetSpeed(int speedToSet)
    {
        if (speedToSet == 0)
        {
            _currentGameSpeed = GameSpeedSettings.Slow;
        }

        if (speedToSet == 1)
        {
            _currentGameSpeed = GameSpeedSettings.Normal;
        }

        if (speedToSet == 2)
        {
            _currentGameSpeed = GameSpeedSettings.Fast;
        }
    }

    public void Update()
    {
        if (_currentGameSpeed == GameSpeedSettings.Fast)
        {
            Time.timeScale = 1.2f;
        }

        if (_currentGameSpeed == GameSpeedSettings.Normal)
        {
            Time.timeScale = 1f;
        }

        if (_currentGameSpeed == GameSpeedSettings.Slow)
        {
            Time.timeScale = 0.5f;
        }
    }
}