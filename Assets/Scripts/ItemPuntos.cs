using UnityEngine;

public class ItemPuntos : MonoBehaviour
{
    [SerializeField] private int puntosOtorgados = 1;
    [SerializeField] private AudioClip audioClip;

    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;
    private Collider2D collider2D;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Puntaje puntaje = collision.GetComponent<Puntaje>();
        if (puntaje != null)
        {
            puntaje.AumentarPuntos(puntosOtorgados);
            ReproducirSonidoYDestruir();
        }
    }

    private void ReproducirSonidoYDestruir()
    {
        if (audioClip == null || audioSource == null)
        {
            Destroy(gameObject);
            return;
        }

        spriteRenderer.enabled = false;
        collider2D.enabled = false;
        audioSource.PlayOneShot(audioClip);
        Destroy(gameObject, audioClip.length);
    }
}
