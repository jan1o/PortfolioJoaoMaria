using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{

    public int proximaCena;
    public int menu;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void RegistrarAcerto(int valor)
    {
        
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(proximaCena);
    }


}
