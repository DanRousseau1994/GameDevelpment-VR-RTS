using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    private int SpeedInt;

    [SerializeField] private AudioMixer MusicMixer;
    [SerializeField] private AudioMixer SFXMixer;

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

    public void SetMusicVolume(float volume)
    {
        MusicMixer.SetFloat("Vol", volume);
    }

    public void SetSFXVolume(float volume)
    {
        SFXMixer.SetFloat("Vol", volume);
    }

    public void Update()
    {
        TrackGameSpeed();
    }

    private void TrackGameSpeed()
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
