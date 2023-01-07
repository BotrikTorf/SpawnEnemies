using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health = 20;

    private NavMeshAgent _aiAgent;
    private GameObject _character;

    public void TakeDamege(int amount)
    {
        _health -= amount;

        if (_health <= 0)
            Destroy(gameObject);
    }

    private void Start()
    {
        _aiAgent = gameObject.GetComponent<NavMeshAgent>();
        _character = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate() => _aiAgent.SetDestination(_character.transform.position);
}
