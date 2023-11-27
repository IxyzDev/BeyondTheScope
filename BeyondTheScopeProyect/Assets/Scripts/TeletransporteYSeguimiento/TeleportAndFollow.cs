using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAndFollow : MonoBehaviour
{
    public GameObject jugador; // Referencia al jugador
    public GameObject objetoMovimiento; // Referencia al objeto en movimiento

    // M�todo para teletransportar y hacer que el jugador siga al objeto
    public void TeleportAndFollowObject()
    {
        // Teletransportar al jugador a la posici�n del objeto
        jugador.transform.position = objetoMovimiento.transform.position;

        // Hacer que el jugador sea hijo del objeto para seguir su movimiento
        jugador.transform.SetParent(objetoMovimiento.transform);
    }

    // Puedes llamar a este m�todo desde otro lugar, por ejemplo, en respuesta a un evento
}
