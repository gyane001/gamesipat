using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    [Header("Configuração da Barreira")]
    [Tooltip("Marque se este objeto for a barreira final.")]
    public bool isBarrier = false;
    [Tooltip("Nome da cena para carregar se TODOS os NPCs forem vencidos.")]
    public string sceneToLoad;

    [Header("Configuração do NPC")]
    [Tooltip("Marque isso se este NPC faz parte do desafio (o jogador precisa acertar o quiz dele para passar).")]
    public bool fazParteDoQuiz = false;

    [Header("Status (Automático)")]
    // Define se o player acertou a pergunta DESTE NPC específico
    public bool acertouQuiz = false;

    private bool playerInRange;
    public Button mobileButton;

    private void Awake()
    {
        playerInRange = false;
        if (visualCue != null) visualCue.SetActive(false);

        GameObject btnObj = GameObject.Find("BotaoInteragirMobile");
        if (btnObj != null)
        {
            mobileButton = btnObj.GetComponent<Button>();
        }
    }

    private void Update()
    {
        // Se for barreira, não mostra o visual cue, pois a interação é automática via colisão
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying && !isBarrier)
        {
            if (visualCue != null) visualCue.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                StartDialogue();
            }
        }
        else
        {
            if (visualCue != null) visualCue.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
{
    if (collider.CompareTag("Player"))
    {
        playerInRange = true;

        if (isBarrier)
        {
            if (VerificarTodosOsQuizzes())
            {
                SceneManager.LoadScene(sceneToLoad);
            }
            else
            {
                StartDialogue();
            }
        }
        else
        {
            // ✅ Inicia o diálogo direto pela colisão, sem precisar do botão
            StartDialogue();
        }
        
    }
}

private void OnTriggerExit2D(Collider2D collider)
{
    if (collider.CompareTag("Player"))
    {
        playerInRange = false;
        // Nada mais necessário aqui, já que o botão foi removido
    }
}

    // --- COROUTINE MOVIDA PARA O LUGAR CERTO ---
    IEnumerator LoadLevel(int levelIndex)
    {
        // Verifica se a transição existe para evitar erros
        if (transition != null)
        {
            transition.SetTrigger("Start");
        }

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

private void StartDialogue()
{
    if (DialogueManager.GetInstance().dialogueIsPlaying) return;

    DialogueManager.GetInstance().EnterDialogueMode(inkJSON, this);

    if (mobileButton != null) mobileButton.gameObject.SetActive(false);

    // Desativa o collider ao fim do diálogo para impedir re-interação
    if (fazParteDoQuiz)
        StartCoroutine(DesativarAposDialogo());
}

private IEnumerator DesativarAposDialogo()
{
    // Aguarda o diálogo terminar
    yield return new WaitUntil(() => !DialogueManager.GetInstance().dialogueIsPlaying);

    // Desativa o collider para bloquear futuras colisões/interações
    Collider2D col = GetComponent<Collider2D>();
    if (col != null) col.enabled = false;
    gameObject.SetActive(false);

    // Opcional: esconde o visual cue também
    if (visualCue != null) visualCue.SetActive(false);
}

    // --- FUNÇÃO PARA VERIFICAR TODOS OS NPCS ---
private bool VerificarTodosOsQuizzes()
{
    // "true" faz ele encontrar objetos desativados também
    DialogueTrigger[] todosNPCs = FindObjectsOfType<DialogueTrigger>(true);

    foreach (DialogueTrigger npc in todosNPCs)
    {
        if (npc == this) continue;

        if (npc.fazParteDoQuiz && !npc.acertouQuiz)
        {
            Debug.Log("O jogador ainda não passou pelo NPC: " + npc.gameObject.name);
            return false;
        }
    }

    return true;
}
}