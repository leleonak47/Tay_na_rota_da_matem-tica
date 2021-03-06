using System.Collections.Generic;
using UnityEngine;

public class Calculos
{
    public List<int> dados;
    public int resposta;

    public Calculos()
    {
        dados = new List<int>();
    }

    // Start is called before the first frame update
    public void LimpaDados(){
        dados.Clear();
    }

    // Gera numeros para mdc
    public void GeraMDC()
    {
        if (dados.Count == 2){
            resposta = CalculaMDC(dados[0],dados[1]);
        } else {
            resposta = CalculaMDC(dados[0],dados[1],dados[2]);
        }
    }

    // Gera numeros para MMC
    public void GeraMMC()
    {
        if (dados.Count == 2){
            resposta = CalculaMMC(dados[0],dados[1]);
        } else {
            resposta = CalculaMMC(dados[0],dados[1],dados[2]);
        }
    }

    //gera dados dos jogadores
    public string GeraDados(int quantDados)
    {
        LimpaDados();

        for (int i = 0 ; i < quantDados; i++){
            dados.Add(Random.Range(1, 7));
        }

        string txtdados = "";

        for (int i = 0; i < quantDados; i++)
        {
            txtdados += " | " + dados[i].ToString();
        }

        return txtdados += " | ";
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
