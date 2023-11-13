using UnityEngine;

public class OrbitSimulation : MonoBehaviour
{
    public Transform star;
    public float perihelion; // en metros
    public float aphelion; // en metros
    public float eccentricity;
    public float inclination; // en grados
    public float orbitalPeriod; // en segundos
    //public float averageOrbitalSpeed; // en metros por segundo

    private float semiMajorAxis;
    private float semiMinorAxis;
    private float focalLength;
    private float theta = 0; // Ángulo actual en la órbita

    void Start()
    {
        
        /*// Convertir período orbital de años a segundos
        orbitalPeriod *= 365.25f * 24 * 60 * 60;

        // Convertir velocidad orbital media de km/s a m/s
        averageOrbitalSpeed *= 1000;*/
    }

    void Update()
    {

        // Calcular los semiejes a partir del perihelio, afelio y excentricidad
        semiMajorAxis = (perihelion + aphelion) / 2;
        semiMinorAxis = semiMajorAxis * Mathf.Sqrt(1 - eccentricity * eccentricity);
        focalLength = Mathf.Sqrt(semiMajorAxis * semiMajorAxis - semiMinorAxis * semiMinorAxis);

        // Calcular la anomalía media
        float meanAnomaly = 2 * Mathf.PI * Time.time / orbitalPeriod;
        // Calcular la anomalía excéntrica (puede requerir una solución iterativa para precisión)
        float eccentricAnomaly = meanAnomaly; // Esto es una aproximación

        // Calcular la distancia radial en función de la anomalía excéntrica
        float r = semiMajorAxis * (1 - eccentricity * Mathf.Cos(eccentricAnomaly));
        // Calcular la verdadera anomalía
        theta = 2 * Mathf.Atan2(Mathf.Sqrt(1 + eccentricity) * Mathf.Sin(eccentricAnomaly / 2),
                                Mathf.Sqrt(1 - eccentricity) * Mathf.Cos(eccentricAnomaly / 2));

        // Calcular la posición en coordenadas cartesianas en el plano XZ
        Vector3 position = new Vector3(r * Mathf.Cos(theta), 0, r * Mathf.Sin(theta));

        // Ajustar la posición por la longitud focal para establecer el perihelio y afelio correctamente
        position.x += focalLength;

        // Crear un quaternion de inclinación que afecte solo al plano de la órbita
        Quaternion inclinationRotation = Quaternion.Euler(inclination, 0, 0);
        // Rotar la posición de la órbita para aplicar la inclinación
        position = inclinationRotation * position;

        // Establecer la posición del planeta en el espacio mundial
        transform.position = star.TransformPoint(position);
    }
}
