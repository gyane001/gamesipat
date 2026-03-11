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
}