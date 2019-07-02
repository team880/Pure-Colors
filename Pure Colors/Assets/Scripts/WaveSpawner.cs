using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class WaveSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    //public List MiniWave miniWavesInWave = new List<
    public List<Wave> level = new List<Wave>();

    void Start()
    {
        StartCoroutine("SpawnEverything");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    public struct Wave
    {
        public List<MiniWave> miniWaves;
    }

    [System.Serializable]
    public class MiniWave
    {
        public List<EnemyInWave> enemiesInMiniWave;
        public float delay;
    }
    
    [System.Serializable]
    public struct EnemyInWave
    {
        public GameObject enemy;
        public float ySpawnPos;
    }

    private IEnumerator SpawnEverything()
    {
        while (true)
        {
            foreach(MiniWave miniwave in level[0].miniWaves)
            {
                foreach (EnemyInWave enemy in miniwave.enemiesInMiniWave)
                {
                    Instantiate (enemy.enemy, new Vector2(22, enemy.ySpawnPos), Quaternion.identity);
                }
                yield return new WaitForSeconds(miniwave.delay);
            }
        }
    }
}
