using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlJugador : MonoBehaviour
{
    private Movimiento movimiento;
    private Vector2 entradaControl;

    void Start()
    {
        movimiento = GetComponent<Movimiento>();

    }

    void Update()
    {
            movimiento.Moverse(entradaControl.x);
            movimiento.MoverseVertical(entradaControl.y);
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

}