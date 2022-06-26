using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject bug_prefab;
    public float respawnTime = 20f;
    public Transform positionToSpawn;
    public bool rotateEnemy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyWaves());
    }

    // Update is called once per frame

    private void spawnEnemy()
    {
        if (rotateEnemy)
        {
            bug_prefab.GetComponent<Enemy>().rotation = true;
            Instantiate(bug_prefab, positionToSpawn.position, positionToSpawn.rotation);
        }
        if (!rotateEnemy)
        {
            bug_prefab.GetComponent<Enemy>().rotation = false;
            Instantiate(bug_prefab, positionToSpawn.position, positionToSpawn.rotation);
        }

    }

    IEnumerator EnemyWaves()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }
}
