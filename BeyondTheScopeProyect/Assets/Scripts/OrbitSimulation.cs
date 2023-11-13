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
    private float theta = 0; // �ngulo actual en la �rbita

    void Start()
    {
        
        /*// Convertir per�odo orbital de a�os a segundos
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

        // Calcular la anomal�a media
        float meanAnomaly = 2 * Mathf.PI * Time.time / orbitalPeriod;
        // Calcular la anomal�a exc�ntrica (puede requerir una soluci�n iterativa para precisi�n)
        float eccentricAnomaly = meanAnomaly; // Esto es una aproximaci�n

        // Calcular la distancia radial en funci�n de la anomal�a exc�ntrica
        float r = semiMajorAxis * (1 - eccentricity * Mathf.Cos(eccentricAnomaly));
        // Calcular la verdadera anomal�a
        theta = 2 * Mathf.Atan2(Mathf.Sqrt(1 + eccentricity) * Mathf.Sin(eccentricAnomaly / 2),
                                Mathf.Sqrt(1 - eccentricity) * Mathf.Cos(eccentricAnomaly / 2));

        // Calcular la posici�n en coordenadas cartesianas en el plano XZ
        Vector3 position = new Vector3(r * Mathf.Cos(theta), 0, r * Mathf.Sin(theta));

        // Ajustar la posici�n por la longitud focal para establecer el perihelio y afelio correctamente
        position.x += focalLength;

        // Crear un quaternion de inclinaci�n que afecte solo al plano de la �rbita
        Quaternion inclinationRotation = Quaternion.Euler(inclination, 0, 0);
        // Rotar la posici�n de la �rbita para aplicar la inclinaci�n
        position = inclinationRotation * position;

        // Establecer la posici�n del planeta en el espacio mundial
        transform.position = star.TransformPoint(position);
    }
}
