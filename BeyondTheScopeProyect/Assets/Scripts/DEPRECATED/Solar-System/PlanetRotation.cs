using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    [Header("Parametros de rotacion")]
    public float velocidadDeRotacion = 10f; // en grados por segundo
    public enum DireccionDeRotacion { Horaria, Antihoraria }
    public DireccionDeRotacion direccionDeRotacion = DireccionDeRotacion.Horaria;
    public float ejeAxial = 23.5f; // Inclinación típica para la Tierra, pero puedes cambiarla en el inspector.

    private Vector3 axisOfRotation;

    private void Start()
    {
        // Establecer el eje de rotación basado en el eje axial.
        axisOfRotation = Quaternion.Euler(ejeAxial, 0, 0) * Vector3.up;
    }

    private void Update()
    {
        RotatePlanet();
    }

    void RotatePlanet()
    {
        float rotationSpeed = (direccionDeRotacion == DireccionDeRotacion.Horaria ? -1 : 1) * velocidadDeRotacion;
        transform.RotateAround(transform.position, axisOfRotation, rotationSpeed * Time.deltaTime);
    }
}
