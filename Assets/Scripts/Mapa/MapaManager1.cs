using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapaManager_1 : MonoBehaviour
{
    public bool isBarrier = false;
    [Header("Transição de Cena")]
    public Animator transition;
    public float transitionTime = 1f;

    public void CarregarFase(string nomeDaFase)
    {
        SceneManager.LoadScene(nomeDaFase);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        StartCoroutine(LoadSceneWithTransition());
    }

    private IEnumerator LoadSceneWithTransition()
    {
       

        if (SceneManager.GetActiveScene().name == "PF_1")
        {
             if (transition != null)
        {
            transition.SetTrigger("Start");
            yield return new WaitForSeconds(transitionTime);
        }
            SceneManager.LoadScene("Adm");
        }
        else if (SceneManager.GetActiveScene().name == "Adm")
        {
             if (transition != null)
        {
            transition.SetTrigger("Start");
            yield return new WaitForSeconds(transitionTime);
        }
            SceneManager.LoadScene("Adm 1");
        }

         else if (SceneManager.GetActiveScene().name == "Adm")
        {
             if (transition != null)
        {
            transition.SetTrigger("Start");
            yield return new WaitForSeconds(transitionTime);
        }
            SceneManager.LoadScene("FimDeJogo");
        }
    }
}