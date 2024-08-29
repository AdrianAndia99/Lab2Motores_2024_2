using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BarraVida : MonoBehaviour
{
    [SerializeField]private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void CambiarVidaMaxima(float vidaMax)
    {
        slider.maxValue = vidaMax;
    }

    public void CambiarVidaActual(float cantidadVida)
    {
        slider.value = cantidadVida;
    }

    public void IniciarBarra(float cantidadVid)
    {
        CambiarVidaMaxima(cantidadVid);
        CambiarVidaActual(cantidadVid);
    }
}