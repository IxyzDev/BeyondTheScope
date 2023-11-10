using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public float dayLengthInMinutes = 2f; // Duraci�n del d�a en minutos
    public Transform sun; // Referencia a la luz direccional que act�a como el sol

    void Update()
    {
        float dayLengthInSeconds = dayLengthInMinutes * 60f; // Convertir la duraci�n a segundos
        float angleThisFrame = Time.deltaTime / dayLengthInSeconds * 360f; // C�lculo de la rotaci�n para este frame
        sun.transform.Rotate(Vector3.right * angleThisFrame); // Rotaci�n de la luz direccional
    }
}
