using UnityEngine;

public class PlanetMovement : MonoBehaviour
{
    public Transform orbitCenter; // Punto alrededor del cual el planeta girará. Podría ser un sol ficticio.
    public float rotationSpeed = 10.0f; // Velocidad de rotación sobre su propio eje.
    public float orbitSpeed = 10.0f; // Velocidad de giro alrededor del punto.
    public float axialTilt = 23.5f; // Oblicuidad o inclinación axial. Para la Tierra, es de aproximadamente 23.5 grados.

    private float orbitAngle = 0.0f; // Ángulo de la órbita.
    private float orbitRadius; // Radio de la órbita alrededor del punto.
    private Vector3 rotationAxis; // Eje de rotación después de aplicar la inclinación axial.

    void Start()
    {
        // Establecer el eje de rotación con la inclinación axial.
        rotationAxis = Quaternion.Euler(0, 0, axialTilt) * Vector3.up;
    }

    void Update()
    {
        // Calculamos la distancia actual entre el planeta y el centro de la órbita para establecer el radio de la órbita.
        orbitRadius = Vector3.Distance(transform.position, orbitCenter.position);

        RotateOnAxis();
        OrbitAroundPoint();
    }

    void RotateOnAxis()
    {
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime, Space.Self);
    }

    void OrbitAroundPoint()
    {
        orbitAngle += orbitSpeed * Time.deltaTime;

        Vector3 offset = new Vector3(
            orbitRadius * Mathf.Cos(orbitAngle),
            0.0f,
            orbitRadius * Mathf.Sin(orbitAngle)
        );

        transform.position = orbitCenter.position + offset;
    }
}
