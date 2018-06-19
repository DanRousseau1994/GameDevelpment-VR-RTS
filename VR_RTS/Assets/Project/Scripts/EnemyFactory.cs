using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private Transform Player;
    
    public Enemy EnemyPrefab;
    public Transform SpawnPoint;
    public float TimeBetweenWaves = 5f;
    private float _countdown = 2f;

    public Text WaveCountdownText;

    private int _waveIndex = 0;

    void Update()
    {
        if (_countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            _countdown = TimeBetweenWaves;
        }

        _countdown -= Time.deltaTime;

        WaveCountdownText.text = Mathf.Round(_countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        _waveIndex++;

        for (int i = 0; i < _waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        var spawn = Instantiate(EnemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
        spawn.Initilaze(Player);
    }
}