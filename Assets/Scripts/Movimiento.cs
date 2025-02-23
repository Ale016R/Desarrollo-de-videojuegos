using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{

    [SerializeField] private float velocidadCaminata = 4f; 
    [SerializeField] private float alturaSalto = 4f;
    [SerializeField] private float velInicialSalto = 24f;
    [SerializeField] private LayerMask capaDeSalto;

    private BoxCollider2D boxCollider; 

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public void Moverse(float movimientoX)
    {

            rb.linearVelocity = new Vector2(movimientoX * velocidadCaminata, rb.linearVelocity.y);

    }

    public void Saltar(bool debeSaltar)
    {
        if (!boxCollider.IsTouchingLayers(capaDeSalto)) {return; }

        if (debeSaltar)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, velInicialSalto);
        }
    }
}