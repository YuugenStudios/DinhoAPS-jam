using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;

    [SerializeField] int enemiesPerWave, enemyInstantiated;
    [SerializeField] int[] enemiesPerWaveMultiply;
    public int activeEnemies;

    //timers
    [SerializeField] float timeBetweenSpawn, timeToStart;

    int enemyIndexArray;

    //externals
    plantBehaviour _plantBehaviour;

    void Awake() {
        _plantBehaviour = FindObjectOfType<plantBehaviour>();
    }
    void Start() {
        InvokeRepeating("EnemySpawn", timeToStart, timeBetweenSpawn);
    }

    void EnemySpawn() {
        if(!pauseController.FindObjectOfType<pauseController>().isPaused){
            if (activeEnemies <= enemiesPerWave) {
                int enemyDir = Random.Range(0, 2);
                enemyIndexArray = Random.Range(0, enemyPrefabs.Length);
                    
                var enemy = Instantiate(enemyPrefabs[enemyIndexArray], Vector3.zero, Quaternion.identity);
                if (enemyDir == 1) {
                    enemy.transform.rotation = Quaternion.Euler(0, 0, 90);
                }
                else {
                    enemy.transform.rotation = Quaternion.Euler(0, 0,-90);
                }
                activeEnemies++;
                enemyInstantiated++;
            }

            switch(_plantBehaviour.clorofilaEnergy) {
                case 20:
                    enemiesPerWave = enemiesPerWaveMultiply[0];
                    break;
                case 40:
                    enemiesPerWave = enemiesPerWaveMultiply[1];
                    break;
                case 60:
                    enemiesPerWave = enemiesPerWaveMultiply[2];
                    break;
                case 80:
                    enemiesPerWave = enemiesPerWaveMultiply[3];
                    break;
                case 90:
                    enemiesPerWave = enemiesPerWaveMultiply[4];
                    break;

            }
        }
    }
}
