using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private Salud salud;
    [SerializeField] private Image barraSalud; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
        salud.alActualizarSalud += ActualizarBarra;
    }

    private void OnDisable()
    {
        salud.alActualizarSalud -= ActualizarBarra;
    }

    private void ActualizarBarra()
    {
        barraSalud.fillAmount = salud.ObtenerFraccion();
    }
}
