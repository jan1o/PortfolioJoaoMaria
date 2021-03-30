using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsertField : MonoBehaviour
{
    public int codigo;

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
