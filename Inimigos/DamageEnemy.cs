//adiciona bibliotecas próprias do Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//cria classe de herança
public class DamageEnemy : MonoBehaviour
{
    //declara variaveis e objetos
    private Movimento2 pulos; 

    public int damageToDeal;

    public AudioSource eliminouInimigoSom;

    public GameObject eliminouInimigoText;

    public Rigidbody2D theRB2D;
    public float bounceforce;

    //se o Jogador colidir com inimigos
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "HurtBox")
        {
            //zera a força de impulso pra não multiplicar com a força de repulsão
            theRB2D.velocity = Vector2.up * 0;
            //inicia uma rotina no código "eliminouInimigosSom"
            eliminouInimigoSom.Play();
            //ativa texto flutuante
            TextoFlutuante.textAtiva = true;
            //Ativa texto flutuante
            eliminouInimigoText.SetActive(true);
            //altera variavel de vida do inimigo
            other.gameObject.GetComponent<EnemyHP>().TakeDamage(damageToDeal);
            //aciona a força de repulsão
            theRB2D.AddForce(transform.up * bounceforce, ForceMode2D.Impulse);
            
        } 
    }
}
