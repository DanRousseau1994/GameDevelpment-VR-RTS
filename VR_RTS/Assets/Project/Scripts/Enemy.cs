using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _target;    
    private NavMeshAgent _agent;

    public int damageValue;

    [SerializeField] private UnityEvent DeathEvent;


    public void Initilaze(Transform target)
    {
        _agent = gameObject.GetComponent<NavMeshAgent>();
        
        _target = target;
        
        _agent.SetDestination(_target.position);
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject != _target.gameObject) return;

        DeathEvent.Invoke();
    }


    public void HandleDeath()
    {
        PlacementController.PlacementControllerInstance.avaliableMoney += 75;
    }
        
}