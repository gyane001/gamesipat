using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Transição de Cena")]
    public Animator transition;
    public float transitionTime = 1f;

    public void PlayGame(string nomeDaFase)
    {
        Debug.Log("Clique registrado: " + Time.realtimeSinceStartup);
        StartCoroutine(LoadLevel(nomeDaFase));
    }

    public void VoltarParaMenu()
    {
        Debug.Log("Game retornando ao menu!");
        StartCoroutine(LoadLevel("Menu"));
    }

    public void ReiniciarJogo()
    {
        GameData.totalWins = 0;
        StartCoroutine(LoadLevel("Menu"));
    }

    public void QuitGame()
    {
        Debug.Log("O jogo fechou!");
        Application.Quit();
    }

    private IEnumerator LoadLevel(string nomeDaFase)
    {
        if (transition != null)
            transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(nomeDaFase);
    }
<<<<<<< HEAD
}
=======

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

>>>>>>> parent of 777af7e (ajustado sistema de dialogos)
