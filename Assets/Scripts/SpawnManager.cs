using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject[] powerups;
    [SerializeField]
    private float _spawnX = 10.0f;
    [SerializeField]
    private float _spawnY = 7.0f;
    [SerializeField]
    private float _spawnRate = 5.0f;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private bool _stopSpawningEnemy = false;
    [SerializeField]
    private bool _stopSpawningPowerup = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (_stopSpawningEnemy == false)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(Random.Range(-_spawnX, _spawnX), _spawnY, 0), Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(_spawnRate);
        }
    }
    IEnumerator SpawnPowerUpRoutine()
    {
        while (_stopSpawningPowerup == false) 
        {
            int randomPowerUp = Random.Range(0, 2);
            GameObject powerUp = Instantiate(powerups[randomPowerUp], new Vector3(Random.Range(-_spawnX, _spawnX), _spawnY, 0), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3.0f, 7.0f));
        }
    }
    public void OnPlayerDeath()
    {
        _stopSpawningEnemy = true;
        _stopSpawningPowerup = true;
    }
}
