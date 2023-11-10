using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Teleport : MonoBehaviour
{
    public Transform objetoPadre;
    public GameObject objetoHijo;

    public GameObject Piso;
    public void TaskOnClick()
    {
        // Establece la posición del objetoHijo a la posición del objetoPadre.
        objetoHijo.transform.position = objetoPadre.transform.position;

        // Establece el objetoPadre como el padre del objetoHijo.
        objetoHijo.transform.SetParent(objetoPadre.transform);

        Floor();

    }

    public void Floor() {

        // Obtener escalas del padre
        Transform transformObjetoPadre = objetoPadre.transform;

        // Obtener el componente Transform del GameObject
        Transform transformComponentPiso = Piso.transform;

        Vector3 scaleObjetoPadre = transformObjetoPadre.localScale;
        Vector3 scaleObjetoPiso = transformComponentPiso.localScale;

        // Calcular las proporciones
        float proporcionX = scaleObjetoPadre.x * 2;
        float proporcionY = scaleObjetoPadre.y * 1.5f;
        float proporcionZ = scaleObjetoPadre.z * 2;

        // Aplicar las proporciones para adaptar la escala
        Piso.transform.localScale = new Vector3(
            scaleObjetoPiso.x * proporcionX,
            scaleObjetoPiso.y * proporcionY,
            scaleObjetoPiso.z * proporcionZ
        );

        // Establece la posición del objetoHijo a la posición del objetoPadre.
        Piso.transform.position = objetoPadre.transform.position;

        // Establece el objetoPadre como el padre del objetoHijo.
        Piso.transform.SetParent(objetoPadre.transform);
    }
}
