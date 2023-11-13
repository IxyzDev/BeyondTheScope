using System;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DrawEllipse : MonoBehaviour
{
    public int segments = 100;
    public Transform objetoDeReferencia;
    public float inclinacionDeOrbita;
    public float semiejeMayor;
    public float semiejeMenor;

    private LineRenderer lineRenderer;
    private float distancia;
    private float distanciaMin;

    void Awake()
    {
        if (!objetoDeReferencia)
        {
            Debug.LogWarning("Objeto de referencia no establecido. Usando distancia por defecto.");
            distancia = 0;
            return;
        }

        Renderer renderer = objetoDeReferencia.GetComponent<Renderer>();
        Vector3 size = renderer.bounds.size;

        distancia = Vector3.Distance(transform.position, objetoDeReferencia.position);
        distanciaMin  = Mathf.Max(size.x, size.y, size.z) / 2; // Usamos /2 porque queremos el radio, no el diámetro
    }

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = segments + 1;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

    }

    void Update()
    {
        Draw();
    }

    void Draw()
    {

        //Console.WriteLine("distancia: " + distancia);

        float a = semiejeMayor + distancia;
        float b = semiejeMenor + distancia;
        float angle = 0f;

        for (int i = 0; i < segments + 1; i++)
        {
            float x = Mathf.Cos(Mathf.Deg2Rad * angle) * a;
            float z = Mathf.Sin(Mathf.Deg2Rad * angle) * b;

            // Crear el vector de posición relativo al centro de la órbita
            Vector3 pos = objetoDeReferencia.position + new Vector3(x, 0, z);

            // Aplicar la inclinación
            pos = Quaternion.AngleAxis(-inclinacionDeOrbita, Vector3.right) * (pos - objetoDeReferencia.position);

            // Ahora sumamos la posición del objeto de referencia
            pos += objetoDeReferencia.position;

            lineRenderer.SetPosition(i, pos);

            angle += 360f / segments;
        }
    }
}
