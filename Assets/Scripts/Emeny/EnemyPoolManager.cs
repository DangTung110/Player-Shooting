using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemyPoolManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private int poolSize;
    private List<GameObject> enemyPool;
    float timer = 0f;
    private void Start()
    {
        CreateEnemyPool();
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f) 
        {
            GameObject enemy = GetEnemy();
            if (enemy != null)
            {
                enemy.SetActive(true);
                enemy.transform.position = transform.position;
            }   
            timer = 2.5f;
        }   
    }
    private void CreateEnemyPool()
    {
        enemyPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            int rd = Random.Range(0, 2);
            GameObject newEnemy = Instantiate(enemyPrefab[rd], gameObject.transform);
            newEnemy.SetActive(false);
            enemyPool.Add(newEnemy);
        }
    }
    public GameObject GetEnemy()
    {
        for (int i = 0; i < enemyPool.Count; i++)
        {
            if (!enemyPool[i].activeInHierarchy)
                return enemyPool[i];
        }
        return null;
    }
}
