using UnityEngine;
using TMPro; // Importante para o texto
using UnityEngine.SceneManagement;

public class Resultados : MonoBehaviour
{
    [Header("Referências de UI")]
    [SerializeField] private TextMeshProUGUI textoTitulo;
    [SerializeField] private TextMeshProUGUI textoDescricao;
    [SerializeField] private TextMeshProUGUI textoDesafio;
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
        if (acertos <= 3)
        {
            textoTitulo.text = "Perfil Ruim";
            textoDescricao.text = "Ainda existem pontos importantes para desenvolver no conhecimento e nas atitudes de segurança. Reforce os conceitos, mantenha a atenção no dia a dia e transforme aprendizado em prática.";
            textoDescricao.text += "\n\n\nDesafio: Aprenda com os erros e faça da segurança um hábito diário";
        }

        else if (acertos <= 8)
        {
            textoTitulo.text = "Perfil Bom";
            textoDescricao.text = "Demonstrou bom conhecimento e consciência em segurança, com atitudes responsáveis no dia a dia. Continue atento aos detalhes, reforçando boas práticas e evoluindo continuamente.";
            textoDescricao.text += "\n\n\nDesafio: Mantenha sua postura segura e seja exemplo para os colegas.";
        }
        else
        {
            textoTitulo.text = "Perfil Especialista";
            textoDescricao.text = "Parabéns! Você acertou todas as respostas e demonstrou excelente conhecimento, responsabilidade e atitude em segurança. Suas escolhas mostram consciência dos riscos e compromisso com o cuidado próprio e coletivo.";
            textoDescricao.text += "\n\nDesafio: Continue sendo exemplo e incentivando a cultura de segurança no dia a dia.";
        }
    }


    public void ReiniciarJogo()
    {
        GameData.totalWins = 0; // Resetamos os pontos para começar de novo
        SceneManager.LoadScene("MenuPrincipal"); // Substitua pelo nome da sua cena de menu
    }
}