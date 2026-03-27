using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapaManager_1 : MonoBehaviour
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
                SceneManager.LoadScene("Adm");
            }

        }
        if (SceneManager.GetActiveScene().name == "Adm")
        {
            SceneManager.LoadScene("FimDeJogo");
        }
    }
}