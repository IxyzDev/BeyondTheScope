using UnityEngine;
using UnityEngine.UI;

public class SelfParentingButton : MonoBehaviour
{
    public GameObject childObject; // Objeto que será hijo temporalmente
    public Vector3 offset; // Desplazamiento respecto al objeto padre
    public Button button; // Botón de Unity que activa o desactiva el parentesco

    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Transform originalParent;

    // Variable estática para llevar la cuenta del último botón pulsado
    private static SelfParentingButton lastButtonPressed;

    void Start()
    {
        // Guardar la posición, rotación y parentesco original del objeto hijo
        originalPosition = childObject.transform.position;
        originalRotation = childObject.transform.rotation;
        originalParent = childObject.transform.parent;

        // Asignar el método ToggleParenting al evento onClick del botón
        button.onClick.AddListener(ToggleParenting);
    }

    public void ToggleParenting()
    {
        // Si se ha pulsado un botón antes, desactivarlo
        if (lastButtonPressed != null && lastButtonPressed != this)
        {
            lastButtonPressed.Deactivate();
        }

        // Si este botón ya está activo, desactivarlo
        if (lastButtonPressed == this)
        {
            Deactivate();
            lastButtonPressed = null;
            return;
        }

        // Activar este botón y hacerlo el último pulsado
        Activate();
        lastButtonPressed = this;
    }

    private void Activate()
    {
        childObject.transform.SetParent(transform);
        childObject.transform.localPosition = offset; // Ajustar la posición en relación con el padre
    }

    private void Deactivate()
    {
        childObject.transform.SetParent(originalParent);
        childObject.transform.position = originalPosition;
        childObject.transform.rotation = originalRotation;
    }
}
