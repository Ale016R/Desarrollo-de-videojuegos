using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemigo : MonoBehaviour
{
    [Header("Ground Detection")]
    [SerializeField] private Transform Detector;
    [SerializeField] private float distanciaAlSuelo = 0.3f;
    [SerializeField] private LayerMask layerSuelo;

    Movimiento movimiento;
    Vector2 direccionMovimiento;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movimiento = GetComponent<Movimiento>();
        direccionMovimiento = new Vector2(1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        movimiento.VoltearTransform(direccionMovimiento.x);
        DetectarSuelo();
        movimiento.Moverse(direccionMovimiento.x);
    }

    void DetectarSuelo() 
    {
        RaycastHit2D hit = Physics2D.Raycast(Detector.position, Vector2.down, distanciaAlSuelo, layerSuelo);
        if (hit.collider == null)
        {
            direccionMovimiento.x *= -1f;
        }
    }
}

