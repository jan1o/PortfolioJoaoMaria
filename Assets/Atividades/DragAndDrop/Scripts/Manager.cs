using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    public List<InsertField> insertFields;
    public List<DragAndDropSprite> dragAndDrops;

    public int proximaCena;
    private int qtdFields;
    public int acertos;

    public GameObject btnProximo;

    // Start is called before the first frame update
    void Start()
    {
        btnProximo.SetActive(false);

        insertFields = new List<InsertField>();
        foreach(InsertField item in FindObjectsOfType<InsertField>())
        {
            insertFields.Add(item);
        }

        dragAndDrops = new List<DragAndDropSprite>();
        foreach (DragAndDropSprite item in FindObjectsOfType<DragAndDropSprite>())
        {
            dragAndDrops.Add(item);
        }

        AssertCodigos();

        qtdFields = insertFields.Count; 
    }

    private void AssertCodigos()
    {
        foreach(InsertField x in insertFields)
        {
            foreach(DragAndDropSprite y in dragAndDrops)
            {
                if(x.codigo == y.codigo)
                {
                    x.AjustarTamanho(y.GetNumCaracteres());
                }
            }
        }
    }

    //soma 1 se acertou e diminui 1 se tirou um campo correto do lugar.
    public void RegistrarAcerto(int valor)
    {
        //Alterar barra de progresso
        int qtd = insertFields.Count;
        BarraProgressao barra = FindObjectOfType<BarraProgressao>();
        if(valor > 0)
        {
            barra.AlterarValor(100/qtd);
        }
        else
        {
            barra.AlterarValor((100/qtd)*-1);
        }
        

        acertos += valor;
        if(acertos == qtdFields)
        {
            InvertButtonNextActivity();
        }
    }

    public void InvertButtonNextActivity()
    {
        btnProximo.SetActive(!btnProximo.activeSelf);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(proximaCena);
    } 

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
