using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PaintGM : MonoBehaviour
{

    public Transform baseDot;
    public KeyCode mouseLeft;
    public static string toolType;

    public int proximaCena;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        if (Input.GetKey(mouseLeft))
        {
            Instantiate(baseDot, objPosition, baseDot.rotation);
        }
    }

    public void NextScene()
    {
        SceneManager.LoadScene(proximaCena);
    }
}
