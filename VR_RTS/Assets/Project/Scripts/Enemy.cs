using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _target;    
    private NavMeshAgent _agent;

    public int damageValue;


    public void Initilaze(Transform target)
    {
        _agent = gameObject.GetComponent<NavMeshAgent>();
        
        _target = target;
        
        _agent.SetDestination(_target.position);
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject != _target.gameObject) return;

        //POOL HERE
        Destroy(gameObject);
    }
}