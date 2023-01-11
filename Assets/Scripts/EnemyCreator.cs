using UnityEngine;
using System.Collections;
using TMPro;

public class EnemyCreator : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _creationPeriod = 3f;
    [SerializeField] private float _radius = 48;
    [SerializeField] private GameObject _character;
    [SerializeField] private TMP_Text _text;

    private Coroutine _coroutine;
    private bool _runCreator = false;
    private float _startPositionY = 0.8f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            StartEnemy();
    }

    private void ManagesCoroutine()
    {
        if (_coroutine != null)
            StopCoroutine(CreatorEnemy());

        _coroutine = StartCoroutine(CreatorEnemy());
    }

    private IEnumerator CreatorEnemy()
    {
        var timeCreator = new WaitForSeconds(_creationPeriod);

        while (_runCreator)
        {
            Vector2 randomCircle = Random.insideUnitCircle * _radius;
            Vector3 position = new Vector3(randomCircle.x, _startPositionY, randomCircle.y);

            Enemy enemy = Instantiate(_enemyPrefab, position, Quaternion.identity);
            enemy.SetTarget(_character);

            yield return timeCreator;
        }
    }

    private void StartEnemy()
    {
        if (_runCreator == false)
        {
            _runCreator = true;
            _text.text = "Для остановки появления противников нажми Enter";
            ManagesCoroutine();
        }
        else
        {
            _runCreator = false;
            _text.text = "Для появления противников нажми Enter";
            ManagesCoroutine();
        }
    }
}
