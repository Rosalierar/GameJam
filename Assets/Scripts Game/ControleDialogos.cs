using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControleDialogos : MonoBehaviour
{

    [Header("Componentes")]

    //Vai controlar o objeto de diálogos
    public TMP_InputField inputField;
    public string nomeDoPersonagemPrincipal;
    [SerializeField] private Image panelBackground;

    [SerializeField] private TextMeshProUGUI conteudoTexto;
    public TextMeshProUGUI nomeDoPersonagem;
    [SerializeField] private GameObject TresOpcoes;
    public GameObject UmaOpcao;
    [SerializeField] private Image imagemPerfil;
    [SerializeField] private Sprite imagemPerfilInicial;
    public TextMeshProUGUI botao1;
    public TextMeshProUGUI botao2;
    public TextMeshProUGUI botao3;
    public TextMeshProUGUI botao4;
    public TextMeshProUGUI botao5;
    public TextMeshProUGUI botao6;
    public GameObject controleDeDialogos;
    public GameObject DuasOpcoes;
    public GameObject BotaoDePular;

    private TabeladeAfinidades tabeladeAfinidades;
    public GameObject objetoDaTabela;

    [SerializeField] private Sprite imagemInicial1, imagemInicial2;
    [SerializeField] private Sprite Player, Maya, Ran, Hanna, Akira;

    [Header("Configurações")]

    [SerializeField] private float velocidadeTexto;

    private string[] textosDialogos;
    public string[] textoInicial;

    public string nomeInicial;

    private int index;
    private int fala = 0;
    public int perguntas = 1;

    private bool textoCompleto;
    public bool dialogoInicial;
    private bool controlarTextoInicial;

    //--------------------------------------------------------------//
    //---------------------------//
    //--------------------------------------------------//
    [Header("Configurações Pos Escolha")]

    private Sprite[] spritesSequencia = new Sprite[2];
    private Sprite[] spritesBackgroundSequencia = new Sprite[2];

    private string[] nomesSequencia;

    public int sequenciaDeDialogos;
    private int falaSequencia = 0;
    public int numeroQueDeveAparecerAsOpcoes;

    public bool ativarOpcao;
    public bool duasOp;
    public bool adicionarNovasStrings = false;

    UniaoGalhos uniaoGalhos; 

    private void Start()
    {
        nomeDoPersonagemPrincipal = PlayerPrefs.GetString("nomeDoJogador");
        Debug.Log("Nome do Jogador: " + nomeDoPersonagemPrincipal);
        uniaoGalhos = GetComponent<UniaoGalhos>();

        tabeladeAfinidades = objetoDaTabela.GetComponent<TabeladeAfinidades>();
    }
    private void Update()
    {
        if (imagemPerfil.sprite == null)
        {
            imagemPerfil.gameObject.SetActive(false);
        }
        else
        {
            imagemPerfil.gameObject.SetActive(true);
        }
    }
    private void FixedUpdate()
    {
        if (dialogoInicial)
        {
            dialogoInicial = false;
            controlarTextoInicial = true;
            Personagem(imagemPerfilInicial, textoInicial, nomeDoPersonagemPrincipal);
        }

        

        if (controlarTextoInicial)
        {
            

            switch (fala)
            {
                case 0:
                    {
                        nomeDoPersonagem.text = nomeDoPersonagemPrincipal;
                        imagemPerfil.sprite = Player;
                        panelBackground.sprite = imagemInicial1;
                        break;
                    }
                case 1:
                    {
                        nomeDoPersonagem.text = "Maya";
                        imagemPerfil.sprite = Maya;
                        panelBackground.sprite = imagemInicial1;
                        break;
                    }
                case 2:
                    {
                        nomeDoPersonagem.text = nomeDoPersonagemPrincipal;
                        imagemPerfil.sprite = Player;
                        panelBackground.sprite = imagemInicial1;
                        break;
                    }
                case 3:
                    {
                        nomeDoPersonagem.text = nomeDoPersonagemPrincipal;
                        imagemPerfil.sprite = Player;
                        panelBackground.sprite = imagemInicial1;
                        break;
                    }
                case 4:
                    {
                        nomeDoPersonagem.text = nomeDoPersonagemPrincipal;
                        imagemPerfil.sprite = Player;
                        panelBackground.sprite = imagemInicial2;
                        conteudoTexto.fontStyle = FontStyles.Italic;
                        break;
                    }
                case 5:
                    {
                        nomeDoPersonagem.text = "Ran";
                        imagemPerfil.sprite = Ran;
                        panelBackground.sprite = imagemInicial2;
                        conteudoTexto.fontStyle = FontStyles.Normal;
                        break;
                    }
                case 6:
                    {
                        nomeDoPersonagem.text = "Maya";
                        imagemPerfil.sprite = Maya;
                        panelBackground.sprite = imagemInicial2;
                        break;
                    }
                case 7:
                    {
                        nomeDoPersonagem.text = nomeDoPersonagemPrincipal;
                        imagemPerfil.sprite = Player;
                        panelBackground.sprite = imagemInicial2;
                        break;
                    }
                case 8:
                    {
                        nomeDoPersonagem.text = "Hanna";
                        imagemPerfil.sprite = Hanna;
                        DuasOpcoes.SetActive(true);
                        BotaoDePular.SetActive(false);
                        controlarTextoInicial = false;
                        break;
                    }
            }


            /*if (tabeladeAfinidades.boolTrovao)
            {

                tabeladeAfinidades.boolTrovao = false;
            }
            else if (tabeladeAfinidades.boolcasaAbandonada)
            {

                tabeladeAfinidades.boolcasaAbandonada = false;
            }
            else if (tabeladeAfinidades.boolbalada)
            {

                tabeladeAfinidades.boolbalada = false;
            }
            else if (tabeladeAfinidades.boolbeco)
            {

                tabeladeAfinidades.boolbeco = false;
            }
            else if (tabeladeAfinidades.boolcorreddorFabrica)
            {

                tabeladeAfinidades.boolcorreddorFabrica = false;
            }
            else if (tabeladeAfinidades.boolforaDeCasa)
            {

                tabeladeAfinidades.boolforaDeCasa = false;
            }
            else if (tabeladeAfinidades.boolmenu)
            {

                tabeladeAfinidades.boolmenu = false;
            }
            else if (tabeladeAfinidades.boolquartoInferno)
            {

                tabeladeAfinidades.boolquartoInferno = false;
            }
            else if (tabeladeAfinidades.boolquartoPersonagem)
            {

                tabeladeAfinidades.boolquartoPersonagem = false;
            }
            else if (tabeladeAfinidades.boolruaPrincial)
            {

                tabeladeAfinidades.boolruaPrincial = false;
            }
            else if (tabeladeAfinidades.boolsalaChefe)
            {

                tabeladeAfinidades.boolsalaChefe = false;
            }
            else if (tabeladeAfinidades.boolsalaFuncionarios)
            {

                tabeladeAfinidades.boolsalaFuncionarios = false;
            }
            else if (tabeladeAfinidades.boolsalaGeradores)
            {

                tabeladeAfinidades.boolsalaGeradores = false;
            }
            else if (tabeladeAfinidades.boolteletransportando)
            {

                tabeladeAfinidades.boolteletransportando = false;
            }*/

        }

        if (ativarOpcao)
        {

            if (numeroQueDeveAparecerAsOpcoes == falaSequencia)
            {
                if (duasOp)
                {
                    DuasOpcoes.SetActive(true);
                    TresOpcoes.SetActive(false);
                    BotaoDePular.SetActive(false);
                }
                else if (!duasOp)
                {
                    TresOpcoes.SetActive(true);
                    DuasOpcoes.SetActive(false);
                    BotaoDePular.SetActive(false);
                }
            }
            else
            {
                DuasOpcoes.SetActive(false);
                TresOpcoes.SetActive(false);

                BotaoDePular.SetActive(true);
            }

            switch (falaSequencia)
            {
                case 0:
                    {
                        nomeDoPersonagem.text = nomesSequencia[0];
                        imagemPerfil.sprite = spritesSequencia[0];
                        panelBackground.sprite = spritesBackgroundSequencia[0];
                        break;
                    }
                case 1:
                    {
                        nomeDoPersonagem.text = nomesSequencia[1];
                        imagemPerfil.sprite = spritesSequencia[1];
                        panelBackground.sprite = spritesBackgroundSequencia[1];
                        break;
                    }
                case 2:
                    {
                        nomeDoPersonagem.text = nomesSequencia[2];
                        imagemPerfil.sprite = spritesSequencia[2];
                        panelBackground.sprite = spritesBackgroundSequencia[2];
                        break;
                    }
                case 3:
                    {
                        nomeDoPersonagem.text = nomesSequencia[3];
                        imagemPerfil.sprite = spritesSequencia[3];
                        panelBackground.sprite = spritesBackgroundSequencia[3];
                        break;
                    }
                case 4:
                    {
                        nomeDoPersonagem.text = nomesSequencia[4];
                        imagemPerfil.sprite = spritesSequencia[4];
                        panelBackground.sprite = spritesBackgroundSequencia[4];
                        break;
                    }
                case 5:
                    {
                        nomeDoPersonagem.text = nomesSequencia[5];
                        imagemPerfil.sprite = spritesSequencia[5];
                        panelBackground.sprite = spritesBackgroundSequencia[5];
                        break;
                    }
                case 6:
                    {
                        nomeDoPersonagem.text = nomesSequencia[6];
                        imagemPerfil.sprite = spritesSequencia[6];
                        panelBackground.sprite = spritesBackgroundSequencia[6];
                        break;
                    }
                case 7:
                    {
                        nomeDoPersonagem.text = nomesSequencia[7];
                        imagemPerfil.sprite = spritesSequencia[7];
                        panelBackground.sprite = spritesBackgroundSequencia[7];
                        break;
                    }
                case 8:
                    {
                        nomeDoPersonagem.text = nomesSequencia[8];
                        imagemPerfil.sprite = spritesSequencia[8];
                        panelBackground.sprite = spritesBackgroundSequencia[8];
                        break;
                    }
                case 9:
                    {
                        nomeDoPersonagem.text = nomesSequencia[9];
                        imagemPerfil.sprite = spritesSequencia[9];
                        panelBackground.sprite = spritesBackgroundSequencia[9];
                        break;
                    }
                case 10:
                    {
                        nomeDoPersonagem.text = nomesSequencia[10];
                        imagemPerfil.sprite = spritesSequencia[10];
                        panelBackground.sprite = spritesBackgroundSequencia[10];
                        break;
                    }
                case 11:
                    {
                        nomeDoPersonagem.text = nomesSequencia[11];
                        imagemPerfil.sprite = spritesSequencia[11];
                        panelBackground.sprite = spritesBackgroundSequencia[11];
                        break;
                    }
                case 12:
                    {
                        nomeDoPersonagem.text = nomesSequencia[12];
                        imagemPerfil.sprite = spritesSequencia[12];
                        panelBackground.sprite = spritesBackgroundSequencia[12];
                        break;
                    }
                case 13:
                    {
                        nomeDoPersonagem.text = nomesSequencia[13];
                        imagemPerfil.sprite = spritesSequencia[13];
                        panelBackground.sprite = spritesBackgroundSequencia[13];
                        break;
                    }
                case 14:
                    {
                        nomeDoPersonagem.text = nomesSequencia[14];
                        imagemPerfil.sprite = spritesSequencia[14];
                        panelBackground.sprite = spritesBackgroundSequencia[14];
                        break;
                    }
                case 15:
                    {
                        nomeDoPersonagem.text = nomesSequencia[15];
                        imagemPerfil.sprite = spritesSequencia[15];
                        panelBackground.sprite = spritesBackgroundSequencia[15];
                        break;
                    }
                case 16:
                    {
                        nomeDoPersonagem.text = nomesSequencia[16];
                        imagemPerfil.sprite = spritesSequencia[16];
                        panelBackground.sprite = spritesBackgroundSequencia[16];
                        break;
                    }
                case 17:
                    {
                        nomeDoPersonagem.text = nomesSequencia[17];
                        imagemPerfil.sprite = spritesSequencia[17];
                        panelBackground.sprite = spritesBackgroundSequencia[17];
                        break;
                    }
                case 18:
                    {
                        nomeDoPersonagem.text = nomesSequencia[18];
                        imagemPerfil.sprite = spritesSequencia[18];
                        panelBackground.sprite = spritesBackgroundSequencia[18];
                        break;
                    }
                case 19:
                    {
                        nomeDoPersonagem.text = nomesSequencia[19];
                        imagemPerfil.sprite = spritesSequencia[19];
                        panelBackground.sprite = spritesBackgroundSequencia[19];
                        break;
                    }
                case 20:
                    {
                        nomeDoPersonagem.text = nomesSequencia[20];
                        imagemPerfil.sprite = spritesSequencia[20];
                        panelBackground.sprite = spritesBackgroundSequencia[20];
                        break;
                    }
                case 21:
                    {
                        nomeDoPersonagem.text = nomesSequencia[21];
                        imagemPerfil.sprite = spritesSequencia[21];
                        panelBackground.sprite = spritesBackgroundSequencia[21];
                        break;
                    }
                case 22:
                    {
                        nomeDoPersonagem.text = nomesSequencia[22];
                        imagemPerfil.sprite = spritesSequencia[22];
                        panelBackground.sprite = spritesBackgroundSequencia[22];
                        break;
                    }
                case 23:
                    {
                        nomeDoPersonagem.text = nomesSequencia[23];
                        imagemPerfil.sprite = spritesSequencia[23];
                        panelBackground.sprite = spritesBackgroundSequencia[23];
                        break;
                    }
                case 24:
                    {
                        nomeDoPersonagem.text = nomesSequencia[24];
                        imagemPerfil.sprite = spritesSequencia[24];
                        panelBackground.sprite = spritesBackgroundSequencia[24];
                        break;
                    }
                case 25:
                    {
                        nomeDoPersonagem.text = nomesSequencia[25];
                        imagemPerfil.sprite = spritesSequencia[25];
                        panelBackground.sprite = spritesBackgroundSequencia[25];
                        break;
                    }
                case 26:
                    {
                        nomeDoPersonagem.text = nomesSequencia[26];
                        imagemPerfil.sprite = spritesSequencia[26];
                        panelBackground.sprite = spritesBackgroundSequencia[26];
                        break;
                    }
                case 27:
                    {
                        nomeDoPersonagem.text = nomesSequencia[27];
                        imagemPerfil.sprite = spritesSequencia[27];
                        panelBackground.sprite = spritesBackgroundSequencia[27];
                        break;
                    }
                case 28:
                    {
                        nomeDoPersonagem.text = nomesSequencia[28];
                        imagemPerfil.sprite = spritesSequencia[28];
                        panelBackground.sprite = spritesBackgroundSequencia[28];
                        break;
                    }
                case 29:
                    {
                        nomeDoPersonagem.text = nomesSequencia[29];
                        imagemPerfil.sprite = spritesSequencia[29];
                        panelBackground.sprite = spritesBackgroundSequencia[29];
                        break;
                    }
                case 30:
                    {
                        nomeDoPersonagem.text = nomesSequencia[30];
                        imagemPerfil.sprite = spritesSequencia[30];
                        panelBackground.sprite = spritesBackgroundSequencia[30];
                        break;
                    }
                case 31:
                    {
                        nomeDoPersonagem.text = nomesSequencia[31];
                        imagemPerfil.sprite = spritesSequencia[31];
                        panelBackground.sprite = spritesBackgroundSequencia[31];
                        break;
                    }
                case 32:
                    {
                        nomeDoPersonagem.text = nomesSequencia[32];
                        imagemPerfil.sprite = spritesSequencia[32];
                        panelBackground.sprite = spritesBackgroundSequencia[32];
                        break;
                    }
                case 33:
                    {
                        nomeDoPersonagem.text = nomesSequencia[33];
                        imagemPerfil.sprite = spritesSequencia[33];
                        panelBackground.sprite = spritesBackgroundSequencia[33];
                        break;
                    }
                case 34:
                    {
                        nomeDoPersonagem.text = nomesSequencia[34];
                        imagemPerfil.sprite = spritesSequencia[34];
                        panelBackground.sprite = spritesBackgroundSequencia[34];
                        break;
                    }
                case 35:
                    {
                        nomeDoPersonagem.text = nomesSequencia[35];
                        imagemPerfil.sprite = spritesSequencia[35];
                        panelBackground.sprite = spritesBackgroundSequencia[35];
                        break;
                    }
                case 36:
                    {
                        nomeDoPersonagem.text = nomesSequencia[36];
                        imagemPerfil.sprite = spritesSequencia[36];
                        panelBackground.sprite = spritesBackgroundSequencia[36];
                        break;
                    }
                case 37:
                    {
                        nomeDoPersonagem.text = nomesSequencia[37];
                        imagemPerfil.sprite = spritesSequencia[37];
                        panelBackground.sprite = spritesBackgroundSequencia[37];
                        break;
                    }


            }
        }

    }

    public void Personagem(Sprite imagemNPC, string[] texto, string nomePersonagem)
    {
        imagemPerfil.sprite = imagemNPC;
        textosDialogos = texto;
        nomeDoPersonagem.text = nomePersonagem;

        controleDeDialogos.SetActive(true);

        StartCoroutine(AnimacaoTexto());
    }

    public void PosPerguntas(Sprite[] imagemNPC, Sprite[] backgrounds, string[] texto, string[] nomePersonagem, int sequencia, bool opcao)
    {
        spritesSequencia = imagemNPC;
        spritesBackgroundSequencia = backgrounds;
        textosDialogos = texto;
        nomesSequencia = nomePersonagem;

        sequenciaDeDialogos = sequencia;
        ativarOpcao = opcao;

        index = 0; falaSequencia = 0;

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
        //Verifica se ainda não foram passados todos os textos do diálogo
        else if (index < textosDialogos.Length - 1)
        {
            //Se ainda faltam textos, pula para o próximo, limpa o texto e inicia a animação do texto seguinte
            index++;
            fala++;

            if (ativarOpcao)
            {
                falaSequencia++;
            }

            StartCoroutine(AnimacaoTexto());
        }
        //Se todos os textos foram passados
        else if (index == textosDialogos.Length - 1)
        {
            conteudoTexto.text = "";
            textosDialogos = new string[] { };
            nomesSequencia = new string[] { };
            spritesSequencia = new Sprite[] { };

            Debug.Log(perguntas);
            Debug.Log(adicionarNovasStrings);
            Debug.Log(textoCompleto);
            Debug.Log(falaSequencia == sequenciaDeDialogos - 1);

            if (adicionarNovasStrings && textoCompleto && falaSequencia == sequenciaDeDialogos - 1)
            {
                NovasStrings();
                adicionarNovasStrings = false;
                Debug.Log("Funcionou");
                Debug.Log("Novas Strings" + perguntas);
            }

            index = 0;
            falaSequencia = 0;

            StartCoroutine(AnimacaoTexto());

            //controleDeDialogos.SetActive(false);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    public void ZerarIndex()
    {
        index = 0;
        falaSequencia = 0;
    }

    public void NovasStrings()
    {
        uniaoGalhos.nomeDoPersonagemPrincipal = nomeDoPersonagemPrincipal;

        textosDialogos = uniaoGalhos.UniaoDeGalhosDialogos(perguntas);
        nomesSequencia = uniaoGalhos.UniaoDeGalhosNomes(perguntas);
        spritesSequencia = uniaoGalhos.UniaoDeGalhosSprites(perguntas);
        numeroQueDeveAparecerAsOpcoes = uniaoGalhos.UniaoDeGalhosOpcoes(perguntas);
        duasOp = uniaoGalhos.UniaoDeGalhosTipoOpcao(perguntas);
        spritesBackgroundSequencia = uniaoGalhos.UniaoDeGalhosBackground(perguntas);
    }
    


}
