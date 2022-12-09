//adiciona bibliotecas próprias do Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//adiciona biblioteca de edição de texto
using TMPro;
//adiciona biblioteca de gerenciamento de cenas
using UnityEngine.SceneManagement;

//cria classe de herança
public class Dialogue : MonoBehaviour
{
    //declara variaveis
    public AudioSource audioFala;
    public AudioListener camera;

    public string proximaFase;

    //variaveis se o dialogo for do objetivo
    [SerializeField]
    private JogadorInterage _jogadorInterage;

    //variaveis se for um dialogo normal

    [SerializeField, TextArea(2, 6)] private string[] dialogueLines;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    public GameObject transicao;
    public GameObject borda;
    public bool fimDialog = false;
    private float typingTime = 0.03f;
    private bool dialogueStart;
    public int lineIndex;
    public Animator cameraZoom;

    //declara propria classe
    public Dialogue dialog;

    //invoca o metodo constantemente
    public void Update()
    {
        //Se o dialogo for desativado
        if(AtivaDialogo.ativaDlg == false)
        {
            //zera a quantidade de linhas lidas 
            lineIndex = 0;
            //para o audio de fala
            audioFala.Stop();
        }
        
        //se o dialogo termina
        if (fimDialog == true)
        {
            //declara variaveis para seus valores iniciais
            dialog.enabled = false;
            audioFala.enabled = false;
            borda.SetActive(false);
            Movimento2.podePular = true;
            Movimento2.moveSpeed = 6.5f;
            cameraZoom.SetBool("IniciaDialog", false);

            //se o dialogo for de interação com um objetivo
            if (CompletaObjetivo.tipoDialog == true)
            {
                //altera variavel
                JogadorInterage.interacao = false;
                //Invoca rotina
                StartCoroutine("ProximaFase");
                
            }
        }
        //Se a interação acontecer
        if (Input.GetButtonDown("Interage"))
        {
            //se o game não for pausado
            if (Pause.isGamePaused == false)
            {
                //se o dialogo não tiver chegado ao fim
                if (fimDialog == false)
                {
                    //se a fala tiver chegado ao fim
                    if (dialogueText.text == dialogueLines[lineIndex])
                    {
                        //invoca rotina
                        NextDialogueLine();
                    }
                    //se a fala não tiver chegado ao fim
                    else
                    {
                        //para todas as rotinas
                        StopAllCoroutines();
                        //insere instantaneamente todo o texto da fala especifica
                        dialogueText.text = dialogueLines[lineIndex];
                        //para o audio de fala
                        audioFala.Stop();
                    }
                }
                //se o dialogo tiver chegado ao fim
                else
                {
                    //para todas as rotinas
                    StopAllCoroutines();
                    //invoca rotina
                    NextDialogueLine();
                }
            }
        }
    }

    // Metodo de dialogo
    public void Dialogo()
    {
        //Se o dialogo iniciar
        if (!dialogueStart)
        {
            //Se ele ainda estiver ativo
            if (fimDialog == false)
            {
                //altera variaveis
                Movimento2.podePular = false;
                Movimento2.moveSpeed = 0;
                borda.SetActive(false);
                dialogueStart = true; 
                dialoguePanel.SetActive(true);
                lineIndex = 0;
                StartCoroutine("ShowLine");
                cameraZoom.SetBool("IniciaDialog", true);
            }
        }
    }

    //Metodo para prosseguir para próxima linha
    private void NextDialogueLine()
    {
        //se o dialog ainda estiver ativo
        if (fimDialog == false)
        {
            //Enumera quantidades de linhas lidas
            lineIndex++;
            //se a quantidade de linhas lidas for menor que a quantidade total de linhas
            if (lineIndex < dialogueLines.Length)
            {
                //invoca rotina
                StartCoroutine("ShowLine");
            }
            //se a a quantidade de linhas lidas for igual que a quantidade total de linhas
            else
            {
                //altera variaveis
                dialogueStart = false;
                dialoguePanel.SetActive(false);
                borda.SetActive(true);
                fimDialog = true;
                transicao.SetActive(true);
            }
        }
    }

    //Rotina
    private IEnumerator ShowLine()
    {
        //intervalo de tempo entre cada algarismo inserido 
        dialogueText.text = string.Empty;
        audioFala.Play();
        foreach (char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSeconds(typingTime);
        }
        //para o audio
        audioFala.Stop();
    }
    //Rotina
    private IEnumerator ProximaFase()
    {
        //passa para a próxima fase apos um intervalo de tempo
        transicao.SetActive(true);
        camera.enabled = false;
        yield return new WaitForSeconds(0.75f);
        CompletaObjetivo.tipoDialog = false;
        SceneManager.LoadScene(proximaFase);
    }
}
