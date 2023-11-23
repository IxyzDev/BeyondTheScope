using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportManager : MonoBehaviour
{
    public string targetScene; // Nombre de la escena de destino
    public Vector3 targetLocation; // Ubicación de destino en la nueva escena

    // Método para teletransportar al jugador
    public void TeleportPlayer()
    {
        // Cargar la escena de destino
        SceneManager.LoadScene(targetScene);

        // Mover al jugador a la ubicación de destino
        // Esto se puede hacer en la función Start() del script del jugador en la nueva escena,
        // o usando un método de "Singleton" para preservar el estado del jugador entre escenas.
    }
}
