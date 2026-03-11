using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class testebotao : MonoBehaviour
{
    // Start is called before the first frame update
    onclick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene());
        Debug.Log("Botão clicado!");
    }
    

    void carregarCena()
    {
        SceneManager.LoadScene("", LoadSceneMode.Single);
    }
}


