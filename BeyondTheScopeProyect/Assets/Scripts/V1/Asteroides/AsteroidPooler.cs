using UnityEngine;
using System.Collections.Generic;

public class AsteroidPooler : MonoBehaviour
{
    public static AsteroidPooler Instance;  // Singleton pattern to easily access the pooler

    public GameObject[] asteroidPrefabs;
    public int initialPoolSize = 100;  // Initial pool size

    private List<GameObject> asteroidPool = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        InitializePool();
    }

    void InitializePool()
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject asteroid = Instantiate(GetRandomAsteroidPrefab(), transform);
            asteroid.SetActive(false);
            asteroidPool.Add(asteroid);
        }
    }

    public GameObject GetPooledAsteroid()
    {
        foreach (GameObject asteroid in asteroidPool)
        {
            if (!asteroid.activeInHierarchy)
            {
                return asteroid;
            }
        }

        // If no inactive asteroid found, expand the pool
        GameObject newAsteroid = Instantiate(GetRandomAsteroidPrefab(), transform);
        asteroidPool.Add(newAsteroid);
        return newAsteroid;
    }

    GameObject GetRandomAsteroidPrefab()
    {
        return asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)];
    }
}
