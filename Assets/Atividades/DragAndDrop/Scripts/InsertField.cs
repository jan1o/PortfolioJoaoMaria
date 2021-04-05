using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsertField : MonoBehaviour
{
    public int codigo;
    //public float NumCaracteres; //O tamanho (em caracteres) do seu field;
    private float tamanhoBase; //O tamanho base de um caractere;

    public bool preenchido;

    void Start()
    {
        tamanhoBase = 0.05f;
        preenchido = false;
        /*
        Transform t = GetComponent<Transform>();
        t.localScale = (Vector3) new Vector3((tamanhoBase * NumCaracteres), tamanhoBase, 0); */


    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Letter")
        {
            DragAndDropSprite col = collision.GetComponent<DragAndDropSprite>();
            if (col.codigo == this.codigo)
            {
                collision.GetComponent<Text>().color = Color.green;
                if (!preenchido)
                {
                    preenchido = true;
                    Manager man = FindObjectOfType<Manager>();
                    man.RegistrarAcerto(1);
                }             
            }
            else
            {
                collision.GetComponent<Text>().color = Color.red;
                if (preenchido)
                {
                    preenchido = false;
                    Manager man = FindObjectOfType<Manager>();
                    man.RegistrarAcerto(-1) ;
                }
            }
        }
    }
    */

    public void AjustarTamanho(float numeroCaracteres)
    {
        tamanhoBase = 0.05f;
        Transform t = GetComponent<Transform>();
        t.localScale = (Vector3)new Vector3((tamanhoBase * numeroCaracteres), 0.1f, 0);
    }

}
