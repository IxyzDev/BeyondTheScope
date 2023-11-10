using UnityEngine;

public class AsteroidBeltSpawner : MonoBehaviour
{
    public int numberOfAsteroids = 100;  // Cantidad de asteroides a generar.
    public float beltThickness = 100f;   // Grosor del cinturón de asteroides.

    public Vector2 rotationSpeedRange = new Vector2(1.0f, 20.0f);
    public Vector2 orbitSpeedRange = new Vector2(5.0f, 15.0f);
    public Vector2 axialTiltRange = new Vector2(0.0f, 45.0f);
    public Vector2 scaleRange = new Vector2(0.5f, 3.0f);

    private void Start()
    {
        SpawnAsteroids();
    }

    void SpawnAsteroids()
    {
        // Precálculo para optimizar la generación de asteroides.
        float halfBeltThickness = beltThickness * 0.5f;

        for (int i = 0; i < numberOfAsteroids; i++)
        {
            // Ahora obtenemos el asteroide del pool en lugar de instanciar uno nuevo.
            GameObject newAsteroid = AsteroidPooler.Instance.GetPooledAsteroid();

            float angle = Random.Range(0, 360) * Mathf.Deg2Rad;
            float radius = Random.Range(0, beltThickness);

            // Calcula la posición del asteroide en base a la distancia y el ángulo.
            Vector3 position = transform.position + new Vector3(radius * Mathf.Cos(angle), Random.Range(-halfBeltThickness, halfBeltThickness), radius * Mathf.Sin(angle));
            newAsteroid.transform.position = position;

            newAsteroid.transform.rotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));

            // Asegurarse de que el asteroide sea visible.
            newAsteroid.SetActive(true);

            PlanetMovement movement = newAsteroid.GetComponent<PlanetMovement>();
            if (movement != null)
            {
                movement.rotationSpeed = Random.Range(rotationSpeedRange.x, rotationSpeedRange.y);
                movement.orbitSpeed = Random.Range(orbitSpeedRange.x, orbitSpeedRange.y);
                movement.axialTilt = Random.Range(axialTiltRange.x, axialTiltRange.y);
            }

            // Ajusta el tamaño del asteroide.
            float scale = Random.Range(scaleRange.x, scaleRange.y);
            newAsteroid.transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}
