using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] NPCsT1;
    [SerializeField] 
    private GameObject[] NPCsT2;
    [SerializeField] 
    private GameObject[] NPCsT3;

    public void StartSpawner(int[] enemies, float spawnDelay)
    {
        StartCoroutine(SpawnerStart(enemies, spawnDelay));
    }

    IEnumerator SpawnerStart(int[] enemies, float spawnDelay)
    {
        GameManager.totalEnemies = enemies.Length;
        GameManager.enemiesLeft = GameManager.totalEnemies;

        GameManager.enemyCounterText.text = GameManager.enemiesLeft.ToString() + "/" + GameManager.totalEnemies.ToString() + " Enemies";

        List<GameObject> enemiesGO = new List<GameObject>();
        foreach(int enemy in enemies)
        {
            switch (enemy)
            {
                case 1:
                    enemiesGO.Add(NPCsT1[Random.Range(0, NPCsT1.Length)]);
                    break;
                case 2:
                    enemiesGO.Add(NPCsT2[Random.Range(0, NPCsT2.Length)]);
                    break;
                case 3:
                    enemiesGO.Add(NPCsT3[Random.Range(0, NPCsT3.Length)]);
                    break;
            }
        }

        foreach(GameObject enemy in enemiesGO)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnDelay);
        }
        
    }

}
