using UnityEngine;
using UnityEngine.SceneManagement;

public class MudarCena : MonoBehaviour
{
    public static string cenaJogo = "Jogo";
    public static string cenaMenu = "Menu";
    public static string cenaEscolheQuantJogador = "EscolhePlayer";
    public static string cenaRegras = "Regras";
    public static string nomeDaCena;
    
    public static void Start()
    {

    }

    public void SetaTela(GameObject Ativa, GameObject Desativa1, GameObject Desativa2, GameObject Desativa3, GameObject Desativa4)
    {
        Desativa1.SetActive(false);
        Desativa2.SetActive(false);
        Desativa3.SetActive(false);
        Desativa4.SetActive(false);
        Ativa.SetActive(true);
    }

    //public static void Mudar(int jogadores){
    //    SceneManager.LoadScene(cenaJogo);
    //}

    //public static void MudarParaMenu(){
    //    SceneManager.LoadScene(cenaMenu);
    //}

    //public static void MudarParaRegras(){
    //    SceneManager.LoadScene(cenaRegras);
    //}

    public static void Sair(){
        Application.Quit();
    }
}
