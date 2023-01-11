using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health = 20;

    private GameObject _character;
    private NavMeshAgent _aiAgent;

    public void TakeDamege(int amount)
    {
        _health -= amount;

        if (_health <= 0)
            Destroy(gameObject);
    }

    public void SetTarget(GameObject target) => _character = target;

    private void Start() => _aiAgent = GetComponent<NavMeshAgent>();

    private void FixedUpdate() => _aiAgent.SetDestination(_character.transform.position);
}
