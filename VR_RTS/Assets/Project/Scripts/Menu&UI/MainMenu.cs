using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void ViewControls()
    {
        //Display control map here.
    }
}
