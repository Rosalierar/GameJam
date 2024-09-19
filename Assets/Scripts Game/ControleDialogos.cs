using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControleDialogos : MonoBehaviour
{

    [Header("Componentes")]

    //Vai controlar o objeto de di�logos
    [SerializeField] private TextMeshProUGUI conteudoTexto;
    [SerializeField] private TextMeshProUGUI nomeDoPersonagem;
    [SerializeField] private GameObject controleDeDialogos;
    [SerializeField] private Image imagemPerfil;
    

    [Header("Configura��es")]

    [SerializeField] private float velocidadeTexto;
    private string[] textosDialogos;
    private int index;
    private DialogoNPC scriptDialogoNPC;
    private List<DialogoNPC> nPCs = new List<DialogoNPC>();

    private bool textoCompleto;

    public void Personagem(Sprite imagemNPC, string[] texto, string nomePersonagem, DialogoNPC npc)
    {
        scriptDialogoNPC = npc;
        imagemPerfil.sprite = imagemNPC;
        textosDialogos = texto;
        nomeDoPersonagem.text = nomePersonagem;

        controleDeDialogos.SetActive(true);

        StartCoroutine(AnimacaoTexto());
    }

    IEnumerator AnimacaoTexto()
    {
        textoCompleto = false;
        conteudoTexto.text = "";
        foreach (char letras in textosDialogos[index].ToCharArray())
        {
            conteudoTexto.text += letras;
            yield return new WaitForSeconds(velocidadeTexto);
        }
        textoCompleto = true;
    }

    public void PularTexto()
    {
        if (!textoCompleto)
        {
            StopAllCoroutines();
            conteudoTexto.text = textosDialogos[index];
            textoCompleto = true;
        }
        //Verifica se ainda n�o foram passados todos os textos do di�logo
        else if (index < textosDialogos.Length - 1)
        {
            //Se ainda faltam textos, pula para o pr�ximo, limpa o texto e inicia a anima��o do texto seguinte
            index++;
            StartCoroutine(AnimacaoTexto());
        }
        //Se todos os textos foram passados
        else
        {
            conteudoTexto.text = "";
            index = 0;
            controleDeDialogos.SetActive(false);

            scriptDialogoNPC.FimDoDialogo(false);
        }
    }

}
