using UnityEngine;

public class PlanetOrbitMotion : MonoBehaviour
{
    [Header("Referencia Orbital")]
    public Transform objetoDeReferencia;

    [Header("Parámetros orbitales")]
    [Tooltip("Velocidad de la órbita en km/h.")]
    public float velocidadDeOrbita;
    [Tooltip("Inclinación de la órbita en grados.")]
    public float inclinacionDeOrbita;
    [Tooltip("Semieje mayor de la órbita.")]
    public float semiejeMayor;
    [Tooltip("Semieje menor de la órbita.")]
    public float semiejeMenor;
    public enum DireccionDeOrbita { Horaria, Antihoraria }
    [Tooltip("Dirección de la órbita.")]
    public DireccionDeOrbita direccionDeOrbita;

    private float distanciaDelSol;
    private float elapsedTime = 0.0f;

    void Awake()
    {
        if (!objetoDeReferencia)
        {
            Debug.LogWarning("Objeto de referencia no establecido. Usando distancia por defecto.");
            return;
        }
        distanciaDelSol = Vector3.Distance(transform.position, objetoDeReferencia.position);
    }

    void Update()
    {
        OrbitPlanet();
    }

    void OrbitPlanet()
    {
        float a = semiejeMayor + distanciaDelSol;  // Semieje mayor
        float b = semiejeMenor + distanciaDelSol;  // Semieje menor
        float inclinacion = inclinacionDeOrbita * Mathf.Deg2Rad;  // Inclinación en radianes

        // Calcular la velocidad variable del objeto
        float distanciaActual = Vector3.Distance(objetoDeReferencia.position, transform.position) ;

        float velocidadVariable = Mathf.Lerp(velocidadDeOrbita * 0.8f,
                                             velocidadDeOrbita * 1.2f,
                                             (distanciaActual) / (a));

        // Incrementar tiempo
        elapsedTime += Time.deltaTime * velocidadVariable;

        // Aplicar dirección de órbita
        float angleMultiplier = direccionDeOrbita == DireccionDeOrbita.Horaria ? -1.0f : 1.0f;

        // Calcular posición en coordenadas polares
        float angle = Mathf.Abs(elapsedTime * Mathf.Deg2Rad) * angleMultiplier;
        float x = a * Mathf.Cos(angle);
        float z = b * Mathf.Sin(angle);

        // Aplicar inclinación
        float y = Mathf.Sin(angle) * Mathf.Sin(inclinacion) * b;

        // Actualizar posición del objeto
        transform.position = objetoDeReferencia.transform.position  + new Vector3(x, y, z) ;
    }
}
