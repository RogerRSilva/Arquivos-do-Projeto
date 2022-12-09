//adiciona bibliotecas pr�prias do Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//cria classe de heran�a
public class Configuracoes : MonoBehaviour
{
    //declara variavel que ir� salvar o progresso de fases do jogador
    public int fase;

    void Start()
    {
        //Sempre que o jogador come�ar uma nova fase, v�riaveis globais s�o alteradas para seus valores iniciais
        TrilhasSonoras.falouDnCleusa = false;
        JogadorInterage.interacao = false;
        CompletaObjetivo.tipoDialog = false;
        BotaoInterage.onOff = false;
        Movimento2.podePular = true;
        Movimento2.moveSpeed = 6.5f;
        Movimento2.estaticoGlobal = true;
        MarmitaPos.dropou = false;
        SetaOff.pegou = true;
        FollowCamera1.perdeuQueda = false;
        Pause.isGamePaused = false;
        Desativatransicao.prxTrue = false;

        //Salva o progresso a cada nova fase desbloqueada
        if (fase == 1 && SaveFaseCarregar.fase == 0)
        {
            SaveFaseCarregar.fase = 1;
            //Componente do pr�prio Unity que cria um arquivo local com uma Variavel do tipo inteira
            PlayerPrefs.SetInt("dbFase", SaveFaseCarregar.fase);
        }
        if (fase == 2 && SaveFaseCarregar.fase == 1)
        {
            SaveFaseCarregar.fase = 2;
            PlayerPrefs.SetInt("dbFase", SaveFaseCarregar.fase);
        }
        if (fase == 3 && SaveFaseCarregar.fase == 2)
        {
            SaveFaseCarregar.fase = 3;
            PlayerPrefs.SetInt("dbFase", SaveFaseCarregar.fase);
        }
        if (fase == 4 && SaveFaseCarregar.fase == 3)
        {
            SaveFaseCarregar.fase = 4;
            PlayerPrefs.SetInt("dbFase", SaveFaseCarregar.fase);
        }
        if (fase >= 5 && SaveFaseCarregar.fase >= 0)
        {
            SaveFaseCarregar.fase = 5;
            PlayerPrefs.SetInt("dbFase", SaveFaseCarregar.fase);
        }
    }
}
