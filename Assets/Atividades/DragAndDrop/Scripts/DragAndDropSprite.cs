using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropSprite : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int codigo;

    private bool isInField = false;
    private Transform fieldTransform;

    [SerializeField] private Camera cameraPrincipal;
    [SerializeField] private Canvas canvas;

    private bool estaDentro;
    private bool estaArrastando;

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

        if (isInField)
        {
            GetComponent<RectTransform>().position = fieldTransform.position;
            estaArrastando = false;
            isInField = false;
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
        Debug.Log("teste1");

        this.fieldTransform = other.GetComponent<Transform>();
        this.isInField = true;
    }

}
