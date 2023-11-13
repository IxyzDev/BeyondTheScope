using System.Collections.Generic;
using UnityEngine;

public class AsteroidPool : MonoBehaviour
{
    [Header("Referencia Orbital")]
    public Transform objetoDeReferencia;

    [Header("Configuración de Asteroides")]
    [Tooltip("Lista de prefabs de asteroides para ser generados.")]
    public List<GameObject> asteroidPrefabs;
    [Tooltip("Número total de asteroides a ser generados.")]
    public int poolSize;

    [Header("Distancias")]
    [Tooltip("Distancia mínima desde el punto central para generar asteroides.")]
    public float minDistance;
    [Tooltip("Distancia máxima desde el punto central para generar asteroides.")]
    public float maxDistance;

    private void Start()
    {
        GenerateAsteroids();
    }

    void GenerateAsteroids()
    {
        float distanciaDelSol = Vector3.Distance(transform.position, objetoDeReferencia.position);
        minDistance = minDistance + distanciaDelSol;
        maxDistance = maxDistance + distanciaDelSol;

        for (int i = 0; i < poolSize; i++)
        {
            int randomPrefabIndex = Random.Range(0, asteroidPrefabs.Count);
            Vector3 asteroidPosition = GenerateRandomPositionInBelt();
            GameObject asteroid = Instantiate(asteroidPrefabs[randomPrefabIndex], asteroidPosition, Quaternion.identity, this.transform);
            asteroid.name = "Asteroid_" + i;
            asteroid.SetActive(true);
        }
    }

    private Vector3 GenerateRandomPositionInBelt()
    {
        float randomRadius = Random.Range(minDistance, maxDistance);
        float randomAngle = Random.Range(0f, 2f * Mathf.PI);

        Vector3 positionOffset = new Vector3(
            randomRadius * Mathf.Cos(randomAngle),
            0f,  // Se mantiene la variación vertical en 0
            randomRadius * Mathf.Sin(randomAngle)
        );

        return objetoDeReferencia.position + positionOffset;
    }
}
