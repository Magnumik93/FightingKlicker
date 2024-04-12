using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnEnemy;
    [SerializeField] private Transform[] spawnPoint;
    [SerializeField] private float seconds;
        
    private float _spawnerInterval;

    public int NumberOfEnemies;
    public int NowTheEnemies;

    private int _randomEnemy;
    private int _randomPoint;

    private void Start()
    {
        seconds = 2;
        _spawnerInterval = seconds; 
    }

    private void Update()
    {
        if (_spawnerInterval <= 0 && NowTheEnemies < NumberOfEnemies)
        {
            _randomEnemy = Random.Range(0, spawnEnemy.Length);
            _randomPoint = Random.Range(0, spawnPoint.Length);

            Instantiate(spawnEnemy[_randomEnemy], spawnPoint[_randomPoint].transform.position,
                Quaternion.identity);

            _spawnerInterval = seconds;

            NowTheEnemies++;
            if (NowTheEnemies >= NumberOfEnemies)
                StartCoroutine(NewWave());
        }
        else
        {
            _spawnerInterval -= Time.deltaTime;
        }
    }

    private IEnumerator NewWave()
    {
        yield return new WaitForSeconds(seconds);
        NowTheEnemies = 0;
        if (seconds >= 0.6f)
        {
            NumberOfEnemies *= 2;
            seconds -= 0.3f;
        }
        else
        {
            seconds = 0.3f;
        }
    }
}