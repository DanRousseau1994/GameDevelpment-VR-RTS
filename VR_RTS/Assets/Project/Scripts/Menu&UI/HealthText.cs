using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{
    [SerializeField] private Text _healthText;

    public void UpdateText()
    {
        _healthText.text = Player.PlayerInstance.Health.ToString();
    }
}