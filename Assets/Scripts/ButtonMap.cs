using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
public class BotaoMapa : MonoBehaviour
{
    [Header("Configuração")]
    public string nomeDaCena;
    //  public int caminhoEscolhido = 0; // 1 para caminho Adm, 2 para caminho Fabrica
    
    public Animator transition;
    public float transitionTime = 1f;

    void Start()
    {
        Button btn = GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(TrocarCena);
        }
    }
    
public void TrocarCena()
    {
        // Inicia a corrotina
        StartCoroutine(RotinaTrocarCena());
    }

    private IEnumerator RotinaTrocarCena()
    {
        if (transition != null)
        {
            transition.SetTrigger("Start");
            yield return new WaitForSeconds(transitionTime);
        }
        
        SceneManager.LoadScene(nomeDaCena);
    }
}