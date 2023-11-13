using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotSunLightController : MonoBehaviour
{
    public GameObject targetObject;  // Referencia al objeto al que la luz deber�a apuntar
    public GameObject lightObject;   // Referencia al objeto de luz que debe orientarse

    void Update()
    {
        // Asegura que ambos objetos est�n asignados antes de proceder
        if (targetObject != null && lightObject != null)
        {
            // Hace que la luz apunte hacia el objeto
            lightObject.transform.LookAt(targetObject.transform);

            // Ajusta la rotaci�n en 180 grados para que la parte trasera de la luz apunte al objeto
            lightObject.transform.rotation *= Quaternion.Euler(0, 180, 0);
        }
    }
}

