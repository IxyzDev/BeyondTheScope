using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public float dayLengthInMinutes = 2f; // Duración del día en minutos
    public Transform sun; // Referencia a la luz direccional que actúa como el sol

    void Update()
    {
        float dayLengthInSeconds = dayLengthInMinutes * 60f; // Convertir la duración a segundos
        float angleThisFrame = Time.deltaTime / dayLengthInSeconds * 360f; // Cálculo de la rotación para este frame
        sun.transform.Rotate(Vector3.right * angleThisFrame); // Rotación de la luz direccional
    }
}
