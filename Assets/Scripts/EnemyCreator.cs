using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] float _creationPeriod = 3f;
    [SerializeField] float _radius = 48;

    private float _timer;

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _creationPeriod) 
        {
            _timer = 0;

            Vector2 randomCircle = Random.insideUnitCircle * _radius;
            Vector3 position = new Vector3(randomCircle.x, 0.8f, randomCircle.y);

            Instantiate(_enemyPrefab, position, Quaternion.identity);
        }
    }
}
