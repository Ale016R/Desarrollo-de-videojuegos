using UnityEngine;

public class ControlCuadrado : MonoBehaviour
{
    private HolaMundo holaMundo; 

    void Start()
    {
      
        holaMundo = GetComponent<HolaMundo>();

        if (holaMundo != null)
        {
            holaMundo.Saludar();
        }
        else
        {
            Debug.LogError("El componente HolaMundo no está asignado en el GameObject.");
        }
    }
}
