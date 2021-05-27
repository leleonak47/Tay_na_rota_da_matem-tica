using UnityEngine;

public static class MudarCena
{
    public static void SetaTela(GameObject Ativa, GameObject Desativa1, GameObject Desativa2, GameObject Desativa3, GameObject Desativa4)
    {
        Desativa1.SetActive(false);
        Desativa2.SetActive(false);
        Desativa3.SetActive(false);
        Desativa4.SetActive(false);
        Ativa.SetActive(true);
    }

    public static void Sair(){
        Application.Quit();
    }
}
