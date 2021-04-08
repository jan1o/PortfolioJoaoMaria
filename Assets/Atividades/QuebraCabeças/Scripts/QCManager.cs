using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QCManager : MonoBehaviour
{

    public List<InsertPoint> insertPoints;
    public List<DragPuzzle> dragPuzzles;

    public int nextScene;
    private int qtdPoints;
    public int acertos;

    // Start is called before the first frame update
    void Start()
    {
        insertPoints = new List<InsertPoint>();
        foreach (InsertPoint item in FindObjectsOfType<InsertPoint>())
        {
            insertPoints.Add(item);
        }

        dragPuzzles = new List<DragPuzzle>();
        foreach (DragPuzzle item in FindObjectsOfType<DragPuzzle>())
        {
            dragPuzzles.Add(item);
        }

        qtdPoints = insertPoints.Count;
    }

    public void RegistrarAcerto(int valor)
    {
        //Alterar barra de progresso
        int qtd = insertPoints.Count;
        QCBarraProgresso barra = FindObjectOfType<QCBarraProgresso>();
        if (valor > 0)
        {
            barra.AlterarValor(100 / qtd);
        }
        else
        {
            barra.AlterarValor((100 / qtd) * -1);
        }


        acertos += valor;
        if (acertos == qtdPoints)
        {
            NextLevel();
        }
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(nextScene);
    }

}
