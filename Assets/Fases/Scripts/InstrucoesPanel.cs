using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrucoesPanel : MonoBehaviour
{
    public GameObject painelInstrucoes;

    // Start is called before the first frame update

    public void InvertPanelActivity()
    {
        painelInstrucoes.SetActive(!painelInstrucoes.activeSelf);
    }
}
