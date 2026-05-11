using UnityEngine;
using TMPro; // Importante para o texto
using UnityEngine.SceneManagement;

public class Resultados : MonoBehaviour
{
    [Header("Referências de UI")]
    [SerializeField] private TextMeshProUGUI textoTitulo;
    [SerializeField] private TextMeshProUGUI textoDescricao;
    [SerializeField] private TextMeshProUGUI textoContador;

    private void Start()
    {
        ExibirResultado();
    }

    public void ExibirResultado()
    {
        int acertos = GameData.totalWins;
        textoContador.text = $"Você acertou {acertos} questões!";

        // Lógica de filtragem de perfil
        if (acertos <= 2)
        {
            textoTitulo.text = "Perfil: Vulnerável";
            textoDescricao.text = "Cuidado! Você não verifica a segurança do ambiente. Recomenda-se ser mais cauteloso.";
        }
        else if (acertos <= 5)
        {
            textoTitulo.text = "Perfil: Cauteloso";
            textoDescricao.text = "Bom trabalho! Você conhece o básico de segurança, mas ainda tem pontos a melhorar.";
        }
        else
        {
            textoTitulo.text = "Perfil: Especialista";
            textoDescricao.text = "Parabéns! Você é um mestre da segurança. Suas escolhas protegem você e seus colegas.";
        }
        }

    public void ReiniciarJogo()
    {
        GameData.totalWins = 0; // Resetamos os pontos para começar de novo
        SceneManager.LoadScene("MenuPrincipal"); // Substitua pelo nome da sua cena de menu
    }
}