using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{

    public int proximaCena;
    public int menu;

    public GameObject painelTextos;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void RegistrarAcerto(int valor)
    {
        
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(proximaCena);
    }

    public void InvertPanelActivity()
    {
        painelTextos.SetActive(!painelTextos.activeSelf);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(menu);
    }
}
