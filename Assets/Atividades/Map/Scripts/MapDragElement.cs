using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MapDragElement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Camera cameraPrincipal;

    private bool estaDentro;
    private bool estaArrastando;

    void Start()
    {
        cameraPrincipal = FindObjectOfType<Camera>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (estaDentro && Input.GetKeyDown(KeyCode.Mouse0))
        {
            estaArrastando = true;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            estaArrastando = false;
        }
    }

    private void FixedUpdate()
    {
        if (estaArrastando)
        {
            rb.MovePosition(cameraPrincipal.ScreenToWorldPoint(Input.mousePosition));
        }
    }

    private void OnMouseOver()
    {
        estaDentro = true;
    }

    private void OnMouseExit()
    {
        estaDentro = false;
    }
}
