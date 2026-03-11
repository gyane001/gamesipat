using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Variável para referenciar o Painel de Instruções
    public GameObject painelInstrucoes;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("O jogo fechou!");
        Application.Quit();
    }

    // --- NOVAS FUNÇÕES ---

    public void AbrirInstrucoes()
    {
        painelInstrucoes.SetActive(true); // Mostra o painel
    }

    public void FecharInstrucoes()
    {
        painelInstrucoes.SetActive(false); // Esconde o painel
    }
}

