using UnityEngine;

public class ItemPuntos : MonoBehaviour
{
    [SerializeField] private int puntosOtorgados = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Puntaje puntaje = collision.GetComponent<Puntaje>();
        if (puntaje != null)
        {
            puntaje.AumentarPuntos(puntosOtorgados);
            Destroy(gameObject);
        }
    }
}
