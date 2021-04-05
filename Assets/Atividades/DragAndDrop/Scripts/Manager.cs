using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    public List<InsertField> insertFields;
    public List<DragAndDropSprite> dragAndDrops;

    public int nextScene;
    private int qtdFields;
    public int acertos;

    // Start is called before the first frame update
    void Start()
    {
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

    // Update is called once per frame
    void Update()
    {
        
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
        acertos += valor;
        if(acertos == qtdFields)
        {
            NextLevel();
        }
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(nextScene);
    } 
}
