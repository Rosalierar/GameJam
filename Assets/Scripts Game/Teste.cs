using System.Collections;
using UnityEngine;
using UnityEngine.U2D;

public class Teste : MonoBehaviour
{
    private int perguntas = 1;
    
    private TabeladeAfinidades tabelaAfinidades;
    private ControleDialogos controleDialogos;
    private AtivarDesativarTexto ativarDesativarTexto;
    [SerializeField]
    private GameObject objetoDosTextos;

    [Header("Personagens")]

    public Sprite Maya;
    public Sprite Ran;
    public Sprite Hanna;
    public Sprite Hannasombra;
    public Sprite Akira;
    public Sprite Finwick;
    public Sprite Macula;
    public Sprite Cooper;
    public Sprite Disha;
    public Sprite Chefe;
    public Sprite Player;
    public Sprite Narrador;
    public Sprite Iva;

    public Sprite Cien;
    public Sprite Gust;

    [Header("Cenas")]

    public Sprite cenaQT;
    public Sprite cenaCS;
    public Sprite cenaCB;
    public Sprite cenaC1;
    public Sprite cenaSB;
    public Sprite cenaRP;
    public Sprite cenaBC;
    public Sprite cenaRC;
    public Sprite cenaQI;
    public Sprite cenaBT;
    public Sprite cenaEF;
    public Sprite cenaCF;
    public Sprite cenaSG;
    public Sprite cenaGG;
    public Sprite cenaSF;
    public Sprite cenaSC;

    public Sprite cenaFP;

    private string nomeDoPersonagemPrincipal;

    private bool casaMalAssombrada;
    private bool AkiraeHanna;
    private bool possibilidadeDeNaoSeguirCooper;
    private bool possibilidadeDeOlharOBeco;
    private bool possibilidadeEscolherCerto;
    private sbyte galhosCasaMalAssombrada = 0;

    public bool ImprimirDoJeitoMacula;
    public bool respondeuHannaFriamente = false;

    private void Start()
    {
        nomeDoPersonagemPrincipal = PlayerPrefs.GetString("nomeDoJogador");

        tabelaAfinidades = FindObjectOfType<TabeladeAfinidades>();
        controleDialogos = FindObjectOfType<ControleDialogos>();
        ativarDesativarTexto = objetoDosTextos.GetComponent<AtivarDesativarTexto>();
    }
    public void CliqueOpcao1()
    {
        Resposta(perguntas, 1);
    }
    public void CliqueOpcao2()
    {
        Resposta(perguntas, 2);
    }
    public void CliqueOpcao3()
    {
        Resposta(perguntas, 3);
    }
    public void CliqueOpcao4()
    {
        if (!casaMalAssombrada && !AkiraeHanna && !possibilidadeDeNaoSeguirCooper && !possibilidadeDeOlharOBeco && !possibilidadeEscolherCerto)
        {
            Resposta(perguntas, 4);
        }
        else if (casaMalAssombrada)
        {
            RespostaCasaMalAssombrada(galhosCasaMalAssombrada, 4);
        }
        else if (AkiraeHanna)
        {
            RespostaAkiraeHanna(4);
        }
        else if (possibilidadeDeNaoSeguirCooper)
        {
            controleDialogos.botao4.text = "Questioning Cooper's statement";
            controleDialogos.botao5.text = "Say nothing";

            possibilidadeDeNaoSeguirCooper = false;

            controleDialogos.PularTexto();
            controleDialogos.BotaoDePular.SetActive(true);

            Sprite[] sprites = { Player, Cooper, Iva, Cooper, Iva, Cooper };
            Sprite[] bg = { cenaBC, cenaRC, cenaRC, cenaRC, cenaRC, cenaRC };
            string[] stringsTextos = { "If... if it's alright, I'd like to accompany you...",
                                    "Well, this is the apartment! Hey, Iva, my door's broken, can you send one of your contacts over to fix it?",
                                    "I can, but who is that?",
                                    "Ah, well, someone looking for an apartment.",
                                    "Does he have any money? If not, I'll put it in your account.",
                                    "Hold on, he's going to start working there in the industry."};
            string[] stringsNomes = { nomeDoPersonagemPrincipal, "Cooper", "Iva", "Cooper", "Iva", "Cooper" };
            int sequencia = stringsTextos.Length;

            controleDialogos.PosPerguntas(sprites, bg, stringsTextos, stringsNomes, sequencia, true);

            controleDialogos.numeroQueDeveAparecerAsOpcoes = sequencia - 1;

            controleDialogos.adicionarNovasStrings = false;
        }
        else if (possibilidadeDeOlharOBeco) //Não Olhar o Beco e Ir para o Trabalho
        {
            controleDialogos.botao4.text = "State the reason for the question";
            controleDialogos.botao5.text = "Say who you are";

            Debug.Log(perguntas);

            possibilidadeDeOlharOBeco = false;

            controleDialogos.PularTexto();
            controleDialogos.BotaoDePular.SetActive(true);

            Sprite[] sprites = { Finwick, Finwick };
            Sprite[] bg = { cenaRP, cenaRP };
            string[] stringsTextos = { "Who would have thought that a human could have such a strong aura that he could even look like us?",
                                    "My name is Finwick, if anyone says anything about me, don't believe them, I'm a little angel, and who are you?" };
            string[] stringsNomes = { "Unknown Monster 5", "Unknown Monster 5" };
            int sequencia = stringsTextos.Length;

            controleDialogos.PosPerguntas(sprites, bg, stringsTextos, stringsNomes, sequencia, true);

            controleDialogos.numeroQueDeveAparecerAsOpcoes = sequencia - 1;

            controleDialogos.adicionarNovasStrings = false;
        }

        else if (possibilidadeEscolherCerto)
        {
            controleDialogos.botao4.text = "Print the human way";
            controleDialogos.botao5.text = "Print the way Macula taught you";

            perguntas++;
            controleDialogos.perguntas++;

            Debug.Log("perguntas" + perguntas);
            Debug.Log("controleDialogos.perguntas" + controleDialogos.perguntas);

            possibilidadeEscolherCerto = false;

            ativarDesativarTexto.AtivarAnimação1(10, "Boss");

            tabelaAfinidades.AtualizarAfinidadeChefe(10);

            controleDialogos.PularTexto();
            controleDialogos.BotaoDePular.SetActive(true);

            Sprite[] sprites = { Gust, Narrador };
            Sprite[] bg = { cenaSG, cenaSF };
            string[] stringsTextos = { "At least you know this, here you DIS. <i>(Gust leaves)</i>",
            "<i>I left the room and went to the staff room to print out the document.</i>"};
            string[] stringsNomes = { "Gust", "" };
            int sequencia = stringsTextos.Length;

            controleDialogos.PosPerguntas(sprites, bg, stringsTextos, stringsNomes, sequencia, true);

            controleDialogos.numeroQueDeveAparecerAsOpcoes = sequencia - 1;

            controleDialogos.adicionarNovasStrings = false;
        }
    }
    public void CliqueOpcao5()
    {
        if (!casaMalAssombrada && !AkiraeHanna && !possibilidadeDeNaoSeguirCooper && !possibilidadeDeOlharOBeco && !possibilidadeEscolherCerto)
        {
            Resposta(perguntas, 5);
        }
        else if (casaMalAssombrada)
        {
            RespostaCasaMalAssombrada(galhosCasaMalAssombrada, 5);
        }
        else if (AkiraeHanna)
        {
            RespostaAkiraeHanna(5);
        }
        else if (possibilidadeDeNaoSeguirCooper)
        {
            NaoSeguirCooper();
        }
        else if (possibilidadeDeOlharOBeco) //Olhar o Beco
        {
            controleDialogos.botao4.text = "State the reason for the question";
            controleDialogos.botao5.text = "Say who you are";

            Debug.Log(perguntas);

            possibilidadeDeOlharOBeco = false;

            ativarDesativarTexto.AtivarAnimação1(5, "Finwick");
            ativarDesativarTexto.AtivarAnimação2(5, "Ran");
            ativarDesativarTexto.AtivarAnimação3(5, "Macula");

            tabelaAfinidades.AtualizarAfinidadeFenwick(5);
            tabelaAfinidades.AtualizarAfinidadeRan(5);
            tabelaAfinidades.AtualizarAfinidadeMacula(5);

            controleDialogos.PularTexto();
            controleDialogos.BotaoDePular.SetActive(true);

            Sprite[] sprites = { Player, Finwick, Finwick };
            Sprite[] bg = { cenaBC, cenaRP, cenaRP };
            string[] stringsTextos = { "<i>There was a dead monster at the end of that alley, I heard a conversation, two monsters talking about what happened. I just turned around and went on my way, whatever happened I don't want them to think it was me.</i>",
                                    "Who would have thought that a human could have such a strong aura that he could even look like us?",
                                    "My name is Finwick, if anyone says anything about me, don't believe them, I'm a little angel, and who are you?"};
            string[] stringsNomes = { nomeDoPersonagemPrincipal,"Unknown Monster 5", "Unknown Monster 5" };
            int sequencia = stringsTextos.Length;

            controleDialogos.PosPerguntas(sprites, bg, stringsTextos, stringsNomes, sequencia, true);

            controleDialogos.numeroQueDeveAparecerAsOpcoes = sequencia - 1; //Permite aparecer as opções

            controleDialogos.adicionarNovasStrings = false; //Impossibilita que possa chamar o a UNIÃO de galhos
        }
        else if (possibilidadeEscolherCerto)
        {
            controleDialogos.botao4.text = "Print the human way";
            controleDialogos.botao5.text = "Print the way Macula taught you";

            perguntas++;
            controleDialogos.perguntas++;

            Debug.Log("perguntas" + perguntas);
            Debug.Log("controleDialogos.perguntas" + controleDialogos.perguntas);

            possibilidadeEscolherCerto = false;

            ativarDesativarTexto.AtivarAnimação1(-10, "Boss");

            tabelaAfinidades.AtualizarAfinidadeChefe(-10);

            controleDialogos.PularTexto();
            controleDialogos.BotaoDePular.SetActive(true);

            Sprite[] sprites = { Player, Narrador };
            Sprite[] bg = { cenaSG, cenaSF };
            string[] stringsTextos = { "I don't know, but the cloud is Blue <i>(Gust informs me, begrudgingly, that it was Local B, Purple, he hands me the DIS and leaves)</i>",
            "<i>I left the room and went to the staff room to print out the document.</i>"};
            string[] stringsNomes = { nomeDoPersonagemPrincipal, ""};
            int sequencia = stringsTextos.Length;

            controleDialogos.PosPerguntas(sprites, bg, stringsTextos, stringsNomes, sequencia, true);

            controleDialogos.numeroQueDeveAparecerAsOpcoes = 0;

            controleDialogos.adicionarNovasStrings = false;
        }
    }

