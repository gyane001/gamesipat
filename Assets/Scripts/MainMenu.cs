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
        StartCoroutine(CarregarCena(nomeDaFase));
    }

    public void VoltarParaMenu()
    {
        Debug.Log("Game retornando ao menu!");
        GameData.totalWins = 0;
        StartCoroutine(CarregarCena("Menu"));
    }

    public void ReiniciarJogo()
    {
        GameData.totalWins = 0;
        StartCoroutine(CarregarCena("Menu"));
    }

    public void QuitGame()
    {
        Debug.Log("O jogo fechou!");
        StartCoroutine(SairDoJogo());
    }

    private IEnumerator CarregarCena(string nomeDaFase)
    {
        if (transition != null)
        {
            transition.SetTrigger("Start");
            yield return new WaitForSeconds(transitionTime);
        }

        SceneManager.LoadScene(nomeDaFase);
    }

    private IEnumerator SairDoJogo()
    {
        if (transition != null)
        {
            transition.SetTrigger("Start");
            yield return new WaitForSeconds(transitionTime);
        }

        Application.Quit();
    }
}