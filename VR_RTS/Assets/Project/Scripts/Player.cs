using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private UnityEvent _damageTaken;

    public static Player PlayerInstance;


    public int Health
    {
        get { return _health; }
    }

    private void OnCollisionEnter(Collision other)
    {
        PlayerInstance = this;
        
        var damageToTake = other.gameObject.GetComponent<Enemy>().damageValue;
        
        TakeDamage(damageToTake);
    }

    private void TakeDamage(int damageAmount)
    {
        _health -= damageAmount;
        
        _damageTaken.Invoke();

        if (_health <= 0)
            Destroy(gameObject);
    }
}