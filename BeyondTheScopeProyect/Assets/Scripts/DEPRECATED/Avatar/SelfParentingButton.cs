using UnityEngine;
using UnityEngine.UI;

public class SelfParentingButton : MonoBehaviour
{
    public GameObject childObject; // Objeto que ser� hijo temporalmente
    public Vector3 offset; // Desplazamiento respecto al objeto padre
    public Button button; // Bot�n de Unity que activa o desactiva el parentesco

    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Transform originalParent;

    // Variable est�tica para llevar la cuenta del �ltimo bot�n pulsado
    private static SelfParentingButton lastButtonPressed;

    void Start()
    {
        // Guardar la posici�n, rotaci�n y parentesco original del objeto hijo
        originalPosition = childObject.transform.position;
        originalRotation = childObject.transform.rotation;
        originalParent = childObject.transform.parent;

        // Asignar el m�todo ToggleParenting al evento onClick del bot�n
        button.onClick.AddListener(ToggleParenting);
    }

    public void ToggleParenting()
    {
        // Si se ha pulsado un bot�n antes, desactivarlo
        if (lastButtonPressed != null && lastButtonPressed != this)
        {
            lastButtonPressed.Deactivate();
        }

        // Si este bot�n ya est� activo, desactivarlo
        if (lastButtonPressed == this)
        {
            Deactivate();
            lastButtonPressed = null;
            return;
        }

        // Activar este bot�n y hacerlo el �ltimo pulsado
        Activate();
        lastButtonPressed = this;
    }

    private void Activate()
    {
        childObject.transform.SetParent(transform);
        childObject.transform.localPosition = offset; // Ajustar la posici�n en relaci�n con el padre
    }

    private void Deactivate()
    {
        childObject.transform.SetParent(originalParent);
        childObject.transform.position = originalPosition;
        childObject.transform.rotation = originalRotation;
    }
}
