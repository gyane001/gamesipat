using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class testebotao : MonoBehaviour
{
    // Start is called before the first frame update
    onclick()
    {
        meuBotao.onClick.AddListener(carregarCena);
        Debug.Log("Botão clicado!");
    }
    

    void carregarCena()
    {
        SceneManager.LoadScene("CenaDesejada", LoadSceneMode.Single);
    }
}
