using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MM2 : MonoBehaviour
{

    public bool isBarrier = false;

    public void CarregarFase(string nomeDaFase)
    {
        SceneManager.LoadScene(nomeDaFase);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {

            // --- LÓGICA DA BARREIRA ATUALIZADA ---
            if (isBarrier)
            {
                SceneManager.LoadScene("Fabrica");
            }


        }
        if (SceneManager.GetActiveScene().name == "Fabrica")
        {
            SceneManager.LoadScene("FimDeJogo");
        }
    }

}



