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

            // --- LÓGICA DA BARREIRA ATUALIZADA ---
            if (isBarrier)
            {
                // Verifica se TODOS os NPCs da cena foram vencidos
                if (VerificarTodosOsQuizzes())
                {
                    Debug.Log("Todos os quizzes resolvidos! Carregando cena...");
                    // Carrega a próxima cena baseada no Index atual + 1
                    StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
                }
                else
                {
                    // Se faltar algum, inicia o diálogo da barreira
                    Debug.Log("Acesso negado. O jogador ainda não completou todos os quizzes.");
                    StartDialogue();
                }
            }
            // --- LÓGICA PARA NPC COMUM (Se NÃO for barreira) ---
            else
            {
                if (mobileButton != null)
                {
                    mobileButton.gameObject.SetActive(true);
                    mobileButton.onClick.RemoveAllListeners();
                    mobileButton.onClick.AddListener(StartDialogue);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerInRange = false;

            if (mobileButton != null)
            {
                mobileButton.onClick.RemoveListener(StartDialogue);
                mobileButton.gameObject.SetActive(false);
            }
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
    }

    // --- FUNÇÃO PARA VERIFICAR TODOS OS NPCS ---
    private bool VerificarTodosOsQuizzes()
    {
        // Encontra TODOS os scripts DialogueTrigger ativos na cena
        DialogueTrigger[] todosNPCs = FindObjectsOfType<DialogueTrigger>();

        foreach (DialogueTrigger npc in todosNPCs)
        {
            // Ignora a própria barreira para não dar erro nela mesma
            if (npc == this) continue;

            // Se o NPC faz parte do Quiz E ainda não foi vencido (acertouQuiz é false)
            if (npc.fazParteDoQuiz && !npc.acertouQuiz)
            {
                Debug.Log("O jogador ainda não passou pelo NPC: " + npc.gameObject.name);
                return false; // Retorna falso imediatamente, impedindo a passagem
            }
        }

        // Se o loop terminou e não encontrou ninguém "falso", então todos são verdadeiros
        return true;
    }
}