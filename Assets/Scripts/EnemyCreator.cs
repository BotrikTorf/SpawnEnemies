using UnityEngine;
using System.Collections;

public class EnemyCreator : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _creationPeriod = 3f;
    [SerializeField] private float _radius = 48;

    //private float _timer;
    private Coroutine _coroutine;
    private bool _runCreator = true;

    private void Start()
    {
        ManagesCoroutine();
    }

    //private void Update()
    //{
    //    _timer += Time.deltaTime;

    //    if (_timer > _creationPeriod) 
    //    {
    //        _timer = 0;

    //        Vector2 randomCircle = Random.insideUnitCircle * _radius;
    //        Vector3 position = new Vector3(randomCircle.x, 0.8f, randomCircle.y);

    //        Instantiate(_enemyPrefab, position, Quaternion.identity);

    //    }
    //}

    public void ManagesCoroutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(CreatorEnemy());
        }

        _coroutine = StartCoroutine(CreatorEnemy());
    }

    private IEnumerator CreatorEnemy()
    {
        var timeCreator = new WaitForSeconds(_creationPeriod);

        while (_runCreator)
        {
            Vector2 randomCircle = Random.insideUnitCircle * _radius;
            Vector3 position = new Vector3(randomCircle.x, 0.8f, randomCircle.y);

            Instantiate(_enemyPrefab, position, Quaternion.identity);
            yield return timeCreator;
        }
    }
}
