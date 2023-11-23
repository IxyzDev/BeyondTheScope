using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportManager : MonoBehaviour
{
    public string targetScene; // Nombre de la escena de destino
    public Vector3 targetLocation; // Ubicaci�n de destino en la nueva escena

    // M�todo para teletransportar al jugador
    public void TeleportPlayer()
    {
        // Cargar la escena de destino
        SceneManager.LoadScene(targetScene);

        // Mover al jugador a la ubicaci�n de destino
        // Esto se puede hacer en la funci�n Start() del script del jugador en la nueva escena,
        // o usando un m�todo de "Singleton" para preservar el estado del jugador entre escenas.
    }
}
