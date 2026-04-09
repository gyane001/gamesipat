using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Unity.VisualScripting;

public class DialogueManager : MonoBehaviour
{
    [Header("Parâmetros de Diálogo")]
    [SerializeField] private float typingSpeed = 0.03f; // Aumentei um pouco, 0.001 é muito rápido

    // Variável que controla se o player pode avançar
    private bool canContinueToNextLine = false;

    [Header("UI do Diálogo")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [SerializeField] private Animator portraitAnimator;
    [SerializeField] private GameObject continueIcon; // A setinha que pisca

    [Header("UI de Escolhas")]
    [SerializeField] private GameObject[] choices;
    [SerializeField] private Text[] choicesText;

    private Story currentStory;
    private DialogueTrigger npcAtual;

    public bool dialogueIsPlaying { get; private set; }

    private static DialogueManager instance;

    // Constantes de Tags
    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
    // private const string LAYOUT_TAG = "layout"; // Removido pois não estava sendo usado no exemplo
    private const string WIN_TAG = "win";
    public int scoreTotal = 0;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Mais de um Dialogue Manager encontrado!");
        }
        instance = this;
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        // Garante que o ícone e as escolhas começam escondidos
        if (continueIcon != null) continueIcon.SetActive(false);
    }

    private void Update()
    {
        // Se não está tocando, não faz nada
        if (!dialogueIsPlaying) return;

        // A LÓGICA CORRIGIDA ESTÁ AQUI:
        // Só entra se:
        // 1. O texto terminou de digitar (canContinueToNextLine)
        // 2. NÃO tem escolhas na tela (currentChoices.Count == 0)
        // 3. O jogador apertou o botão (Teclado OU Mouse)
        if (canContinueToNextLine
            && currentStory.currentChoices.Count == 0
            && (Input.GetButtonDown("Submit") || Input.GetMouseButtonDown(0))) // PARENTESES SÃO ESSENCIAIS AQUI
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON, DialogueTrigger npc)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        npcAtual = npc;

        // Reseta as tags para o padrão antes de começar

        if (portraitAnimator != null) portraitAnimator.Play("default");

        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";


        if (continueIcon != null) continueIcon.SetActive(false);
    }

    private void ContinueStory()
    {
        // Passo 1: Verifica se pode continuar
        if (currentStory.canContinue)
        {
            // Começa a digitar a linha (A Corrotina cuida de exibir as escolhas depois)
            StartCoroutine(DisplayLine(currentStory.Continue()));

            // Processa as tags (nome, retrato)
            HandleTags(currentStory.currentTags);
        }
        else
        {
            // Se não pode continuar, sai do modo diálogo
            ExitDialogueMode();
        }
    }

    private IEnumerator DisplayLine(string line)
    {
        // Limpa o texto anterior
        dialogueText.text = "";

        // Esconde botões de escolha e ícone de continuar enquanto digita
        HideChoices();
        if (continueIcon != null) continueIcon.SetActive(false);

        // Bloqueia o avanço
        canContinueToNextLine = false;

        // Digita letra por letra
        foreach (char letter in line.ToCharArray())
        {
            // Se o jogador clicar ENQUANTO digita, você pode implementar um "skip" aqui futuramente
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        // Texto terminou de digitar: Libera o avanço
        canContinueToNextLine = true;

        // AGORA verificamos se existem escolhas para mostrar
        if (currentStory.currentChoices.Count > 0)
        {
            DisplayChoices();
        }
        else
        {
            // Se não tem escolhas, mostra a setinha para indicar que pode clicar para a próxima frase
            if (continueIcon != null) continueIcon.SetActive(true);
        }
    }

    private void HideChoices()
    {
        foreach (GameObject choiceBtn in choices)
        {
            choiceBtn.SetActive(false);
        }
    }

 private void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            string cleanTag = tag.Trim();

            if (cleanTag == WIN_TAG)
            {
                if (npcAtual != null)
                {
                    npcAtual.acertouQuiz = true;
                    // Debug.Log removido para limpar o console, mas pode descomentar
                }
                continue;
            }

            string[] splitTag = cleanTag.Split(':');
            if (splitTag.Length != 2) continue;

            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case PORTRAIT_TAG:
                    if (portraitAnimator != null) portraitAnimator.Play(tagValue);
                    break;
            }
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("Erro: Mais escolhas no Ink do que botões na UI.");
        }

        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;

            // Configura o botão
            int choiceIndex = index;
            Button btn = choices[index].GetComponent<Button>();

            // É importante limpar listeners antigos
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(() => MakeChoice(choiceIndex));

            index++;
        }

        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice()
    {
        // Corrige bug do EventSystem mantendo seleção antiga
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        if (choices.Length > 0 && choices[0].activeSelf)
        {
            EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        // Só permite escolher se o texto já terminou de digitar
        if (canContinueToNextLine)
        {
            currentStory.ChooseChoiceIndex(choiceIndex);
            ContinueStory();
        }
    }
}