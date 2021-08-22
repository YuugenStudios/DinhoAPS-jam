using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;

    [SerializeField] int enemiesPerWave, enemiesPerWaveMultiply, enemyInstantiate;
    public int activeEnemies, enemiesToWin;
    [SerializeField] float timeBetweenSpawn, timeToStart;
    int enemyIndexArray;

    //externals
    void Start() {
        InvokeRepeating("EnemySpawn", timeToStart, timeBetweenSpawn);
    }

    void EnemySpawn() {
        if (activeEnemies <= enemiesPerWave) {
            int enemyDir = Random.Range(0, 2);
            enemyIndexArray = Random.Range(0, enemyPrefabs.Length);
                
            var enemy = Instantiate(enemyPrefabs[enemyIndexArray], Vector3.zero, Quaternion.identity);
            if (enemyDir == 1)
            {
                enemy.transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else
            {
                enemy.transform.rotation = Quaternion.Euler(0, 0,-90);
            }
            activeEnemies++;
            enemyInstantiate++;
        }

        //switch (_score.virusKilled) {
        //    case 5:
        //        enemiesPerWave += enemiesPerWaveMultiply;
        //        break;

        //    case 10:
        //        enemiesPerWave += enemiesPerWaveMultiply;
        //        break;

        //    case 15:
        //        enemiesPerWave += enemiesPerWaveMultiply;
        //        break;
        //    case 20:
        //        FindObjectOfType<CallScene>().callScene("WonScreen");
        //        break;
        //}
    }
}
