using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsertField : MonoBehaviour
{
    public int codigo;
    public float NumCaracteres; //O tamanho (em caracteres) do seu field;
    private float tamanhoBase; //O tamanho base de um caractere;

    void Start()
    {
        tamanhoBase = 0.1f;
        Transform t = GetComponent<Transform>();
        t.localScale = (Vector3) new Vector3((tamanhoBase * NumCaracteres), tamanhoBase, 0);


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DragAndDropSprite col = collision.GetComponent<DragAndDropSprite>();
        if (col.codigo == this.codigo)
        { 
            collision.GetComponent<Text>().color = Color.green;
        }
        else
        {
            collision.GetComponent<Text>().color = Color.red;
        }
    }

}
