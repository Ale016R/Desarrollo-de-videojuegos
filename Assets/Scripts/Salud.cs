using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Salud : MonoBehaviour
{
    [SerializeField] private float saludMax = 3f;
    [SerializeField] private bool destruirAlMorir = true;
    [SerializeField] private float tiempoEnDestruirse = 0f;
    [SerializeField] private UnityEvent<float> alPerderSalud;
    [SerializeField] private UnityEvent alMorir; 

    private float saludActual;
    private Animator animator;
    private bool estaMuerto = false;

    public event Action alActualizarSalud;

    private void Awake()
    {
        animator = GetComponent<Animator>(); 
        saludActual = saludMax; 
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        alActualizarSalud.Invoke(); 
    }

    public bool EstaMuerto()
    {
        return estaMuerto;
    }

    public float ObtenerFraccion()
    {
        return saludActual / saludMax;
    }

    public float ObtenerSalud()
    {
        return saludActual;
    }

    public void AjustarSalud(float salud)
    {
        saludActual = salud;
        alActualizarSalud.Invoke();
    }

    public void PerderSalud(float saludPerdida)
    {
        saludActual = Mathf.Max(saludActual - saludPerdida, 0);
        alPerderSalud?.Invoke(saludPerdida);
        alActualizarSalud?.Invoke();
        if(saludActual == 0)
        {
            Morir();
        } else {

        }
    }

    private void Morir()
    {
        if (estaMuerto) return; 

        alMorir?.Invoke();
        estaMuerto = true;

        if(destruirAlMorir)
        {
            Destroy(gameObject, tiempoEnDestruirse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
