using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachAndStopFollowing : MonoBehaviour
{
    public GameObject jugador; // Referencia al jugador

    // M�todo para desvincular al jugador del objeto y detener su seguimiento
    public void DetachAndStop()
    {
        // Desvincular al jugador del objeto en movimiento
        jugador.transform.SetParent(null);

        // Opcional: Mover al jugador a una nueva posici�n
        // jugador.transform.position = nuevaPosicion;
    }

    // Este m�todo se puede llamar desde otro lugar, como en respuesta a un evento
}
