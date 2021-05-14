using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{

    public List<MapField> mapFields;
    public List<MapDragElement> dragAndDrops;

    public int proximaCena;
    private int qtdFields;
    public int acertos;

    // Start is called before the first frame update
    void Start()
    {
        mapFields = new List<MapField>();
        foreach (MapField item in FindObjectsOfType<MapField>())
        {
            mapFields.Add(item);
        }

        dragAndDrops = new List<MapDragElement>();
        foreach (MapDragElement item in FindObjectsOfType<MapDragElement>())
        {
            dragAndDrops.Add(item);
        }

        qtdFields = mapFields.Count;
    }

    public void RegistrarAcerto(int valor)
    {
        //Alterar barra de progresso
        int qtd = mapFields.Count;
        BarraProgressao barra = FindObjectOfType<BarraProgressao>();
        if (valor > 0)
        {
            barra.AlterarValor(100 / qtd);
        }
        else
        {
            barra.AlterarValor((100 / qtd) * -1);
        }


        acertos += valor;
        if (acertos == qtdFields)
        {
            NextLevel();
        }
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(proximaCena);
    }


}
