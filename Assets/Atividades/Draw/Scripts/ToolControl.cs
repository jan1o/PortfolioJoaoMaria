using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if(gameObject.name == "Borracha")
        {
            PaintGM.toolType = "eraser";
        }
        
        else if(gameObject.name == "Lapis")
        {
            PaintGM.toolType = "pencil";
        }
    }
}
