//adiciona bibliotecas pr�prias do Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//adiciona biblioteca pr�pria do Unity de gerenciamento de cenas
using UnityEngine.SceneManagement;

//declarando requerimento do componente "colisor 2D" para o c�digo funcionar
[RequireComponent(typeof(Collider2D))]
//cria classe de heran�a
public class prxFase : MonoBehaviour
{
    //declara variaveis e objetos
    public string proximaFase;
    public GameObject transicao;
    public AudioListener camera;

    //quando um objeto especifico (jogador) entrar no campo definido o metodo � invocado
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Inicia uma rotina
            StartCoroutine("ProximaFase");
        }
        
    }
    //define a troca de cenas com intervalo de tempo e altera valores de v�riaveis
    IEnumerator ProximaFase()
    {
        transicao.SetActive(true);
        camera.enabled = false;
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(proximaFase);
    }
}
