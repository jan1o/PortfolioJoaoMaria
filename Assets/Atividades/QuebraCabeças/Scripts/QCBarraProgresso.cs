using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QCBarraProgresso : MonoBehaviour
{

    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponentInChildren<Slider>();
        slider.value = slider.minValue;
    }

    public void AlterarValor(float valor)
    {
        slider.value += valor;
    }

}