    private void RespostaCasaMalAssombrada(int pergunta, int opcaoEscolhida)
    {
        controleDialogos.numeroQueDeveAparecerAsOpcoes = -1;

        switch (pergunta)
        {
            case 0:
                {
                    controleDialogos.botao4.text = "Go with them";
                    controleDialogos.botao5.text = "Stay a little longer";

                    switch (opcaoEscolhida) // Think Positive & Think Negative
                    {
                        case 4:// Think Positive
                            {
                                galhosCasaMalAssombrada++;

                                ativarDesativarTexto.AtivarAnimação1(10, "Maya");

                                tabelaAfinidades.AtualizarAfinidadeMaya(10);

                                controleDialogos.PularTexto();
                                controleDialogos.BotaoDePular.SetActive(true);

                                Sprite[] sprites = { Player, Maya, Ran };
                                Sprite[] bg = { cenaCB, cenaCB, cenaC1 };
                                string[] stringsTextos = { "Well, we've only just arrived, and we haven't even done anything yet, maybe something will turn up later.",
                                    "You're right, I can't wait for the ritual <i>(Maya gives a smile, it looks like Ran is happy too)</i>",
                                    "Well, let's go down and find the others, shall we?!"};
                                string[] stringsNomes = { nomeDoPersonagemPrincipal, "Maya", "Ran" };
                                int sequencia = stringsTextos.Length;

                                controleDialogos.PosPerguntas(sprites, bg, stringsTextos, stringsNomes, sequencia, true);

                                controleDialogos.numeroQueDeveAparecerAsOpcoes = sequencia - 1;

                                break;
                            }
                        case 5:// Think Negative
                            {
                                galhosCasaMalAssombrada++;

                                ativarDesativarTexto.AtivarAnimação1(-10, "Maya");

                                tabelaAfinidades.AtualizarAfinidadeMaya(-10);

                                controleDialogos.PularTexto();
                                controleDialogos.BotaoDePular.SetActive(true);

                                Sprite[] sprites = { Player, Maya, Ran };
                                Sprite[] bg = { cenaCB, cenaCB, cenaC1 };
                                string[] stringsTextos = { "There's no such thing...",
                                    "You're so dull, you know that? It's Halloween, pretend you believe it. <i>(It seems that Maya turned her face away from me. It seems that Ren felt a bit uncomfortable)</i>",
                                    "Well, let's go down and find the others, shall we?!"};
                                string[] stringsNomes = { nomeDoPersonagemPrincipal, "Maya", "Ran" };
                                int sequencia = stringsTextos.Length;

                                controleDialogos.PosPerguntas(sprites, bg, stringsTextos, stringsNomes, sequencia, true);

                                controleDialogos.numeroQueDeveAparecerAsOpcoes = sequencia - 1;
                                break;
                            }
                    }
                    break;
                }
            case 1:
                {
                    casaMalAssombrada = false;
                    perguntas++;
                    controleDialogos.perguntas = perguntas;

                    controleDialogos.botao4.text = "Follow Cooper";
                    controleDialogos.botao5.text = "Don't follow Cooper";

                    // No próximo clique de botão vai verificar se vai clicar em NÃO seguir Cooper
                    possibilidadeDeNaoSeguirCooper = true;

                    switch (opcaoEscolhida) // Go with them & Stay a little longer
                    {
                        case 4:// Go with them
                            {
                                controleDialogos.adicionarNovasStrings = true;
                                controleDialogos.PularTexto();
                                break;
                            }
                        case 5:// Stay a little longer
                            {
                                controleDialogos.PularTexto();
                                controleDialogos.BotaoDePular.SetActive(true);

                                Sprite[] sprites = { Player, Narrador, Player };
                                Sprite[] bg = { cenaC1, cenaC1, cenaC1 };
                                string[] stringsTextos = { "Can you go ahead? I want to see that painting one more time. <i>(You could sense some fear coming from Ren, but Maya agreed and started pulling him towards the stairs)</i>",
                                    "<i>As soon as they'd finished going down the stairs, I went as quickly as possible to the room where Ren was, then I began to analyze the room once more, I saw a carpet full of dust on the floor and decided to remove it, so I could see a mandala on the floor, it didn't look fresh, but it was very recent.</i>",
                                    "Did Ran see that? <i>(I put the rug back and went downstairs to meet my friends)</i>"};
                                string[] stringsNomes = { nomeDoPersonagemPrincipal, "", nomeDoPersonagemPrincipal };
                                int sequencia = stringsTextos.Length;

                                controleDialogos.PosPerguntas(sprites, bg, stringsTextos, stringsNomes, sequencia, true);

                                controleDialogos.adicionarNovasStrings = true;
                                break;
                            }
                    }
                    break;
                }
        }
    }
    private void RespostaAkiraeHanna(int opcaoEscolhida)
    {
        controleDialogos.numeroQueDeveAparecerAsOpcoes = -1;

        AkiraeHanna = false;
        perguntas++;
        controleDialogos.perguntas = perguntas;

        controleDialogos.botao4.text = "Follow Cooper";
        controleDialogos.botao5.text = "Don't follow Cooper";

        // No próximo clique de botão vai verificar se vai clicar em NÃO seguir Cooper
        possibilidadeDeNaoSeguirCooper = true;

        switch (opcaoEscolhida) // Helping Akira & Do nothing
        {
            case 4:// Helping Akira
                {
                    ativarDesativarTexto.AtivarAnimação1(15, "Akira");

                    tabelaAfinidades.AtualizarAfinidadeMaya(15);

                    controleDialogos.PularTexto();
                    controleDialogos.BotaoDePular.SetActive(true);

                    Sprite[] sprites = { Player, Narrador };
                    Sprite[] bg = { cenaSB, cenaSB };
                    string[] stringsTextos = { "Let me get this stuff out of the middle of the room, we need a lot of space. Hanna, if you're too scared, come closer to Akira.",
                                    "<i>I sit down next to Akira, and as soon as I've finished, he smiles.</i>" };
                    string[] stringsNomes = { nomeDoPersonagemPrincipal, "" };
                    int sequencia = stringsTextos.Length;

                    controleDialogos.PosPerguntas(sprites, bg, stringsTextos, stringsNomes, sequencia, true);

                    controleDialogos.adicionarNovasStrings = true;
                    break;
                }
            case 5:// Do nothing
                {
                    ativarDesativarTexto.AtivarAnimação1(-15, "Akira");

                    tabelaAfinidades.AtualizarAfinidadeMaya(-15);

                    controleDialogos.PularTexto();
                    controleDialogos.BotaoDePular.SetActive(true);

                    Sprite[] sprites = { Akira, Hanna, Narrador };
                    Sprite[] bg = { cenaSB, cenaSB, cenaSB };
                    string[] stringsTextos = { "Hanna, can you move these objects away from where we're staying? To have more space.",
                                    "Yes, I can...",
                                    "<i>The player sits down next to Akira, but he doesn't seem to like it.</i>"};
                    string[] stringsNomes = { "Akira", "Hanna", "" };
                    int sequencia = stringsTextos.Length;

                    controleDialogos.PosPerguntas(sprites, bg, stringsTextos, stringsNomes, sequencia, true);

                    controleDialogos.adicionarNovasStrings = true;
                    break;
                }
        }
    }

