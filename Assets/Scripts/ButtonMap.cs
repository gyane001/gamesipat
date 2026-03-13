using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BotaoMapa : MonoBehaviour
{
    [Header("Configuração")]
    public string nomeDaCena; // Digite o nome da fase aqui no Inspetor

    void Start()
    {
        // Pega o componente de botão automaticamente
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

public int caminhoEscolhido = 0; // 1 para PF_1, 2 para PF_2
   public void IrParaProximaFase()
    {
        string cenaAtual = SceneManager.GetActiveScene().name;

        if (caminhoEscolhido == 1)
        {
            if (cenaAtual == "PF_1") SceneManager.LoadScene("Adm");
            else if (cenaAtual == "Adm") SceneManager.LoadScene("FimDeJogo");
        }
        else if (caminhoEscolhido == 2)
        {
            if (cenaAtual == "PF_2") SceneManager.LoadScene("Fabrica");
            else if (cenaAtual == "Fabrica") SceneManager.LoadScene("FimDeJogo");
        }
    }

}

