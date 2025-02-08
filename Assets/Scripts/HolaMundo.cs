using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class HolaMundo : MonoBehaviour
{
    [SerializeField] private string mensaje;


    public void Saludar()
    {
        Debug.Log(mensaje);
    }
}
