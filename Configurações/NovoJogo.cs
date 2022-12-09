//adiciona bibliotecas próprias do Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//cria classe de herança
public class NovoJogo : MonoBehaviour
{
    //se a opção de Novo jogo for selecionada o método abaixo é invocado
    public void Novojogo()
    {
        //define que número de fases desbloqueadas é zero, todo o progresso (caso tenha) é perdido
        SaveFaseCarregar.fase = 0;
        PlayerPrefs.SetInt("dbFase", SaveFaseCarregar.fase);
    }
}