    private void NaoSeguirCooper()
    {
        controleDialogos.PularTexto();
        controleDialogos.BotaoDePular.SetActive(true);

        Sprite[] sprites = { Player, Cooper, Gust, Player };
        Sprite[] bg = { cenaBC, cenaBC, cenaBC, cenaBC };
        string[] stringsTextos = { "Thanks, I guess, but I... I'll manage anyway, I still think it's a nightmare.",
                                    "It's up to you, but this is very real. <i>(Cooper walks away, while I try to pull myself together)</i>",
                                    "That bastard broke me, but not enough for me not to break you!",
                                    "Oh, no, get out, get out! HELPPP!!!! <i>(The monster advanced on me, strangling me once again, this time there was no one to help me, it was the end, my end...)</i>"};
        string[] stringsNomes = { nomeDoPersonagemPrincipal, "Cooper", "Unknown Monster 2", nomeDoPersonagemPrincipal };
        int sequencia = stringsTextos.Length;

        controleDialogos.PosPerguntas(sprites, bg, stringsTextos, stringsNomes, sequencia, true);

        controleDialogos.numeroQueDeveAparecerAsOpcoes = sequencia - 1;
    }

    private void Resposta(int pergunta, int opcaoEscolhida)
    {
        controleDialogos.numeroQueDeveAparecerAsOpcoes = -1;

        switch (pergunta)
        {
            case 1:
                {
                    controleDialogos.botao4.text = "Go with Ran and Maya";
                    controleDialogos.botao5.text = "Stay with Akira and Hanna";

                    switch (opcaoEscolhida)
                    {
                        case 4: //Verdade
                            {
                                //Aumentar Pergunta
                                perguntas++;
                                controleDialogos.perguntas = perguntas;

                                ativarDesativarTexto.AtivarAnimação1(-5, "Maya");
                                ativarDesativarTexto.AtivarAnimação2(-5, "Hanna");
                                ativarDesativarTexto.AtivarAnimação3(10, "Ran");

                                tabelaAfinidades.AtualizarAfinidadeMaya(-5);
                                tabelaAfinidades.AtualizarAfinidadeHanna(-5);
                                tabelaAfinidades.AtualizarAfinidadeRan(10);

                                controleDialogos.PularTexto();
                                controleDialogos.BotaoDePular.SetActive(true);

                                Sprite[] sprites = { Ran, Hanna, Akira, Maya };
                                Sprite[] bg = { cenaCS, cenaCS, cenaCS, cenaCS };
                                string[] stringsTextos = { "I'd be surprised if they slept before you.",
                                    "Seriously, it would be better if you lied <i>(rolls eyes)</i>, how can you slept, on such a crucial day?! You were supposed to leave two hours ago, you know that? You're late.",
                                    $"{nomeDoPersonagemPrincipal}, Amazing that you woke up when we called, you slept like a rock.",
                                    "Guys, can we leave this discussion on the way to the venue? We can't waste." };
                                string[] stringsNomes = { "Ran", "Hanna", "Akira", "Maya" };
                                int sequencia = stringsTextos.Length;

                                controleDialogos.PosPerguntas(sprites, bg, stringsTextos, stringsNomes, sequencia, true);

                                controleDialogos.adicionarNovasStrings = true;

                                break;
                            }
                        case 5: //Mentir
                            {
                                //Aumentar Pergunta
                                perguntas++;
                                controleDialogos.perguntas = perguntas; 

                                ativarDesativarTexto.AtivarAnimação1(5, "Maya");
                                ativarDesativarTexto.AtivarAnimação2(5, "Hanna");
                                ativarDesativarTexto.AtivarAnimação3(-10, "Ran");

                                tabelaAfinidades.AtualizarAfinidadeMaya(5);
                                tabelaAfinidades.AtualizarAfinidadeHanna(5);
                                tabelaAfinidades.AtualizarAfinidadeRan(-10);

                                controleDialogos.PularTexto();
                                controleDialogos.BotaoDePular.SetActive(true);

                                Sprite[] sprites = { Ran, Hanna, Akira, Maya };
                                Sprite[] bg = { cenaCS, cenaCS, cenaCS, cenaCS };
                                string[] stringsTextos = { "I hope so, really...",
                                    "At least the delay must have been worth it for you, Mommy and Daddy's little darling.",
                                    "It feels really good, doesn't it? Disobeying, I love it <i>(he laughs).</i>",
                                    "Can we please go? The clock is ticking, we can't waste too much time here." };
                                string[] stringsNomes = { "Ran", "Hanna", "Akira", "Maya" };
                                int sequencia = stringsTextos.Length;

                                controleDialogos.PosPerguntas(sprites, bg, stringsTextos, stringsNomes, sequencia, true);

                                controleDialogos.adicionarNovasStrings = true;

                                break;
                            }
                    }

                    break;
                }
            case 2:
                {
                    switch (opcaoEscolhida)
                    {
                        case 4://IR COM REN E MAYA
                            {
                                casaMalAssombrada = true;

                                controleDialogos.botao4.text = "Think Positive";
                                controleDialogos.botao5.text = "Think Negative";

                                ativarDesativarTexto.AtivarAnimação1(5, "Maya");
                                ativarDesativarTexto.AtivarAnimação2(5, "Ran");

                                tabelaAfinidades.AtualizarAfinidadeMaya(5);
                                tabelaAfinidades.AtualizarAfinidadeRan(5);

                                controleDialogos.PularTexto();
                                controleDialogos.BotaoDePular.SetActive(true);

                                controleDialogos.ZerarIndex();

                                Sprite[] sprites = { Player, Narrador, Maya, Ran, Player, Ran , Ran , Maya, Narrador, Maya , Ran , Maya, };
                                Sprite[] bg = { cenaCB, cenaCB, cenaC1, cenaC1, cenaC1, cenaC1, cenaC1, cenaC1, cenaC1, cenaCB, cenaCB, cenaCB };
                                string[] stringsTextos = { "I'm coming with you!",
                                    "<i>They go up the stairs, start calling for Ren, a noise is heard in the distance, a thump, at the end of the corridor, so Maya and the player hurry quickly to the room. When they get there, Ren is putting his hair back, with an expression of pain. He had hit his head on the wooden shelf.</i>",
                                    "Are you all right?",
                                    "I'm fine, I just hit my head on this wooden, but there's nothing to worry about.",
                                    "What were you doing?",
                                    "I was looking for anything that could have caused this house to be abandoned, like blood, rituals, ghosts, but I didn't find anything.",
                                    "I've looked all over and there's nothing if you want to look again.",
                                    "Let's take a look, at least maybe we'll be startled by something <i>(she laughs).</i>",
                                    "<i>Maya and I went out to look in the other rooms and ended up finding nothing. Ren comes to meet us.</i>",
                                    "How absurd! How can an abandoned house be empty?!",
                                    "Well, it's an abandoned house, what did you expect?",
                                    "I don't know, I wanted a ghost, something weird, supernatural..."};
                                string[] stringsNomes = { nomeDoPersonagemPrincipal, "", "Maya ", "Ran ", nomeDoPersonagemPrincipal, "Ran ", "Ran ", "Maya ", "", "Maya ", "Ran ", "Maya " };
                                int sequencia = stringsTextos.Length;

                                controleDialogos.PosPerguntas(sprites, bg, stringsTextos, stringsNomes, sequencia, true);

                                controleDialogos.numeroQueDeveAparecerAsOpcoes = sequencia - 1;

                                break;
                            }
                        case 5://FICAR COM AKIRA E HANNA
                            {
                                AkiraeHanna = true;

                                controleDialogos.botao4.text = "Helping Akira";
                                controleDialogos.botao5.text = "Do nothing";

                                ativarDesativarTexto.AtivarAnimação1(5, "Akira");
                                ativarDesativarTexto.AtivarAnimação2(5, "Hanna");

                                tabelaAfinidades.AtualizarAfinidadeAkira(5);
                                tabelaAfinidades.AtualizarAfinidadeHanna(5);

                                controleDialogos.PularTexto();
                                controleDialogos.BotaoDePular.SetActive(true);

                                controleDialogos.ZerarIndex();

                                Sprite[] sprites = { Player, Hanna, Akira, Narrador, Akira, Player, Akira };
                                Sprite[] bg = { cenaCB, cenaCB, cenaCB, cenaCB, cenaSB, cenaSB, cenaSB };
                                string[] stringsTextos = { "Go on! <i>(Akira, Hanna and I went to find the most spacious place in the house.)</i>",
                                    "I'm starting to regret coming, this place is scary.",
                                    "Relax Hanna, we're here with you.",
                                    "<i>They arrive in a room, most likely a “mini” library or office.</i>",
                                    "This room is huge, I wish my house had a room like this.",
                                    "One day, who knows, it won't!",
                                    "Yeah, who knows, well, I'll get all these things out of my backpack so we can get started." };
                                string[] stringsNomes = { nomeDoPersonagemPrincipal, "Hanna", "Akira ", "", "Akira", nomeDoPersonagemPrincipal, "Akira" };
                                int sequencia = stringsTextos.Length;

                                controleDialogos.PosPerguntas(sprites, bg, stringsTextos, stringsNomes, sequencia, true);

                                controleDialogos.numeroQueDeveAparecerAsOpcoes = sequencia - 1;

                                break;
                            }
                    }

                    break;
                }
            case 3: // Questioning Cooper's statement && Say nothing
                {
                    controleDialogos.botao4.text = "Continue following her";
                    controleDialogos.botao5.text = "Question what happened";

                    controleDialogos.numeroQueDeveAparecerAsOpcoes = -1; // Serve para não permitir que apareça as opçõse na hora errada

                    switch (opcaoEscolhida)
                    {
                        case 4: //Questioning Cooper's statement
                            {

                                perguntas++;
                                controleDialogos.perguntas = perguntas;

                                ativarDesativarTexto.AtivarAnimação1(-5, "Cooper");

                                tabelaAfinidades.AtualizarAfinidadeCooper(-5);

                                controleDialogos.PularTexto();
                                controleDialogos.BotaoDePular.SetActive(true);

                                controleDialogos.ZerarIndex();

                                Sprite[] sprites = { Player, Cooper };
                                Sprite[] bg = { cenaRC, cenaRC };
                                string[] stringsTextos = { "Hey, what do you mean start working?! I never said and you didn't say anything about it.",
                                    "Like I said, if you want to look like someone who's moved away, you'd better live life quietly." };
                                string[] stringsNomes = { nomeDoPersonagemPrincipal, "Cooper" };
                                int sequencia = stringsTextos.Length;

                                controleDialogos.PosPerguntas(sprites, bg, stringsTextos, stringsNomes, sequencia, true);

                                controleDialogos.adicionarNovasStrings = true; //Permite a UNIÃO de galhos

                                break;
                            }
                        case 5: //Say nothing
                            {

                                perguntas++;
                                controleDialogos.perguntas = perguntas;

                                ativarDesativarTexto.AtivarAnimação1(15, "Cooper");

                                tabelaAfinidades.AtualizarAfinidadeCooper(15);

                                controleDialogos.PularTexto();
                                controleDialogos.BotaoDePular.SetActive(true);

                                controleDialogos.ZerarIndex();

                                Sprite[] sprites = { Cooper, Cooper };
                                Sprite[] bg = { cenaRC, cenaRC };
                                string[] stringsTextos = { "He needs to look like someone who's moved to this city...",
                                    "...And it'll be good for me too, I'll have less work there." };
                                string[] stringsNomes = { "Cooper", "Cooper" };
                                int sequencia = stringsTextos.Length;

                                controleDialogos.PosPerguntas(sprites, bg, stringsTextos, stringsNomes, sequencia, true);

                                controleDialogos.adicionarNovasStrings = true; //Permite a UNIÃO de galhos


                                break;
                            }
                    }

                    break;
                }
            case 4: //Continue following her && Question what happened
                {
                    controleDialogos.botao4.text = "Say you don't feel like going now, calmly";
                    controleDialogos.botao5.text = "Saying that you don't want to go now, harshly";

                    controleDialogos.numeroQueDeveAparecerAsOpcoes = -1; // Serve para não permitir que apareça as opçõse na hora errada

                    perguntas++;
                    controleDialogos.perguntas = perguntas;

                    switch (opcaoEscolhida)
                    {
                        case 4: //Continue following her
                            {
                                ativarDesativarTexto.AtivarAnimação1(20, "Macula");
                                ativarDesativarTexto.AtivarAnimação2(10, "Boss");

                                tabelaAfinidades.AtualizarAfinidadeMacula(20);
                                tabelaAfinidades.AtualizarAfinidadeChefe(10);

                                controleDialogos.PularTexto();
                                controleDialogos.BotaoDePular.SetActive(true);

                                controleDialogos.ZerarIndex();

                                Sprite[] sprites = { Macula };
                                Sprite[] bg = { cenaCF };
                                string[] stringsTextos = { "By the way, that DIS was supposed to be plugged in, at the bottom of the tool, in red, don't forget <i>(I have no idea what DIS was)</i>" };
                                string[] stringsNomes = { "Macula" };
                                int sequencia = stringsTextos.Length;

                                controleDialogos.PosPerguntas(sprites, bg, stringsTextos, stringsNomes, sequencia, true);

                                controleDialogos.adicionarNovasStrings = true; //Permite a UNIÃO de galhos
                                break;
                            }
                        case 5: //Question what happened
                            {

                                ativarDesativarTexto.AtivarAnimação1(5, "Macula");
                                ativarDesativarTexto.AtivarAnimação2(-10, "Boss");

                                tabelaAfinidades.AtualizarAfinidadeMacula(5);
                                tabelaAfinidades.AtualizarAfinidadeChefe(-10);

                                controleDialogos.PularTexto();
                                controleDialogos.BotaoDePular.SetActive(true);

                                controleDialogos.ZerarIndex();

                                Sprite[] sprites = { Player, Macula };
                                Sprite[] bg = { cenaCF, cenaCF };
                                string[] stringsTextos = { "Why didn't you say or do anything to that monster?",
                                "You're here to work, not ask questions, and get used to it, either you do things right as you're told or you suffer the consequences, and by the way, that DIS was supposed to be plugged in, at the bottom of the tool, in red, don't forget it anymore <i>(I didn't want to ask what DIS was)</i>"};
                                string[] stringsNomes = { nomeDoPersonagemPrincipal, "Macula" };
                                int sequencia = stringsTextos.Length;

                                controleDialogos.PosPerguntas(sprites, bg, stringsTextos, stringsNomes, sequencia, true);

                                controleDialogos.adicionarNovasStrings = true; //Permite a UNIÃO de galhos
                                break;
                            }
                    }

                    break;
                }
            case 5: //Say you don't feel like going now, calmly && Saying that you don't want to go now, harshly
                {
                    controleDialogos.botao4.text = "Go straight to work";
                    controleDialogos.botao5.text = "Take a look at the end of the alley";

                    controleDialogos.numeroQueDeveAparecerAsOpcoes = -1; // Serve para não permitir que apareça as opçõse na hora errada

                    perguntas++;
                    controleDialogos.perguntas = perguntas;

                    Debug.Log(perguntas);

                    possibilidadeDeOlharOBeco = true;

                    switch (opcaoEscolhida)
                    {
                        case 4: //Say you don't feel like going now, calmly
                            {
                                ativarDesativarTexto.AtivarAnimação1(20, "Disha");

                                tabelaAfinidades.AtualizarAfinidadeDisha(20);

                                controleDialogos.PularTexto();
                                controleDialogos.BotaoDePular.SetActive(true);

                                controleDialogos.ZerarIndex();

                                Sprite[] sprites = { Player, Disha };
                                Sprite[] bg = { cenaRP, cenaRP };
                                string[] stringsTextos = { "I'm sorry, I can't right now, maybe next time.",
                                "Then I'll be waiting, I have to go <i>(The same way she arrived, very quickly, she left)</i>"};
                                string[] stringsNomes = { nomeDoPersonagemPrincipal, "Disha" };
                                int sequencia = stringsTextos.Length;

                                controleDialogos.PosPerguntas(sprites, bg, stringsTextos, stringsNomes, sequencia, true);

                                controleDialogos.adicionarNovasStrings = true; //Permite a UNIÃO de galhos
                                break;
                            }
                        case 5: //Saying that you don't want to go now, harshly
                            {
                                ativarDesativarTexto.AtivarAnimação1(-5, "Disha");

                                tabelaAfinidades.AtualizarAfinidadeDisha(-5);

                                controleDialogos.PularTexto();
                                controleDialogos.BotaoDePular.SetActive(true);

                                controleDialogos.ZerarIndex();

                                Sprite[] sprites = { Player, Disha };
                                Sprite[] bg = { cenaRP, cenaRP };
                                string[] stringsTextos = { "I've just left a job, and I don't fancy seeing little monsters near me right now! So if you could stop frightening me with that grip on my arm, I'd appreciate it.",
                                "Who do YOU think you ARE to talk to me like that?! if you don't show up at that club to buy something by tomorrow, you'll see what happens to you! <i>(The same way she arrived, very quickly, she left)</i>"};
                                string[] stringsNomes = { nomeDoPersonagemPrincipal, "Disha" };
                                int sequencia = stringsTextos.Length;

                                controleDialogos.PosPerguntas(sprites, bg, stringsTextos, stringsNomes, sequencia, true);

                                controleDialogos.adicionarNovasStrings = true; //Permite a UNIÃO de galhos
                                break;
                            }
                    }

                    break;
                }
            case 6: // State the reason for the question && Say who you are
                {
                    controleDialogos.botao4.text = "Say it all";
                    controleDialogos.botao5.text = "Hide some parts";

                    controleDialogos.numeroQueDeveAparecerAsOpcoes = -1; // Serve para não permitir que apareça as opçõse na hora errada

                    //-------------------------------------------------------------------------------------------------//
                    //------------- A partir daqui por algum motivo mudou a sequência de perguntas do outro script -----------------//
                    //-------------------------------------------------------------------------------------------------------------//

                    perguntas++;
                    controleDialogos.perguntas = 8;

                    switch (opcaoEscolhida)
                    {
                        case 4: //State the reason for the question
                            {
                                ativarDesativarTexto.AtivarAnimação1(-5, "Finwick");

                                tabelaAfinidades.AtualizarAfinidadeFenwick(-5);

                                controleDialogos.PularTexto();
                                controleDialogos.BotaoDePular.SetActive(true);

                                controleDialogos.ZerarIndex();

                                Sprite[] sprites = { Player, Finwick, Player };
                                Sprite[] bg = { cenaRP, cenaRP, cenaRP };
                                string[] stringsTextos = { "What kind of question is that? If you asked me my name I'd understand, but who am I? That's too much for someone I've only just met.",
                                "A human is rare around here and the fact that you're alive and well is very peculiar, I'd say. ",
                                $"Just so you leave me alone, my name is {nomeDoPersonagemPrincipal}, I ended up here because of a ridiculous ritual and I have no idea how to get out of here. And if I'm still alive it's because of Cooper, I don't know if you know him, he's a monster like Bigfoot."};
                                string[] stringsNomes = { nomeDoPersonagemPrincipal, "Finwick", nomeDoPersonagemPrincipal };
                                int sequencia = stringsTextos.Length;

                                controleDialogos.PosPerguntas(sprites, bg, stringsTextos, stringsNomes, sequencia, true);

                                controleDialogos.adicionarNovasStrings = true; //Permite a UNIÃO de galhos

                                break;
                            }
                        case 5: //Say who you are
                            {
                                ativarDesativarTexto.AtivarAnimação1(10, "Finwick");

                                tabelaAfinidades.AtualizarAfinidadeFenwick(10);

                                controleDialogos.PularTexto();
                                controleDialogos.BotaoDePular.SetActive(true);

                                controleDialogos.ZerarIndex();

                                Sprite[] sprites = { Finwick, Player };
                                Sprite[] bg = { cenaRP, cenaRP };
                                string[] stringsTextos = { "Strange question, but you're a human and here, humans don't often stop here, and you're still alive, I wonder what you are for such a feat.",
                                $"My name is {nomeDoPersonagemPrincipal}, I ended up here because of a ridiculous ritual and I have no idea how to get out of here. And if I'm still alive it's because of Cooper, I don't know if you know him, he's a monster like Bigfoot."};
                                string[] stringsNomes = { "Finwick", nomeDoPersonagemPrincipal };
                                int sequencia = stringsTextos.Length;

                                controleDialogos.PosPerguntas(sprites, bg, stringsTextos, stringsNomes, sequencia, true);

                                controleDialogos.adicionarNovasStrings = true; //Permite a UNIÃO de galhos
                                break;
                            }
                    }

                    break;
                }
            case 7:
                {
                    controleDialogos.botao1.text = "Location A, Green";
                    controleDialogos.botao2.text = "Location B, Purple"; 
                    controleDialogos.botao3.text = "Location C, Orange";

                    controleDialogos.numeroQueDeveAparecerAsOpcoes = -1; // Serve para não permitir que apareça as opçõse na hora errada

                    perguntas++;
                    controleDialogos.perguntas++;

                    Debug.Log("perguntas = " + perguntas);
                    Debug.Log("controleDialogos.perguntas = " + controleDialogos.perguntas);

                    switch (opcaoEscolhida)
                    {
                        case 4: // Say it all
                            {
                                ativarDesativarTexto.AtivarAnimação1(15, "Finwick");

                                tabelaAfinidades.AtualizarAfinidadeFenwick(15);

                                controleDialogos.PularTexto();
                                controleDialogos.BotaoDePular.SetActive(true);

                                controleDialogos.ZerarIndex();

                                //----------------------------------------------------------//
                                //------------- A partir daqui não sei os cenários -----------------//
                                //--------------------------------------------//

                                Sprite[] sprites = { Player, Finwick };
                                Sprite[] bg = { cenaRP, cenaRP }; ////////////////////////// A partir daqui não sei os cenários
                                string[] stringsTextos = { "I hated it, I'm just going to carry on, for the simple fact that I want to stay alive, that's if the monsters there don't kill me too, I almost got electrocuted yesterday and a monster punched me, and others pushed me, I don't doubt that they wanted me to hit my head and die, it was terrible.",
                                "With you too? So your experience wasn't that much worse than mine, by the way, if you're in the corridor, ignore everyone you can, otherwise you'll be an easy target, everyone there just wants to take their anger out on someone, so if you give them a break, it's over."};
                                string[] stringsNomes = { nomeDoPersonagemPrincipal, "Finwick" };
                                int sequencia = stringsTextos.Length;

                                controleDialogos.PosPerguntas(sprites, bg, stringsTextos, stringsNomes, sequencia, true);

                                controleDialogos.adicionarNovasStrings = true; //Permite a UNIÃO de galhos

                                break;
                            }
                        case 5: //Hide some parts
                            {
                                ativarDesativarTexto.AtivarAnimação1(10, "Finwick");
                                ativarDesativarTexto.AtivarAnimação2(5, "Macula");

                                tabelaAfinidades.AtualizarAfinidadeFenwick(10);
                                tabelaAfinidades.AtualizarAfinidadeMacula(5);

                                controleDialogos.PularTexto();
                                controleDialogos.BotaoDePular.SetActive(true);

                                controleDialogos.ZerarIndex();

                                Sprite[] sprites = { Player, Finwick };
                                Sprite[] bg = { cenaRP, cenaRP };
                                string[] stringsTextos = { "I hated it, I'm just going to carry on, for the simple reason that I want to stay alive, if the monsters there don't kill me.",
                                $"And this hatred will only increase, I can assure you."};
                                string[] stringsNomes = { nomeDoPersonagemPrincipal, "Finwick" };
                                int sequencia = stringsTextos.Length;

                                controleDialogos.PosPerguntas(sprites, bg, stringsTextos, stringsNomes, sequencia, true);

                                controleDialogos.adicionarNovasStrings = true; //Permite a UNIÃO de galhos
                                break;
                            }
                    }

                    break;
                }
            case 8: // Location A, Green && Location B, Purple && Location C, Orange
                {

                    controleDialogos.numeroQueDeveAparecerAsOpcoes = -1; // Serve para não permitir que apareça as opçõse na hora errada

                    perguntas++;
                    controleDialogos.perguntas++;

                    

                    controleDialogos.duasOp = true;

                    switch (opcaoEscolhida) 
                    {
                        case 1: //Location A, Green
                            {
                                controleDialogos.botao4.text = "Location B, Purple";
                                controleDialogos.botao5.text = "Location C, Orange";

                                possibilidadeEscolherCerto = true;

                                ativarDesativarTexto.AtivarAnimação1(-10, "Boss");

                                tabelaAfinidades.AtualizarAfinidadeChefe(-10);

                                controleDialogos.PularTexto();
                                controleDialogos.BotaoDePular.SetActive(true);

                                controleDialogos.ZerarIndex();

                                Sprite[] sprites = { Gust };
                                Sprite[] bg = { cenaSG };
                                string[] stringsTextos = { "You're wrong, this DIS doesn't have access to this Location, the Location is the color of the DIS Plug plus the color of its Cloud." };
                                string[] stringsNomes = { "Gust" };
                                int sequencia = stringsTextos.Length;

                                controleDialogos.PosPerguntas(sprites, bg, stringsTextos, stringsNomes, sequencia, true);

                                controleDialogos.adicionarNovasStrings = false; //NÃO Permite a UNIÃO de galhos

                                controleDialogos.numeroQueDeveAparecerAsOpcoes = sequencia - 1;

                                break;
                            }
                        case 2: //Location B, Purple
                            {
                                controleDialogos.botao4.text = "Print the human way";
                                controleDialogos.botao5.text = "Print the way Macula taught you";

                                perguntas++;
                                controleDialogos.perguntas++;

                                Debug.Log("perguntas" + perguntas);
                                Debug.Log("controleDialogos.perguntas" + controleDialogos.perguntas);

                                ativarDesativarTexto.AtivarAnimação1(20, "Boss");

                                tabelaAfinidades.AtualizarAfinidadeChefe(20);

                                controleDialogos.PularTexto();
                                controleDialogos.BotaoDePular.SetActive(true);

                                controleDialogos.ZerarIndex();

                                Sprite[] sprites = { Gust, Player };
                                Sprite[] bg = { cenaSG, cenaSF };
                                string[] stringsTextos = { "At least you know this, here you DIS. (Gust leaves)",
                                        "<i>I left the room and went to the staff room to print out the document.</i>"};
                                string[] stringsNomes = { "Gust", nomeDoPersonagemPrincipal };
                                int sequencia = stringsTextos.Length;

                                controleDialogos.PosPerguntas(sprites, bg, stringsTextos, stringsNomes, sequencia, true);

                                controleDialogos.adicionarNovasStrings = false; //NÃO Permite a UNIÃO de galhos

                                controleDialogos.numeroQueDeveAparecerAsOpcoes = sequencia - 1;

                                break;
                            }
                        case 3: //Location C, Orange
                            {
                                controleDialogos.botao4.text = "Location B, Purple";
                                controleDialogos.botao5.text = "Location A, Green";

                                possibilidadeEscolherCerto = true;

                                ativarDesativarTexto.AtivarAnimação1(-10, "Boss");

                                tabelaAfinidades.AtualizarAfinidadeChefe(-10);

                                controleDialogos.PularTexto();
                                controleDialogos.BotaoDePular.SetActive(true);

                                controleDialogos.ZerarIndex();

                                Sprite[] sprites = { Gust };
                                Sprite[] bg = { cenaSG };
                                string[] stringsTextos = { "You're wrong, this DIS doesn't have access to this Location, the Location is the color of the DIS Plug plus the color of its Cloud." };
                                string[] stringsNomes = { "Gust" };
                                int sequencia = stringsTextos.Length;

                                controleDialogos.PosPerguntas(sprites, bg, stringsTextos, stringsNomes, sequencia, true);

                                controleDialogos.adicionarNovasStrings = false; //NÃO Permite a UNIÃO de galhos

                                controleDialogos.numeroQueDeveAparecerAsOpcoes = sequencia - 1;

                                break;
                            }
                    }

                    break;
                }
            case 10: //Print the human way && Print the way Macula taught you
                {
                    controleDialogos.botao4.text = "Don´t  Talk to Disha";
                    controleDialogos.botao5.text = "Talk to Disha";

                    controleDialogos.numeroQueDeveAparecerAsOpcoes = -1; // Serve para não permitir que apareça as opçõse na hora errada

                    perguntas++;
                    controleDialogos.perguntas++;

                    switch (opcaoEscolhida)
                    {
                        case 4://Print the human way
                            {
                                ImprimirDoJeitoMacula = false;

                                ativarDesativarTexto.AtivarAnimação1(-10, "Boss");

                                tabelaAfinidades.AtualizarAfinidadeChefe(-10);

                                controleDialogos.PularTexto();
                                controleDialogos.BotaoDePular.SetActive(true);

                                controleDialogos.ZerarIndex();

                                Sprite[] sprites = { Narrador };
                                Sprite[] bg = { cenaSF };
                                string[] stringsTextos = { "<i>Printing takes longer than usual, I should have done it as Macula had taught me...</i>" };
                                string[] stringsNomes = { "" };
                                int sequencia = stringsTextos.Length;

                                controleDialogos.PosPerguntas(sprites, bg, stringsTextos, stringsNomes, sequencia, true);

                                controleDialogos.adicionarNovasStrings = true; //Permite a UNIÃO de galhos
                                break;
                            }
                        case 5://Print the way Macula taught you
                            {
                                ImprimirDoJeitoMacula = true;

                                ativarDesativarTexto.AtivarAnimação1(10, "Boss");

                                tabelaAfinidades.AtualizarAfinidadeChefe(10);

                                controleDialogos.PularTexto();
                                controleDialogos.BotaoDePular.SetActive(true);

                                controleDialogos.ZerarIndex();

                                Sprite[] sprites = { Narrador };
                                Sprite[] bg = { cenaSF };
                                string[] stringsTextos = { "<i>The printing was very fast and there don't seem to be any errors.</i>" };
                                string[] stringsNomes = { "" };
                                int sequencia = stringsTextos.Length;

                                controleDialogos.PosPerguntas(sprites, bg, stringsTextos, stringsNomes, sequencia, true);

                                controleDialogos.adicionarNovasStrings = true; //Permite a UNIÃO de galhos
                                break;
                            }
                    }

                    break;
                }
            case 11: //Don´t Talk to Disha && Talk to Disha
                {
                    controleDialogos.botao4.text = "Cold answer";
                    controleDialogos.botao5.text = "Answer worriedly";

                    controleDialogos.numeroQueDeveAparecerAsOpcoes = -1; // Serve para não permitir que apareça as opçõse na hora errada

                    perguntas++;
                    controleDialogos.perguntas++;
                    switch (opcaoEscolhida)
                    {
                        case 4://Don´t Talk to Disha
                            {
                                ativarDesativarTexto.AtivarAnimação1(-10, "Disha");
                                ativarDesativarTexto.AtivarAnimação2(-10, "Finwick");

                                tabelaAfinidades.AtualizarAfinidadeDisha(-10);
                                tabelaAfinidades.AtualizarAfinidadeFenwick(-10);

                                controleDialogos.PularTexto();
                                controleDialogos.BotaoDePular.SetActive(true);

                                controleDialogos.ZerarIndex();

                                Sprite[] sprites = { Player, Hannasombra, Player, Narrador, Player, Hanna, Hanna };
                                Sprite[] bg = { cenaBC, cenaBC, cenaBC, cenaBC, cenaBC, cenaQI, cenaQI };
                                string[] stringsTextos = { "Huh?! What was that? <i>(I hear a scream, extremely familiar, on impulse, I run to the end of the alley to find out what's going on)</i>",
                                "I'll never be anyone's doormat! Neither alive nor dead!",
                                "WHAT?! Hanna?!!! <i>(One of the monsters was the one that chased me when I arrived)</i>",
                                "<i>Somehow they just left.</i>",
                                "<i>Hanna, what- how are you here? Wait, Let's get out of here, let's go to my apartment. (I take her hand and lead her to my room)</i>",
                                "I thought I was alone here, if you're here, it means the others are too?! <i>(With her here, it means the others were too, I'm glad I'm not alone)</i>",
                                "Those monsters! If I could, I'd wipe them all out, they've been chasing me ever since I got here, and how was it with you? and how did you manage to do that, scare them away?" };
                                string[] stringsNomes = { nomeDoPersonagemPrincipal, "Unknown Person", nomeDoPersonagemPrincipal, "", nomeDoPersonagemPrincipal, "Hanna", "Hanna" };
                                int sequencia = stringsTextos.Length;

                                controleDialogos.PosPerguntas(sprites, bg, stringsTextos, stringsNomes, sequencia, true);

                                controleDialogos.adicionarNovasStrings = false; // NÃO Permite a UNIÃO de galhos

                                controleDialogos.numeroQueDeveAparecerAsOpcoes = sequencia - 1;

                                break;
                            }
                        case 5:// Talk to Disha
                            {
                                ativarDesativarTexto.AtivarAnimação1(20, "Disha");
                                ativarDesativarTexto.AtivarAnimação2(15, "Finwick");

                                tabelaAfinidades.AtualizarAfinidadeDisha(20);
                                tabelaAfinidades.AtualizarAfinidadeFenwick(15);

                                controleDialogos.PularTexto();
                                controleDialogos.BotaoDePular.SetActive(true);

                                controleDialogos.ZerarIndex();

                                Sprite[] sprites = { Disha, Player, Disha, Player, Hannasombra, Player, Narrador, Player, Hanna, Hanna };
                                Sprite[] bg = { cenaBT, cenaBT, cenaBT, cenaBC, cenaBC, cenaBC, cenaBC, cenaBC, cenaQI, cenaQI };
                                string[] stringsTextos = { "How can I help? (Does she even remember me?)",
                                "I haven't received any money yet, so maybe next time I'll buy some, I came to talk to you since you told me to come by.",
                                "Did you really come? I'm sorry for anything I've done, my dear, don't take the things I say seriously, sometimes I can sound crazy, haha, but I'm glad you came, thank you, if you'll excuse me I have some clients to see, come by in the morning and we'll have a chat. <i>(I confirm and leave)</i>",
                                "Huh?! What was that? <i>(I hear a scream, extremely familiar, on impulse, I run to the end of the alley to find out what's going on)</i>",
                                " I'll never be anyone's doormat! Neither alive nor dead!",
                                "WHAT?! Hanna?!!! <i>(One of the monsters was the one that chased me when I arrived)</i>",
                                "<i>Somehow they just left.</i>",
                                "<i>Hanna, what- how are you here? Wait, Let's get out of here, let's go to my apartment. (I take her hand and lead her to my room)</i>",
                                "I thought I was alone here, if you're here, it means the others are too?! <i>(With her here, it means the others were too, I'm glad I'm not alone)</i>",
                                "Those monsters! If I could, I'd wipe them all out, they've been chasing me ever since I got here, and how was it with you? and how did you manage to do that, scare them away?" };
                                string[] stringsNomes = { "Disha",nomeDoPersonagemPrincipal, "Disha", nomeDoPersonagemPrincipal, "Unknown Person", nomeDoPersonagemPrincipal, "", nomeDoPersonagemPrincipal, "Hanna", "Hanna" };
                                int sequencia = stringsTextos.Length;

                                controleDialogos.PosPerguntas(sprites, bg, stringsTextos, stringsNomes, sequencia, true);

                                controleDialogos.adicionarNovasStrings = false; // NÃO Permite a UNIÃO de galhos

                                controleDialogos.numeroQueDeveAparecerAsOpcoes = sequencia - 1;
                                break;
                            }
                    }
                    

                    break;
                }
            case 12: //Cold answer && Answer worriedly
                {
                    controleDialogos.botao4.text = "No, but they almost were. (truth)";
                    controleDialogos.botao5.text = "Yes, they did. (lie)";

                    controleDialogos.numeroQueDeveAparecerAsOpcoes = -1; // Serve para não permitir que apareça as opçõse na hora errada

                    perguntas++;
                    controleDialogos.perguntas++;

                    Debug.Log("Antes perguntas " + perguntas);
                    Debug.Log("Antes controleDialogos.perguntas " + controleDialogos.perguntas);

                    switch (opcaoEscolhida)
                    {
                        case 4: //Cold answer
                            {
                                respondeuHannaFriamente = true;

                                ativarDesativarTexto.AtivarAnimação1(-10, "Hanna");

                                tabelaAfinidades.AtualizarAfinidadeDisha(-10);

                                controleDialogos.PularTexto();
                                controleDialogos.BotaoDePular.SetActive(true);

                                controleDialogos.ZerarIndex();

                                Sprite[] sprites = { Player, Hanna };
                                Sprite[] bg = { cenaQI, cenaQI };
                                string[] stringsTextos = { "And how would I know that?! Anyway, all the monsters here are terrible. Get used to it.",
                                "And you're no worse than them! <i>(I seem to have stressed her out even more)</i>"};
                                string[] stringsNomes = { nomeDoPersonagemPrincipal, "Hanna" };
                                int sequencia = stringsTextos.Length;

                                controleDialogos.PosPerguntas(sprites, bg, stringsTextos, stringsNomes, sequencia, true);

                                controleDialogos.adicionarNovasStrings = true; // Permite a UNIÃO de galhos

                                break;
                            }
                        case 5://Answer worriedly
                            {
                                respondeuHannaFriamente = false;

                                ativarDesativarTexto.AtivarAnimação1(15, "Hanna");

                                tabelaAfinidades.AtualizarAfinidadeDisha(15);

                                controleDialogos.PularTexto();
                                controleDialogos.BotaoDePular.SetActive(true);

                                controleDialogos.ZerarIndex();

                                Sprite[] sprites = { Player, Hanna };
                                Sprite[] bg = { cenaQI, cenaQI };
                                string[] stringsTextos = { "A monster helped me when I first got here and I don't know why the ones now gone have left. But changing the subject, how are you?",
                                "I'm fine, at least now... <i>(She calmed down)</i>"};
                                string[] stringsNomes = { nomeDoPersonagemPrincipal, "Hanna" };
                                int sequencia = stringsTextos.Length;

                                controleDialogos.PosPerguntas(sprites, bg, stringsTextos, stringsNomes, sequencia, true);

                                controleDialogos.adicionarNovasStrings = true; // Permite a UNIÃO de galhos
                                break;
                            }
                    }
                    break;
                }
        }
        
        

        controleDialogos.DuasOpcoes.SetActive(false);
    }
}
