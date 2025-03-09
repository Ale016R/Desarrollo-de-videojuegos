using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] private float velocidadCaminata = 4f; 
    [SerializeField] private float alturaSalto = 4f;
    [SerializeField] private int contadorSaltos = 2;
    [SerializeField] private LayerMask capaDeSalto;
    [SerializeField] private LayerMask capaTrampas;
    [SerializeField] private LayerMask capaEscalera;
    [SerializeField] private LayerMask capaSuelo;
    [SerializeField] private float velocidadEscalada = 4f; 
    private Animator animator;
    private BoxCollider2D boxCollider; 
    private Rigidbody2D rb;
    private float velInicialSalto;
    private SaludJugador saludJugador;
    private bool estaEnEscalera = false;
    private float inputVertical = 0f;
    private float gravedadOriginal;
    private int saltosRestantes;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        saludJugador = GetComponent<SaludJugador>();
        gravedadOriginal = rb.gravityScale;
        float gravedad = Physics2D.gravity.y * rb.gravityScale;
        velInicialSalto = Mathf.Sqrt(-2 * gravedad * alturaSalto);
        saltosRestantes = contadorSaltos; 
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
     
        bool tocandoEscalera = boxCollider.IsTouchingLayers(capaEscalera);

        if (tocandoEscalera && Mathf.Abs(inputVertical) > 0.1f)
        {
            estaEnEscalera = true;
        }
        else if (!tocandoEscalera)
        {
            estaEnEscalera = false;
        }

        if (estaEnEscalera)
        {
            rb.gravityScale = 0f;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, inputVertical * velocidadEscalada);
        }
        else
        {
            rb.gravityScale = gravedadOriginal;
        }

      
        if (boxCollider.IsTouchingLayers(capaTrampas))
        {
            RecibirDaño();
        }
    }

    private void RecibirDaño()
    {
        if (saludJugador != null)
        {
            saludJugador.RecibirDaño(1); 
        }
    }

    public void Moverse(float movimientoX)
    {
        rb.linearVelocity = new Vector2(movimientoX * velocidadCaminata, rb.linearVelocity.y);
        animator.SetBool("estaCorriendo", movimientoX != 0);
    }

   
    public void MoverseVertical(float movimientoY)
    {
        inputVertical = movimientoY;
    }

    public void Saltar(bool debeSaltar)
    {
        if (estaEnEscalera) return;

        bool tocandoSuelo = boxCollider.IsTouchingLayers(capaSuelo);

        if (debeSaltar)
        {
            if (tocandoSuelo) 
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, velInicialSalto);
          
                saltosRestantes = contadorSaltos;
            }
            else if (saltosRestantes > 0) 
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, velInicialSalto);
                saltosRestantes--;
             
                Debug.Log("Saltos extras restantes: " + saltosRestantes);
            }
        }
       

        
    }

    public void VoltearTransform(float movimientoX)
    {
        transform.localScale = new Vector2(
            Mathf.Sign(movimientoX) * Mathf.Abs(transform.localScale.x),
            transform.localScale.y
        );
    }
}