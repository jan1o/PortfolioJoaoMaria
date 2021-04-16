using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class S1Manager : MonoBehaviour
{

    public List<Image> images;
    public List<Sprite> sprites;

    public Sprite desenhoCorreto;

    public int proximaCena;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Sprite s in sprites)
        {
            images[sprites.IndexOf(s)].sprite = s;
        }
    }

    public void Click(Image img)
    {
        if(img.sprite == desenhoCorreto)
        {
            Debug.Log("Ok");
            NextScene();
        }
        else
        {
            Debug.Log("ok");
            //Alerta de erro
        }
    }

    public void NextScene()
    {
        SceneManager.LoadScene(proximaCena);
    }
}
