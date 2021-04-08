using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragPuzzle : MonoBehaviour
{

    public int codigo;

    private bool isInField = false;
    private Transform fieldTransform;

    [SerializeField] private Camera cameraPrincipal;
    [SerializeField] private Rigidbody2D rb;

    public bool estaDentro;
    public bool estaArrastando;

    private bool foiTocado;

    public bool campoCorreto;

    // Start is called before the first frame update
    void Start()
    {
        cameraPrincipal = FindObjectOfType<Camera>();
        rb = GetComponent<Rigidbody2D>();

        campoCorreto = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Desktop
        if (estaDentro && Input.GetKeyDown(KeyCode.Mouse0))
        {
            estaArrastando = true;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            estaArrastando = false;
        }

        // Esse if funciona para os dois
        if (isInField)
        {
            GetComponent<Transform>().position = fieldTransform.position;
            estaArrastando = false;
            isInField = false;
        }

        //Android
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.Equals(GetComponent<RectTransform>()))
            {
                //Vector3 touchPosition = cameraPrincipal.ScreenToWorldPoint(touch.position);
                foiTocado = true;
            }
        }
        if (foiTocado)
        {
            Touch touch = Input.GetTouch(0);
            transform.position = cameraPrincipal.ScreenToWorldPoint(touch.position);
        }
    }

    void FixedUpdate()
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        this.fieldTransform = other.GetComponent<Transform>();
        this.isInField = true;

        InsertPoint point = other.GetComponent<InsertPoint>();
        if (point.codigo == this.codigo)
        {
            if (!campoCorreto)
            {
                campoCorreto = true;
                QCManager man = FindObjectOfType<QCManager>();
                man.RegistrarAcerto(1);
            }
        }
        else
        {
            if (campoCorreto)
            {
                campoCorreto = false;
                QCManager man = FindObjectOfType<QCManager>();
                man.RegistrarAcerto(-1);
            }
        }
    }
}
