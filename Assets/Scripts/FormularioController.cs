using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormularioController : MonoBehaviour
{

    public Animator[] questions;
    public Animator lastPanel;
    public Animator firstPanel;
    int[] responses;
    int currentQuestion = 0;
    int navigationTech;
    float playTime;

    void Start(){
        responses = new int[questions.Length];
        navigationTech = GameObject.Find("InstructionStylePicker").GetComponent<InstructionStylePicker>().instructionStyle;
        playTime = GameObject.Find("Timer").GetComponent<LevelTimer>().theTime;
        firstPanel.Play("QuestionPanelOpen");
    }

    public void AnswerQuestion(int answer){
        responses[currentQuestion] = answer;
        if(currentQuestion != questions.Length -1)
            StartCoroutine(NextQuestion());
        else StartSendResults();
    }

    public void OpenFirstQuestion(){
        StartCoroutine(FirstQuestion());
    }

    IEnumerator FirstQuestion(){
        firstPanel.Play("QuestionPanelClose");
        yield return new WaitForSeconds(firstPanel.GetCurrentAnimatorStateInfo(0).length);
        firstPanel.gameObject.SetActive(false);
        questions[0].gameObject.SetActive(true);
        questions[0].Play("QuestionPanelOpen");
    }

    IEnumerator NextQuestion(){
        questions[currentQuestion].Play("QuestionPanelClose");
        yield return new WaitForSeconds(questions[currentQuestion].GetCurrentAnimatorStateInfo(0).length);
         questions[currentQuestion].gameObject.SetActive(false);
        currentQuestion++;
        if(currentQuestion < questions.Length){
            questions[currentQuestion].gameObject.SetActive(true);
            questions[currentQuestion].Play("QuestionPanelOpen");
        }
        else
            StartSendResults();
        
    }

    IEnumerator OpenLastPanel(){
        questions[currentQuestion].Play("QuestionPanelClose");
        yield return new WaitForSeconds(questions[currentQuestion].GetCurrentAnimatorStateInfo(0).length);
        questions[currentQuestion].gameObject.SetActive(false);
        lastPanel.gameObject.SetActive(true);
        lastPanel.Play("QuestionPanelOpen");
        yield return new WaitForSeconds(lastPanel.GetCurrentAnimatorStateInfo(0).length);
    }

    public void StartSendResults(){
        StartCoroutine(SendResults());
    }

    public IEnumerator SendResults(){
        DBEntry results = new DBEntry();
        results.tecnicaDeNavegacao = navigationTech;
        results.tempoDeJogo = playTime;
        results.jaJogouJogosParecidosAntes = responses[0];
        results.teveFacilidadeEmCompletarOJogo = responses[1];
        results.seSentiuPerdido = responses[2];
        results.jogoPrecisaDeInstrucoesMaisClaras = responses[3];
        results.instrucoesQuebraramImersao = responses[4];
        results.teveQueSeEsforcarParaJogar = responses[5];
        results.experienciaSatisfatoria = responses[6];

        if(PlayerPrefs.GetInt("JaEnviou", -1) == -1){
            PlayerPrefs.SetInt("JaEnviou", 1);
            yield return WebServerConnection.UploadToDatabase(results);
        }


        yield return OpenLastPanel();

    }

    public void End(){
        Application.Quit();
    }     
}
