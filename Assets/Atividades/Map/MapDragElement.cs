using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MapDragElement : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public int codigo;

    [SerializeField] private Camera cameraPrincipal;
    [SerializeField] private Canvas canvas;

    private bool estaDentro;
    private bool estaArrastando;

    private bool foiTocado;

    private bool campoCorreto;
    // Start is called before the first frame update
    void Start()
    {
        cameraPrincipal = FindObjectOfType<Camera>();
        canvas = FindObjectOfType<Canvas>();

        campoCorreto = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (estaDentro && Input.GetKeyDown(KeyCode.Mouse0))
        {
            estaArrastando = true;
        }

        if (estaArrastando)
        {
            transform.position = cameraPrincipal.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, canvas.planeDistance));
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            estaArrastando = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        estaDentro = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        estaDentro = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        MapField field = other.GetComponent<MapField>();
        if (this.codigo == field.codigo)
        { 
            if (!campoCorreto)
            {
                GoToField(other.GetComponent<Transform>());
                campoCorreto = true;
                MapManager man = FindObjectOfType<MapManager>();
                man.RegistrarAcerto(1);
            }
        }
        else
        {
            if (campoCorreto)
            {
                campoCorreto = false;
                MapManager man = FindObjectOfType<MapManager>();
                man.RegistrarAcerto(-1);
            }
        }
    }

    private void GoToField(Transform t)
    {
        GetComponent<RectTransform>().position = t.position;
        estaArrastando = false;
    }
}
