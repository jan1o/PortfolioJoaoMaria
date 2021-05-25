using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuElemenstsController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IrParaFase(int fase)
    {
        SceneManager.LoadScene(fase);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
