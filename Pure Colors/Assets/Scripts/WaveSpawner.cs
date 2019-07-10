using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class WaveSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    //public List MiniWave miniWavesInWave = new List<
    public LevelScriptableObject levelScriptableObject;

    public Level level;

    public float startX = 20f;

    public MiniWavesScriptableObject miniwave;

    void Start()
    {
        DeserializeLevel();
        StartCoroutine("SpawnLevel");
        
    }

    private void DeserializeLevel()
    {
        //Lord have mercy
        foreach(WavesScriptableObject wave in levelScriptableObject.waves)
        {
            Wave tempWave = new Wave();

            List<MiniWave> miniWaves = new List<MiniWave>();
            foreach(MiniWavesScriptableObject miniWave in wave.wave)
            {
                List<EnemyInWave> enemyList = new List<EnemyInWave>();
                foreach (EnemyInWave enemy in miniWave.miniWave.enemiesInMiniWave)
                {
                    enemyList.Add(enemy);
                }
                MiniWave tempMiniWave = new MiniWave{enemiesInMiniWave = enemyList, delay = miniWave.miniWave.delay};
                miniWaves.Add(tempMiniWave);
            }
            tempWave.miniWaves = miniWaves;
            level.waves.Add(tempWave);
        }
    }



    // Update is called once per frame
    void Update()
    {
    
    }

    

     private IEnumerator SpawnLevel()
    {
       foreach (Wave wave in level.waves)
       {
           foreach(MiniWave miniwave in wave.miniWaves)
           {
               foreach(EnemyInWave enemy in miniwave.enemiesInMiniWave)
               {
                   Instantiate(enemy.enemy, new Vector2(startX, enemy.ySpawnPos), Quaternion.identity);
               }
            yield return new WaitForSeconds(miniwave.delay);
           }
        yield return new WaitForSeconds(10);
       }

    }
}

[System.Serializable]
public struct Level
{
    public List<Wave> waves;
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
