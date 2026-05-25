using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BotaoMapa : MonoBehaviour
{
    [Header("Configuração")]
    public string nomeDaCena;
    //  public int caminhoEscolhido = 0; // 1 para caminho Adm, 2 para caminho Fabrica

    void Start()
    {
        Button btn = GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(TrocarCena);
        }
    }
 
    void TrocarCena()
    {
        if (!string.IsNullOrEmpty(nomeDaCena))
        {
            SceneManager.LoadScene(nomeDaCena);
        }
        else
        {
            Debug.LogError("Erro: Nome da cena vazio no objeto " + gameObject.name);
        }
    }

    public void IrCaminho1()
    {
        //string cenaAtual = SceneManager.GetActiveScene().name
        SceneManager.LoadScene("PF_1");
    }

    public void IrCaminho2()
    {
        //string cenaAtual = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("PF_2");
    }
}