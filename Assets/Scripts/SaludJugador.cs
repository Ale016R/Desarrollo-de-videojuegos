using UnityEngine;
using UnityEngine.Events;

public class SaludJugador : MonoBehaviour
{
    [SerializeField] private int saludMaxima = 3;
    [SerializeField] private float tiempoInvulnerable = 1f;
    [SerializeField] private Vector2 puntoRespawn = Vector2.zero;

    private int saludActual;
    private bool esInvulnerable = false;
    private float tiempoInvulnerableRestante;

    public UnityEvent alRecibirDaño;
    public UnityEvent alMorir;

    private void Start()
    {
        saludActual = saludMaxima;
    }

    private void Update()
    {
        if (esInvulnerable)
        {
            tiempoInvulnerableRestante -= Time.deltaTime;
            if (tiempoInvulnerableRestante <= 0)
            {
                esInvulnerable = false;
            }
        }
    }

    public void RecibirDaño(int cantidad)
    {
        if (esInvulnerable) return;

        saludActual -= cantidad;
        Debug.Log("Salud restante: " + saludActual);

        if (saludActual <= 0)
        {
            Morir();
        }
        else
        {
            // Activar invulnerabilidad temporal
            esInvulnerable = true;
            tiempoInvulnerableRestante = tiempoInvulnerable;
            alRecibirDaño?.Invoke();
        }
    }

    private void Morir()
    {
        Debug.Log("¡Jugador muerto!");
        alMorir?.Invoke();
        Respawn();
    }

    private void Respawn()
    {
        transform.position = puntoRespawn;
        saludActual = saludMaxima;
    }

    public void SetPuntoRespawn(Vector2 nuevoPunto)
    {
        puntoRespawn = nuevoPunto;
    }
}