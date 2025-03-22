using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlJugador : MonoBehaviour
{
    private Movimiento movimiento;
    private Vector2 entradaControl;
    private LanzaProyectiles lanzaProyectiles; 

    void Start()
    {
        movimiento = GetComponent<Movimiento>();
        lanzaProyectiles = GetComponent<LanzaProyectiles>();

    }

    void Update()
    {
            movimiento.Moverse(entradaControl.x);
            movimiento.MoverseVertical(entradaControl.y);
            movimiento.Escalar(entradaControl.y);
            if (Mathf.Abs(entradaControl.x) > Mathf.Epsilon)
            {
                movimiento.VoltearTransform(entradaControl.x);
            }

    }
    public void AlMoverse(InputAction.CallbackContext context)
    {
        entradaControl = context.ReadValue<Vector2>();
    }

    public void AlSaltar(InputAction.CallbackContext context)
    {
        movimiento.Saltar(context.action.triggered);
    }

    public void AlLanzar(InputAction.CallbackContext context)
    {
        if (!context.action.triggered)
        {
            return;
        }
        lanzaProyectiles.Lanzar();
    }

}