using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculos : MonoBehaviour
{
    public  int quantDados;
    public List<int> dados;
    public int resposta;

    // Start is called before the first frame update
    void Start(){
        dados.Clear();
    }

    // Update is called once per frame
    void Update(){
        
    }

    // Gera numeros para mdc
    public void GeraMDC(){
        GeraDados();
        if (quantDados == 2){
            resposta = CalculaMDC(dados[0],dados[1]);
        } else {
            resposta = CalculaMDC(dados[0],dados[1],dados[2]);
        }
    }

    // Gera numeros para MMC
    public void GeraMMC(){
        GeraDados();
        if (quantDados == 2){
            resposta = CalculaMMC(dados[0],dados[1]);
        } else {
            resposta = CalculaMMC(dados[0],dados[1],dados[2]);
        }
    }

    //gera dados dos jogadores
    public void GeraDados(){
        for (int i = 0 ; i < quantDados; i++){
            dados.Add(Random.Range(1, 7));
        }
    }

    //calculo mdc 2 dados
    int CalculaMDC(int dado1, int dado2){ 
        while(dado2 != 0){
            int aux = dado1 % dado2;
            dado1 = dado2;
            dado2 = aux;
        }
        return dado1;
    }

    //calculo mdc 3 dados
    int CalculaMDC(int dado1, int dado2, int dado3){ 
        dado1 = CalculaMDC(dado1, dado2);
        return CalculaMDC(dado1, dado3);
    }

    //calculo mmc 2 dados
    int CalculaMMC(int dado1, int dado2){ 
        return dado1 * (dado2 / CalculaMDC(dado1, dado2));
    }

    //calculo mmc 3 dados
    int CalculaMMC(int dado1, int dado2, int dado3){ 
        dado1 = CalculaMMC(dado1, dado2);
        return CalculaMMC(dado1,dado3);
    }

    //verifica resultado do jogador
    bool VerifiResultado(int resultadoJogador){
        if (resultadoJogador == resposta) return true;
        else return false;
    }
}
