using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MudarCena : MonoBehaviour
{
    public string cenaJogo = "Jogo";
    public string nomeDaCena;
    public int quantJogador;
    
    // Update is called once per frame
    void Update()
    {
        //if (Application.loadedLevelName == cenaJogo){
            //Jogo.quantJogador = quantJogador;
            //Destroy(gameObject);
        //}
    }

    public void Mudar(){
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(nomeDaCena);
    }

    public void Sair(){
        Application.Quit();
    }
}
