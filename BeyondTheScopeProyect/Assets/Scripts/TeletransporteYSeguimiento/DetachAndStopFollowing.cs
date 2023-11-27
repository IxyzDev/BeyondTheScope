using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachAndStopFollowing : MonoBehaviour
{
    public GameObject jugador; // Referencia al jugador

    // Método para desvincular al jugador del objeto y detener su seguimiento
    public void DetachAndStop()
    {
        // Desvincular al jugador del objeto en movimiento
        jugador.transform.SetParent(null);

        // Opcional: Mover al jugador a una nueva posición
        // jugador.transform.position = nuevaPosicion;
    }

    // Este método se puede llamar desde otro lugar, como en respuesta a un evento
}
