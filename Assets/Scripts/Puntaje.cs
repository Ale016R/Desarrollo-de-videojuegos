using UnityEngine;
using System;

public class Puntaje : MonoBehaviour
{
    [SerializeField] private int puntos = 0;
    public event Action alActualizarPuntaje;

    public void AumentarPuntos(int cantidad)
    {
        puntos += cantidad;
        alActualizarPuntaje?.Invoke();
    }

    public int ObtenerPuntos()
    {
        return puntos;
    }
}
