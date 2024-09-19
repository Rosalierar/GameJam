using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private int levelGame;

    [SerializeField] private GameObject MenuInicial;
    [SerializeField] private GameObject MenuOpcoes;



    public void Jogar()
    {
        cliqueBotaoJogar = true;
    }

    public void AbrirOpcoes()
    {
        MenuInicial.SetActive(false);
        MenuOpcoes.SetActive(true);
    }

    public void FecharOpcoes()
    {
        MenuOpcoes.SetActive(false);
        MenuInicial.SetActive(true);
    }

    public void Sair()
    {
        Application.Quit();
    }




    //Controla a velocidade da transi��o de fade
    [SerializeField] private float escalaDeVelocidade = 1f;

    //Define a cor do fade, que ser� preto.
    [SerializeField] private Color corFade = Color.black;

    //essa curva permite personalizar como a transi��o acontece ao longo do tempo
    [SerializeField] private AnimationCurve curva = new AnimationCurve(new Keyframe(0, 1), new Keyframe(0.5f, 0.5f, -1.5f, -1.5f), new Keyframe(1, 0));

    //Determina se a tela come�a escurecida (true) ou vis�vel (false)
    [SerializeField] private bool comecarEscurecido = false;




    //Armazena o n�vel de opacidade (0 = vis�vel, 1 = escuro)
    private float opacidade = 0f;

    //A textura que ser� desenhada na tela para o efeito de fade
    private Texture2D textura;

    //Controla a dire��o da transi��o (1 = clareando, -1 = escurecendo, 0 = parado)
    private int direcao = 0;

    //Controla o progresso na curva de anima��o
    private float tempo = 0f;

    private bool cliqueBotaoJogar = false;



    private void Start()
    {
        //Se a tela deve come�ar escurecida, define a opacidade para 1 (escuro). Caso contr�rio, define para 0 (vis�vel)
        if (comecarEscurecido)
        {
            opacidade = 1f;
        }
        else
        {
            opacidade = 0f;
        }

        //Cria uma textura de 1x1 pixel
        textura = new Texture2D(1, 1);

        //Define a cor do �nico pixel da textura, usando a cor e opacidade configuradas
        textura.SetPixel(0, 0, new Color(corFade.r, corFade.g, corFade.b, opacidade));

        //Aplica as mudan�as na textura
        textura.Apply();
    }

    private void Update()
    {
        //Se n�o h� transi��o em andamento (dire��o = 0) e o bot�o foi pressionado, inicia a transi��o
        if (direcao == 0 && cliqueBotaoJogar)
        {
            cliqueBotaoJogar = false;
            //Se a tela est� totalmente escura, come�a a clarear (direcao = 1)
            if (opacidade >= 1f)
            {
                opacidade = 1f;
                tempo = 0f;
                direcao = 1;
            }
            //Se a tela est� totalmente vis�vel, come�a a escurecer (direcao = -1)
            else
            {
                opacidade = 0f;
                tempo = 1f;
                direcao = -1;
            }
        }
    }

    private void OnGUI()
    {
        //Se a opacidade � maior que 0, desenha a textura cobrindo toda a tela
        if (opacidade > 0f)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), textura);
        }

        //Se h� uma transi��o em andamento, atualiza o tempo e a opacidade
        if (direcao != 0)
        {
            tempo += direcao * Time.deltaTime * escalaDeVelocidade;

            //Usa a curva de anima��o para calcular a nova opacidade baseada no tempo
            opacidade = curva.Evaluate(tempo);

            //Atualiza a cor da textura com a nova opacidade
            textura.SetPixel(0, 0, new Color(corFade.r, corFade.g, corFade.b, opacidade));

            //Aplica a mudan�a na textura
            textura.Apply();

            //Se o fade chegou ao fim (totalmente vis�vel ou escuro), para a transi��o.
            if (opacidade >= 1f || opacidade <= 0f)
            {
                direcao = 0;
            }

            if (opacidade >= 1f && direcao == 0)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
