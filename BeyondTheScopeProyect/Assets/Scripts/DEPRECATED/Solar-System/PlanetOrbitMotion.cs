using UnityEngine;

public class PlanetOrbitMotion : MonoBehaviour
{
    [Header("Referencia Orbital")]
    public Transform objetoDeReferencia;

    [Header("Par�metros orbitales")]
    [Tooltip("Velocidad de la �rbita en km/h.")]
    public float velocidadDeOrbita;
    [Tooltip("Inclinaci�n de la �rbita en grados.")]
    public float inclinacionDeOrbita;
    [Tooltip("Semieje mayor de la �rbita.")]
    public float semiejeMayor;
    [Tooltip("Semieje menor de la �rbita.")]
    public float semiejeMenor;
    public enum DireccionDeOrbita { Horaria, Antihoraria }
    [Tooltip("Direcci�n de la �rbita.")]
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
        float inclinacion = inclinacionDeOrbita * Mathf.Deg2Rad;  // Inclinaci�n en radianes

        // Calcular la velocidad variable del objeto
        float distanciaActual = Vector3.Distance(objetoDeReferencia.position, transform.position) ;

        float velocidadVariable = Mathf.Lerp(velocidadDeOrbita * 0.8f,
                                             velocidadDeOrbita * 1.2f,
                                             (distanciaActual) / (a));

        // Incrementar tiempo
        elapsedTime += Time.deltaTime * velocidadVariable;

        // Aplicar direcci�n de �rbita
        float angleMultiplier = direccionDeOrbita == DireccionDeOrbita.Horaria ? -1.0f : 1.0f;

        // Calcular posici�n en coordenadas polares
        float angle = Mathf.Abs(elapsedTime * Mathf.Deg2Rad) * angleMultiplier;
        float x = a * Mathf.Cos(angle);
        float z = b * Mathf.Sin(angle);

        // Aplicar inclinaci�n
        float y = Mathf.Sin(angle) * Mathf.Sin(inclinacion) * b;

        // Actualizar posici�n del objeto
        transform.position = objetoDeReferencia.transform.position  + new Vector3(x, y, z) ;
    }
}
