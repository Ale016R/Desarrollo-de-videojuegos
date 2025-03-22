using UnityEngine;

public class Equipo : MonoBehaviour
{
    [SerializeField] EquipoEnum equipo = EquipoEnum.Trampas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public EquipoEnum EquipoActual
    {
        get {return equipo;}
        private set {equipo = value;}
    }
}
