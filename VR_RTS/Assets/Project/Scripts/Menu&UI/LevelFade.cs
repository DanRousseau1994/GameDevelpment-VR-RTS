using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFade : MonoBehaviour
{
    public Animator Anim;

    public void FadeToLevel()
    {
       Anim.SetTrigger("FadeOut"); 
    }
}