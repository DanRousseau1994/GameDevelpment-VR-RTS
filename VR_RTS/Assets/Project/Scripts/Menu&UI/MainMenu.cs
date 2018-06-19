using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public LevelFade fade;
    
    public void StartGame()
    {
        fade.FadeToLevel("Gameplay");
    }
}
