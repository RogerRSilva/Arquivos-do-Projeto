//adiciona bibliotecas próprias do Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//cria classe de herança
public class TransicaoBaile : MonoBehaviour
{
    //declara variaveis
    public string proximaFase;
    public AudioListener trilhaSonora;
    public AudioSource somAmbiente;

    void Start()
    {
        //Inicia a Rotina apenas uma vez
        StartCoroutine("ProximaFase");
    }

    //define a troca de cenas com intervalos de tempo e altera valores de váriaveis
    IEnumerator ProximaFase()
    {
        yield return new WaitForSeconds(3);
        trilhaSonora.enabled = false;
        somAmbiente.enabled = false;
        Movimento2.podePular = false;
        Movimento2.moveSpeed = 0;
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(proximaFase);
    }
}
