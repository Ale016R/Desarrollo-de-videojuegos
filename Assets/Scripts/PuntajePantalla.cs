using UnityEngine;
using TMPro;

public class PuntajePantalla : MonoBehaviour
{
    [SerializeField] private Puntaje puntaje;
    [SerializeField] private TextMeshProUGUI textoPuntos;

    private void OnEnable()
    {
        puntaje.alActualizarPuntaje += ActualizarPuntos;
    }

    private void OnDisable()
    {
        puntaje.alActualizarPuntaje -= ActualizarPuntos;
    }

    private void Start()
    {
        ActualizarPuntos(); // Mostrar el valor inicial
    }

    private void ActualizarPuntos()
    {
        textoPuntos.text = "Puntos: " + puntaje.ObtenerPuntos();
    }
}
