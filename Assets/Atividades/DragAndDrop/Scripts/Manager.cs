using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public List<InsertField> insertFields;
    public List<DragAndDropSprite> dragAndDrops;

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
}
