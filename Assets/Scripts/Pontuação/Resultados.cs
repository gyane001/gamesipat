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
        if (acertos <= 3)
        {
            textoTitulo.text = "Perfil: Vulnerável";
            textoDescricao.text = "Você demonstrou que ainda existem lacunas importantes no seu conhecimento e nas suas atitudes relacionadas à segurança. Isso não significa falta de capacidade, mas sim uma oportunidade clara de aprendizado e mudança de comportamento.";
        }
        else if (acertos <= 8)
        {
            textoTitulo.text = "Perfil: Cauteloso";
            textoDescricao.text = "Você demonstrou um bom nível de conhecimento e consciência em segurança, aplicando corretamente muitos conceitos importantes no seu dia a dia. Suas escolhas indicam responsabilidade e atenção aos riscos..";
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