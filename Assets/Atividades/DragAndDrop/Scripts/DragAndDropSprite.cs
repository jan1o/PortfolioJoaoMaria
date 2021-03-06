using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDropSprite : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int codigo;
    private float numCaracteres;
    private float tamanhoBase;

    [SerializeField] private Camera cameraPrincipal;
    [SerializeField] private Canvas canvas;

    private bool estaDentro;
    private bool estaArrastando;

    private bool foiTocado;

    //Variaveis que dizem se esta no campo correto
    private bool campoCorreto;

    void Start()
    {
        cameraPrincipal = FindObjectOfType<Camera>();
        canvas = FindObjectOfType<Canvas>();

        numCaracteres = ContaCaracteres();
        
        tamanhoBase = 40f;
        RectTransform t = GetComponent<RectTransform>();
        t.sizeDelta = (Vector2) new Vector2((tamanhoBase * numCaracteres), 60f);

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

        if (estaArrastando)
        {
            transform.position = cameraPrincipal.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, canvas.planeDistance));
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            estaArrastando = false;
        }

        //Android
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); 
            if (touch.position.Equals(GetComponent<RectTransform>())){
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
        InsertField field = other.GetComponent<InsertField>();
        if (this.codigo == field.codigo)
        {
            GetComponentInParent<Text>().color = Color.green;
            if (!campoCorreto)
            {
                GoToField(other.GetComponent<Transform>());
                campoCorreto = true;
                Manager man = FindObjectOfType<Manager>();
                man.RegistrarAcerto(1);
            }
        }
        else
        {
            GetComponentInParent<Text>().color = Color.red;
            if (campoCorreto)
            {
                campoCorreto = false;
                Manager man = FindObjectOfType<Manager>();
                man.RegistrarAcerto(-1);
            }
        }
    }

    private void GoToField(Transform t)
    {
        GetComponent<RectTransform>().position = t.position;
        estaArrastando = false;
    }

    public float ContaCaracteres()
    {
        Text text = GetComponent<Text>();
        float num = text.text.Length;
        return num;
    }

    public float GetNumCaracteres()
    {
        float num = ContaCaracteres();
        Debug.Log(num);
        return num;
    }

}
