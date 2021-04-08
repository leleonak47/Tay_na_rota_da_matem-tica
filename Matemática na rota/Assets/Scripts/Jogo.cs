using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogo : MonoBehaviour
{
    public int casaFinal = 140;
    public int quantJogador = 2;
    public int jogadorAtual = 0;
    public int casasAndadas;
    public List<Player> Jogadores;
    public bool repete = true;
    public List<int> casaMMC;
    public List<int> casaMDC;
    public List<int> casa2;
    public List<int> casa3;

    // Start is called before the first frame update
    void Start()
    {
        casaMMC.Clear();
        casaMDC.Clear();
        casa2.Clear();
        casa3.Clear();

        casasAndadas = 0;
        //seleciona ordem jogadores
        foreach (Player item in Jogadores){
            item.SetaOrdemJogadores(quantJogador);
            while (repete){
                repete = false;
                for (int j = 0; j < Jogadores.Count; j++){
                    if (item.posicao == Jogadores[j].posicao){
                        repete = true;
                    }
                }  
                item.SetaOrdemJogadores(quantJogador);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        casasAndadas = 0;
        AtualizaJogadorAtual();
    }

    void AtualizaJogadorAtual(){
        if (jogadorAtual >= (quantJogador-1)){
            jogadorAtual = 0;
        }
        else if (Jogadores[jogadorAtual].posicao == casaFinal){
            //Apresenta tela de vitória
            //jogadorAtual++;
        }
        else {
            jogadorAtual++;
        }
    }

    void GeraCasas(){
        for (int i = 0; i <7; i++){
            
        }
    }
}
