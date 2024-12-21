using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
using UnityEngine.UIElements.Experimental;

public class UniaoGalhos : MonoBehaviour
{
    public string nomeDoPersonagemPrincipal;
    private TabeladeAfinidades tabeladeAfinidades;
    private AtivarDesativarTexto ativarDesativarTexto;
    private ControleDialogos controleDialogos;
    private Teste teste;

    public GameObject objetoDosTextos;
    public GameObject objetoDoControleDialogos;
    public GameObject objetoDaTabela;

    private sbyte falarComFinwick = 0;//0 = NULO, 1 = VERDADEIRO, 2 = FALSE
    private bool permiteFalarComFenwick = false;
    private bool pontuarImprimirJeitoMacula = true;

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

    public void Start()
    {
        tabeladeAfinidades = objetoDaTabela.GetComponent<TabeladeAfinidades>();
        ativarDesativarTexto = objetoDosTextos.GetComponent<AtivarDesativarTexto>();
        controleDialogos = objetoDoControleDialogos.GetComponent<ControleDialogos>();
        teste = objetoDoControleDialogos.GetComponent<Teste>();
    }

    public void FixedUpdate()
    {
        if (teste.ImprimirDoJeitoMacula && pontuarImprimirJeitoMacula)
        {
            pontuarImprimirJeitoMacula = false;
            tabeladeAfinidades.AtualizarAfinidadeMacula(5);
            ativarDesativarTexto.AtivarAnimação1(5, "Macula");
        }
        
        if (falarComFinwick == 1) //0 = NULO, 1 = VERDADEIRO, 2 = FALSE
        {
            falarComFinwick = 0;

            permiteFalarComFenwick = true;

            tabeladeAfinidades.AtualizarAfinidadeMacula(5);
            ativarDesativarTexto.AtivarAnimação1(5, "Macula");
        }
        else if (falarComFinwick == 2) //0 = NULO, 1 = VERDADEIRO, 2 = FALSE
        {
            falarComFinwick = 0;

            permiteFalarComFenwick = false;

            tabeladeAfinidades.AtualizarAfinidadeMacula(5);
            ativarDesativarTexto.AtivarAnimação1(5, "Macula");
        }
    }

    public string[] UniaoDeGalhosDialogos(int x)
    {
        string[] resultado = new string[] { "" };

        switch (x)
        {
            case 2:
                {
                    resultado = new string[]{ "<i>They go to an abandoned residence that was about 10 to 15 minutes away from my house.They leave their bikes on the lawn in front of the house and break in. Arriving at the house, they turn on their flashlights and look around to see if there's anything there.</i>",
                    "Hoho! So I've finally broken into a house, I can't wait to tell my grandchildren about it.",
                    "That's if you survive today.",
                    "I don't know about you, but I'm going to take a look at the rooms upstairs. (The four of them look around the group, wondering what they're going to do)</i>",
                    "I'll go with Ren, Hanna you stay with Akira, he's the strongest and isn't afraid of cockroaches and spiders, you'll be fine.",
                    $"{nomeDoPersonagemPrincipal}, do you want to come with me or stay with Akira?"};
                    break;
                }
            case 3:
                {
                    resultado = new string[] { "<i>It didn't take long for the group to reconvene. Akira then takes the last item missing from his backpack, a book on the occult, and Hanna begins to worry.</i>",
                    "Guys, don't you think we should forget about this and enjoy Halloween like everyone else?",
                    "But let's enjoy it, how about making a ouija board?",
                    "<i>With the exception of Hanna, everyone agreed, and so began our Halloween day. We played for quite a while, until Ren picked up his book, he didn't want to use Akira's at all, for some reason. Ren flipped through the pages and read out a few rituals of his choice for us to perform, our group choosing to try and trap a demon in a glass container.</i>",
                    "Come on then <i>(Ren frowns) well—</i>",
                    "Don't try to change the choice, if it happens, you'll see.",
                    "I won't, relax, well here, say open the glass jar with the lid on top, half open half closed, in the center of the circle, once that's done we have to hold hands and I have to recite a few things.",
                    "<i>Everyone followed the steps to the letter, but when we finished the circle on the floor, we started to hear grunts, and not only that, but the house started to shake and everything around us fell down. Ren began to say a few words while the rest of us had our eyes closed, and at this point, I just wanted to go home.</i>",
                    "Holy shit! What the fuck is that?!",
                    "<i>Everyone looked where Akira pointed, it was a sinister portal, everyone dropped their hands and looked at each other, I just thought I'd turn around, just as I was about to get up, gravity changed, from the earth to that portal.</i>",
                    "No, no, no, no, Ahhhhhhhhh!",
                    "<i>Everything goes dark for a while, until it starts to take shape, but this isn't the abandoned house, not really, you can see the deserted red sky, and a huge factory on fire.</i>",
                    "W-What happened? Where am I, people?! <i>(There was no one else with him)</i>",
                    "<i>It was now possible to hear various grunts and roars, it was astonishing now that I started to pay attention, they were various... monsters.</i>",
                    
                    //Ato 1
                    
                    "Why are there so many monsters?! This can only be a nightmare <i>(I pinch myself)</i>",
                    "It can't be real! <i>(I rush into an alleyway, so as not to be seen)</i>",
                    "What the fuck happened? How did I get here? How am I going to get out of here?! <i>(I start walking down the alley)</i>",
                    "What was that? <i>(A sound began to approach)</i>",
                    "Ahhh, let me go! <i>(A monster appears at the speed of sound, grabbing me by one of my arms)</i>",
                    "Over here! I told you he was here.",
                    "Look, it's rare to see a human here! <i>(I keep struggling to get out of the monster's hands and I manage to do so. I run as fast as I can and lock myself in one of the buildings where the door was open)</i>",
                    "What the hell, you little human, open the door!",
                    "I don't think he'll want to open it Haha! <i>(I hadn't seen it but there was a monster on the first floor of the building looking out of the window, seeing the monsters that were chasing me) </i>",
                    "Look, that door won't hold for long. You can't go into other people's houses and have the door break down, you know that? <i>(He starts down the stairs)",
                    "I'm sorry, forgive me, I didn't mean to do that, it's just that I didn't know where to go and hide.",
                    "Oh, you poor thing, but if I just leave you here, I'll be the one to lose out.",
                    "Please! Let me stay here, those monsters are... are..., I could die out there.",
                    "Of course! You're human after all, it's fun.",
                    "Yeah! That's a nightmare for sure, what a joke, it could only have been after that ritual, and at some point I must have fallen asleep.",
                    "HAHAHA! You did a ritual to come here?! Well, I'm Coo-...per.",
                    "AHHHHHHHHHHHH! <i>(The other monsters managed to break down the door)</i>",
                    "Now you won't escape  <i>(The monster started to strangle me, I started to feel short of breath)</i>",
                    "H... Hel...-  <i>(Cooper and some mini creatures attacked the two monsters, releasing me)</i>",
                    "Oh... my God... thank you...",
                    "Don't get me wrong, but I didn't want you to ask for help, I didn't want anyone to see me helping someone who asked for help.",
                    "Anyway, the monsters know who is from outside this world and who is from another city, if you want to stay alive, the second option is better, so you'd better find an apartment as soon as possible.",
                    "Now I have to go, I have to find someone to fix my door...argh...coincidentally it's in an apartment…"};
                    break;
                }
            case 4:
                {
                    resultado = new string[] { "If everything is alright, your room will be 666, don't make me repeat myself, it will already be open, and Cooper, an acquaintance, will come by to fix your door. <i>(Cooper thanks her and leaves, I follow him on his way to work)</i>",
                    "<i>[Time Break]</i>",
                    "Cooper! Punctual as always, not to say otherwise, I don't want to hear any excuses this time. <i>(The monster was furious)</i>",
                    "Boss, I brought you this young bumpkin who's looking for work",
                    "Interesting... very interesting, you'll get away with it this time Cooper. But if you are late again…, Macula! Present the space to him. <i>(As if by magic, another monster appeared, she's the most human monster I've met so far)</i>",
                    "Follow me immediately! <i>(I simply nodded and began to follow her)</i>",
                    "This is the corridor, if you don't want to work just avoid it, if you can of course.",
                    "Macula! This one next to you, hand this to him, I need it signed as soon as possible <i>(I get a property division paper, what does this factory do anyway?)</i>",
                    "You've been asked to sign this document, the person who does this is in the staff room. <i>(Someone grabs my arm)</i>",
                    "Come here immediately, I need you! <i>(The monster pulled me into a room that looked like a generator room? Macula ended up following me)</i>",
                    "Here, take this for me and lift it up, now, you should put it in the tool room.",
                    "Wait, I - I'm new, I don't know what I have to do, Macula is still introducing me o-",
                    "And I'm a son of a bitch, just do what I say. <i>(I put whatever it is in my hands, and ended up getting a hell of a shock, letting what he was holding fall to the ground, the only thing Macula does is write something down in her notebook)</i>",
                    "You wretch! Look what you've done, you've ruined all my work, who do you think you are?! <i>(Still recovering from the shock, the monster punches me)</i>",
                    "Get out of my way, NOW! <i>(I was still on the floor when Macula started to pull my foot, dragging me out of the room where the monster was, but not by much, as I ended up getting up)</i>",
                    "That's the Management and Generators room, normally, if you want to get a document to print, you have to get it from the cloud in that room. <i>(Macula speaks so calmly, it's like she didn't even see what happened back there)</i>",
};
                    break;
                }
            case 5:
                {

                    resultado = new string[] { "<i>Macula showed me to the boss's office, telling me that this was where I delivered most of the documentation, when it wasn't to be delivered directly to the person who had given me the task.</i>",
                    "<i>Then she introduced me to the staff room and taught me how to use their printing machine with the DIS, which I still don't know what it means, but it not only works for uploading data, but also for repairing machines.</i>",
                    "<i>I ended up meeting the monster who was supposed to sign the paper I'd been given, who had a lot of paperwork to sign, took mine and threw it in my face, apparently he only grabbed my paper quickly because Macula was next to me.</i>",
                    "Here it is! <i>(Still with Macula by my side, I went back to the corridor where I started to hand the signed paper to that official from before)</i>",
                    "Don't you know what fast means, human?! <i>(The monster took the paper from my hand and started walking, bumping into me, I staggered)</i>",
                    "That's it for today, you can go home and be ready for tomorrow.",
                    "<i>I left work in the direction of the apartment, I'm extremely exhausted, I just want to lie down, if there's a bed like this place is, maybe what Cooper said was true, since the monsters aren't staring at me anymore, I'm more relaxed about it.</i>",
                    "Hey! Psst! <i>(A monster spoke in my direction, but I just ignored it, it certainly wasn't me)</i>",
                    "I'M CALLING YOU! I'm Disha, why don't you come to my nightclub and have a few drinks?",
                    "<i>(This monster grabbed my arm and put a lot of pressure on it, I thought I was going to lose the mobility of my hands)</i>" };

                    break;
                }
            case 6:
                {
                    resultado = new string[] { "<i>I returned to the apartment, Iva was reading a newspaper, when she saw me she stared at me, with a face that was not at all inviting, I immediately went out to look for my room, I found it without any problems with the lock on the door broken, but at that point I didn't even care and rolled over in bed.]</i>",
                    "<i>I kept thinking about what happened with the ritual, I remembered the portal that appeared, whatever it is, it's real, and I have no idea how to get back, the only thing I can do now is do everything I can not to die.</i>", 
                    
                    //ATO 2

                    "<i>[Crash].</i>",
                    "What was that? <i>(I go to the window)</i>",
                    "Oh my God! That was a robbery! I hope they manage to catch the thief... It's really difficult here. I'm going to organize my thoughts and then go to work.",
                    "<i>I end up deciding not to leave the apartment until it's time to go to work.</i>",
                    "Don't look in the alley back there (The receptionist seems to speak with a bitter tone, but this time I don't think it's for me, so I leave the apartment)" };

                    break;
                }
            case 7:
                {
                    resultado = new string[] { "Who would have thought that a human could have such a strong aura that he could even look like us?",
                    "My name is Finwick, if anyone says anything about me, don't believe them, I'm a little angel, and who are you?", };

                    break;
                }
            case 8:
                {
                    resultado = new string[] { "A ritual, interesting, and Cooper, I know him, I used to work at the factory before I resigned...",
                    "I saw that you started working there, what did you think?" };

                    break;
                }
            case 9:
                {
                    if (tabeladeAfinidades.Fenwick <= 5)
                    {
                        resultado = new string[] { "Don't expect anyone to help you there, and don't even talk, and if you come across someone talking, ignore them...",
                        "...it's the best option for you to be less hated, and for the disgraced secretary not to want to do anything to you.",
                        "I'm going now. <i>(That was very strange, I kept looking where he was going, he ended up turning the corner)</i>",
                        "Newbie, come here! <i>(I decide not to ignore it)</i>",
                        "I want you to get the data for the new recipe for the products being manufactured in the company, the Color of the Cloud is Blue, here's the DIS. <i>(He hands me the DIS)</i>",
                        "All right! I won't be long.",
                        "Hi! I want to make a dice roll for the cloud.",
                        "Oh, is that you?! Huh... to where? You know at least that much, right?"};
                    }
                    else if (tabeladeAfinidades.Fenwick > 5)
                    {
                        resultado = new string[] { "Don't expect anyone to help you there, and don't even talk, and if you come across someone talking, ignore them...",
                        "...it's the best option for you to be less hated, and for the disgraced secretary not to want to do anything to you.",
                        "Did you know that she got her job as secretary by putting some monsters in the factory oven? And she also made everyone listen to their screams every day at work, just so that the boss could tame his employees.",
                        "It was a tremendous liberation for me to leave that factory, you have no idea, well, I'm going now, I have to work, stop by the nightclub later.",
                        "Newbie, come here! <i>(I decide not to ignore it)</i>",
                        "I want you to get the data for the new recipe for the products being manufactured in the company, the Color of the Cloud is Blue, here's the DIS. <i>(He hands me the DIS)</i>",
                        "All right! I won't be long.",
                        "Hi! I want to make a dice roll for the cloud.",
                        "Oh, is that you?! Huh... to where? You know at least that much, right?" };
                    }

                    break;
                }
            case 12:
                { 
                    if (teste.ImprimirDoJeitoMacula && permiteFalarComFenwick)
                    {
                        resultado = new string[] { "Here Cien!",
                        "<i>I hand over the DIS and the document.</i>",
                        "Wow, that's fast... congratulations... another thing, Cooper is waiting for you in the Chief's Office for I don't know what.",
                        "You're here! Actually, I just wanted to tell you that there's a party at the nightclub tonight, it would be good if you went to get along, it's 2 blocks from the factory.",
                        "What's all this talk about, Cooper? <i>(Cooper starts saying some words that I have no idea what they mean)</i>",
                        "Oh yes! Well, I'm going there. If you want me to show you the way, just follow me.",
                        "<i>The nightclub had several things that were similar or practically the same as my world, such as discos, well-padded armchairs and other things. I continued to follow Macula to the VIP part of the nightclub.</i>",
                    "The club allows a lot of things, so don't be surprised if you see something different. And again, this is the only time I've come with you, so don't get used to it.",
                    "How did you get here? <i>(Of course, she volunteered to show me around, out of pure interest)</i>",
                    "My friends and I went to do a ritual to trap a monster, but it ended up going wrong somehow and I ended up here, we followed our friend Ran's book, it had a reddish brown cover, a symbol of a bug's head made in bone around a circle with some studs, if I remember correctly. <i>(Macula gets pensive)</i>",
                    "Do you know anything? Or how to get me out of here?",
                    "No, I was wondering if you knew anything like that around here, but she doesn't. <i>(She doesn't hide her disappointment, but I wonder if the book is related to the factory in any way.)</i>",
                        "How did you get to your position as Secretary, if you don't mind me asking?",
                        "I often come to this club, I ended up losing my memory as a teenager, I always have this need to come here, even if I don't drink or do anything, and one of these nights, I saw the Boss for the first time, when he was still allowed to leave the factory, while he was having fun some employees tried to assassinate him, because of the extremely exhausting work.",
                        "I managed to stop them, The Boss was amazed at how I handled the situation and asked me what the punishment should be for them, maybe he was testing me, I said that those guys should be thrown into the furnace, and let all the employees hear it to serve as an example, after I said that, he saw that I could be useful to him to run the factory and so I became the secretary.",
                        "Macula ended up getting up and saying goodbye. I was about to leave too, but I saw Disha on the counter."};
                    }
                    else if (teste.ImprimirDoJeitoMacula && !permiteFalarComFenwick)
                    {
                        resultado = new string[] { "Here Cien!",
                        "<i>I hand over the DIS and the document.</i>",
                        "Wow, that's fast... congratulations... another thing, Cooper is waiting for you in the Chief's Office for I don't know what.",
                        "You're here! Actually, I just wanted to tell you that there's a party at the nightclub tonight, it would be good if you went to get along, it's 2 blocks from the factory.",
                        "What's all this talk about, Cooper? <i>(Cooper starts saying some words that I have no idea what they mean)</i>",
                        "Oh yes! Well, I'm going there. If you want me to show you the way, just follow me.",
                        "<i>The nightclub had several things that were similar or practically the same as my world, such as discos, well-padded armchairs and other things. I continued to follow Macula to the VIP part of the nightclub.</i>",
                    "The club allows a lot of things, so don't be surprised if you see something different. And again, this is the only time I've come with you, so don't get used to it.",
                    "How did you get here? <i>(Of course, she volunteered to show me around, out of pure interest)</i>",
                    "My friends and I went to do a ritual to trap a monster, but it ended up going wrong somehow and I ended up here, we followed our friend Ran's book, it had a reddish brown cover, a symbol of a bug's head made in bone around a circle with some studs, if I remember correctly. <i>(Macula gets pensive)</i>",
                    "Do you know anything? Or how to get me out of here?",
                    "No, I was wondering if you knew anything like that around here, but she doesn't. <i>(She doesn't hide her disappointment, but I wonder if the book is related to the factory in any way.)</i>",
                        "Macula ended up getting up and saying goodbye. I was about to leave too, but I saw Disha on the counter."};
                    }
                    else if (!teste.ImprimirDoJeitoMacula && permiteFalarComFenwick)
                    {
                        resultado = new string[] { "Here Cien!",
                        "<i>I hand over the DIS and the document.</i>",
                        "Don't you know that we also have work to do! Seriously... Cooper told you to go to the boss's office <i>(Cien spat the last sentence in my face)</i>",
                        "You're here! Actually, I just wanted to tell you that there's a party at the nightclub tonight, it would be good if you went to get along, it's 2 blocks from the factory.",
                        "What's all this talk about, Cooper? <i>(Cooper starts saying some words that I have no idea what they mean)</i>",
                        "Oh yes! Well, I'm going there. If you want me to show you the way, just follow me.",
                        "<i>The nightclub had several things that were similar or practically the same as my world, such as discos, well-padded armchairs and other things. I continued to follow Macula to the VIP part of the nightclub.</i>",
                    "The club allows a lot of things, so don't be surprised if you see something different. And again, this is the only time I've come with you, so don't get used to it.",
                    "How did you get here? <i>(Of course, she volunteered to show me around, out of pure interest)</i>",
                    "My friends and I went to do a ritual to trap a monster, but it ended up going wrong somehow and I ended up here, we followed our friend Ran's book, it had a reddish brown cover, a symbol of a bug's head made in bone around a circle with some studs, if I remember correctly. <i>(Macula gets pensive)</i>",
                    "Do you know anything? Or how to get me out of here?",
                    "No, I was wondering if you knew anything like that around here, but she doesn't. <i>(She doesn't hide her disappointment, but I wonder if the book is related to the factory in any way.)</i>",
                        "How did you get to your position as Secretary, if you don't mind me asking?",
                        "I often come to this club, I ended up losing my memory as a teenager, I always have this need to come here, even if I don't drink or do anything, and one of these nights, I saw the Boss for the first time, when he was still allowed to leave the factory, while he was having fun some employees tried to assassinate him, because of the extremely exhausting work.",
                        "I managed to stop them, The Boss was amazed at how I handled the situation and asked me what the punishment should be for them, maybe he was testing me, I said that those guys should be thrown into the furnace, and let all the employees hear it to serve as an example, after I said that, he saw that I could be useful to him to run the factory and so I became the secretary.",
                        "Macula ended up getting up and saying goodbye. I was about to leave too, but I saw Disha on the counter."};
                    }
                    else if (!teste.ImprimirDoJeitoMacula && !permiteFalarComFenwick)
                    {
                        resultado = new string[] { "Here Cien!",
                        "<i>I hand over the DIS and the document.</i>",
                        "Don't you know that we also have work to do! Seriously... Cooper told you to go to the boss's office <i>(Cien spat the last sentence in my face)</i>",
                        "You're here! Actually, I just wanted to tell you that there's a party at the nightclub tonight, it would be good if you went to get along, it's 2 blocks from the factory.",
                        "What's all this talk about, Cooper? <i>(Cooper starts saying some words that I have no idea what they mean)</i>",
                        "Oh yes! Well, I'm going there. If you want me to show you the way, just follow me.",
                        "<i>The nightclub had several things that were similar or practically the same as my world, such as discos, well-padded armchairs and other things. I continued to follow Macula to the VIP part of the nightclub.</i>",
                    "The club allows a lot of things, so don't be surprised if you see something different. And again, this is the only time I've come with you, so don't get used to it.",
                    "How did you get here? <i>(Of course, she volunteered to show me around, out of pure interest)</i>",
                    "My friends and I went to do a ritual to trap a monster, but it ended up going wrong somehow and I ended up here, we followed our friend Ran's book, it had a reddish brown cover, a symbol of a bug's head made in bone around a circle with some studs, if I remember correctly. <i>(Macula gets pensive)</i>",
                    "Do you know anything? Or how to get me out of here?",
                    "No, I was wondering if you knew anything like that around here, but she doesn't. <i>(She doesn't hide her disappointment, but I wonder if the book is related to the factory in any way.)</i>",
                        "Macula ended up getting up and saying goodbye. I was about to leave too, but I saw Disha on the counter."};
                    }

                    break;
                }
            case 13:
                {
                    if (teste.respondeuHannaFriamente) //Ela está estressada
                    {
                        resultado = new string[] { $"What's up, {nomeDoPersonagemPrincipal}, did you go to the nightclub? What the fuck? Why is there another human here?!",
                    "Yeah... Cooper, this is Hanna..., remember I told you about the ritual I did with my friends? She's one of them. I know Iva won't like the idea but could she stay here with me for now? You're friends, I know she'd understand if you told her.",
                    "I'm glad you know, well, if she comes to work too and doesn't sneak around like a rat, I can talk to Iva, but only her! Iva is losing customers because a human is living in her building.",
                    "Working?! With... monsters?! Why do I have to do this?",
                    "Firstly, so that you can pay for living here, and Iva doesn't lose so much, and secondly... so nomedojogador, don't have the chance to see your friend die... <i>(Hanna was about to answer him again, but ends up accepting the fact)</i>",
                    "<i>Cooper leaves without even having time for me to answer how the nightclub went, Hanna starts telling us about everything she's been through and how we can get back home, we decide that we'll start looking for Akira, Maya and Ran, starting tomorrow when we leave work.</i>",

                    //DIA SEGUINTE
                    "<i>[The next morning...]</i>",
                    "<i>Hanna was no longer in her room, Cooper had come in the morning to accompany Hanna to the factory, as I work the opposite shift, so it would be time for her to leave as soon as I arrived.</i>",
                    "<i>[Time Break]</i>",
                    "<i>When I finish my work I see Cooper and Hanna at the end of the corridor. Apparently Hanna will be here all day, being supervised by him, they were talking about something, I decided to approach.</i>",

                    "Why, I have to deliver it! You have two hands and two legs, you can do this!",
                    "I'm the manager here, and you have to obey me! This is the job, either you do what I say, or you can say goodbye to the roof over your head your friend gave you <i>(She walks away doing what he asks.)</i>",
                    "I'm sorry about her, I should have calmed her down, she's quite difficult when she's like this. <i>(Cooper says nothing, just waits for Hanna to return so they can leave, I follow him, out of the factory too, since I've finished my work)</i>",

                    "So, you mean Hanna is bipolar? Interesting... How does that happen?-",
                    "<i>Screams. Screams and roars were everywhere. When we looked at the factory, we heard a huge explosion, Cooper ran out to hear the noise and we decided to follow him.</i>",
                    "Is that...ice?! <i>(The three of us looked at each other, not knowing how it had happened)</i>",
                    "<i>The entire generator room was covered in ice.</i>"};
                    }
                    else if (!teste.respondeuHannaFriamente) //Ela está calma
                    {
                        resultado = new string[] { $"What's up, {nomeDoPersonagemPrincipal}, did you go to the nightclub? What the fuck? Why is there another human here?!",
                    "Yeah... Cooper, this is Hanna..., remember I told you about the ritual I did with my friends? She's one of them. I know Iva won't like the idea but could she stay here with me for now? You're friends, I know she'd understand if you told her.",
                    "I'm glad you know, well, if she comes to work too and doesn't sneak around like a rat, I can talk to Iva, but only her! Iva is losing customers because a human is living in her building.",
                    "Working?! With... monsters?! Why do I have to do this?",
                    "Firstly, so that you can pay for living here, and Iva doesn't lose so much, and secondly... so nomedojogador, don't have the chance to see your friend die... <i>(Hanna was about to answer him again, but ends up accepting the fact)</i>",
                    "<i>Cooper leaves without even having time for me to answer how the nightclub went, Hanna starts telling us about everything she's been through and how we can get back home, we decide that we'll start looking for Akira, Maya and Ran, starting tomorrow when we leave work.</i>",

                    //DIA SEGUINTE
                    "<i>[The next morning...]</i>",
                    "<i>Hanna was no longer in her room, Cooper had come in the morning to accompany Hanna to the factory, as I work the opposite shift, so it would be time for her to leave as soon as I arrived.</i>",
                    "<i>[Time Break]</i>",
                    "<i>When I finish my work I see Cooper and Hanna at the end of the corridor. Apparently Hanna will be here all day, being supervised by him, they were talking about something, I decided to approach.</i>",

                    "Deliver this to your... boss's office? The monsters... What if they try something?",
                    " I know some of them are tricky, but they won't mess with you. <i>(Hanna leaves to deliver whatever it was)</i>",
                    "She's giving you a hard time, isn't she? I know you don't like it, sorry, but thanks. <i>(Cooper doesn't say anything, just waits for Hanna to return so they can leave, I follow him, out of the factory too, since I've finished my work)</i>",

                     "So, you mean Hanna is bipolar? Interesting... How does that happen?-",
                     "<i>Screams. Screams and roars were everywhere. When we looked at the factory, we heard a huge explosion, Cooper ran out to hear the noise and we decided to follow him.</i>",
                     "Is that...ice?! <i>(The three of us looked at each other, not knowing how it had happened)</i>",
                     "<i>The entire generator room was covered in ice.</i>"};
                    }
                    
                    break;
                }
        }
        return resultado;
    }


    public string[] UniaoDeGalhosNomes(int x)
    {
        string[] resultado = new string[] { "" };

        switch (x)
        {
            case 2:
                {
                    resultado = new string[]{ "",
                        "Akira",
                        "Maya",
                        "Ren",
                        "Maya",
                        "Maya"};
                    break;
                }
            case 3:
                {
                    resultado = new string[]{ "",
                        "Hanna",
                        "Ran",
                        "",
                        "Ran",
                        "Akira",
                        "Ran",
                        "",
                        "Akira",
                        "",
                        "Akira, Hanna and Maya",
                        "",
                        nomeDoPersonagemPrincipal,
                        "",

                        // Ato 1

                        nomeDoPersonagemPrincipal,
                        nomeDoPersonagemPrincipal,
                        nomeDoPersonagemPrincipal,
                        nomeDoPersonagemPrincipal,
                        nomeDoPersonagemPrincipal,
                        "Unknown Monster 1",
                        "Unknown Monster 2",
                        "Unknown Monster 2",
                        "Unknown Monster 3",
                        "Unknown Monster 3",
                        nomeDoPersonagemPrincipal,
                        "Unknown Monster 3",
                        nomeDoPersonagemPrincipal,
                        "Unknown Monster 3",
                        nomeDoPersonagemPrincipal,
                        "Unknown Monster 3",
                        nomeDoPersonagemPrincipal,
                        "Unknown Monster 1",
                        nomeDoPersonagemPrincipal,
                        nomeDoPersonagemPrincipal,
                        "Cooper",
                        "Cooper",
                        "Cooper"};
                    break;
                }
            case 4:
                {
                    resultado = new string[] { "Iva",
                        "",
                        "Scary Monster",
                        "Cooper",
                        "Boss",
                        "Macula",
                        "Macula",
                        "Employee 1",
                        "Macula",
                        "Employee 2",
                        "Employee 2",
                        nomeDoPersonagemPrincipal,
                        "Employee 2",
                        "Employee 2",
                        "Employee 2",
                        "Macula"};
                    break;
                }
            case 5:
                {
                    resultado = new string[] { "", 
                        "",
                        "",
                        nomeDoPersonagemPrincipal,
                        "Employee 1",
                        "Macula", 
                        "",
                        "Unknown Monster 4",
                        "Unknown Monster 4",
                        nomeDoPersonagemPrincipal
                    };
                    break;
                }
            case 6:
                {
                    resultado = new string[] { "",
                        "",
                        "",
                        nomeDoPersonagemPrincipal,
                        nomeDoPersonagemPrincipal,
                        "",
                        "Iva" };
                    break;
                }
            case 7:
                {
                    resultado = new string[] { "Unknown Monster 5",
                        "Unknown Monster 5" };
                    break;
                }
            case 8:
                {
                    resultado = new string[] { "Finwick",
                        "Finwick" };
                    break;
                }
            case 9:
                {
                    if (tabeladeAfinidades.Fenwick <= 5)
                    {
                        resultado = new string[] { "Finwick",
                        "Finwick",
                        "Finwick",
                        "Cien",
                        "Cien",
                        nomeDoPersonagemPrincipal,
                        nomeDoPersonagemPrincipal,
                        "Gust" };
                    }
                    else if (tabeladeAfinidades.Fenwick > 5)
                    {
                        resultado = new string[] { "Finwick",
                        "Finwick",
                        "Finwick",
                        "Finwick",
                        "Cien",
                        "Cien",
                        nomeDoPersonagemPrincipal,
                        nomeDoPersonagemPrincipal,
                        "Gust" };
                    }

                        

                    break;
                }
            case 12:
                {
                    Debug.Log("Case12 Funcionou");
                    Debug.Log("Imprimir jeito macula " + teste.ImprimirDoJeitoMacula);
                    Debug.Log("permiteFalarComFenwick " + permiteFalarComFenwick);

                    if (teste.ImprimirDoJeitoMacula && permiteFalarComFenwick)
                    {
                        resultado = new string[] { nomeDoPersonagemPrincipal, "",
                        "Cien",
                        "Cooper", "Macula", "Macula",
                        "", "Macula", "Macula", nomeDoPersonagemPrincipal, nomeDoPersonagemPrincipal, "Macula",
                        nomeDoPersonagemPrincipal, "Macula", "Macula", ""};
                    }
                    else if (teste.ImprimirDoJeitoMacula && !permiteFalarComFenwick)
                    {
                        resultado = new string[] { nomeDoPersonagemPrincipal, "",
                        "Cien",
                        "Cooper", "Macula", "Macula",
                        "", "Macula", "Macula", nomeDoPersonagemPrincipal, nomeDoPersonagemPrincipal, "Macula",
                        ""};
                    }
                    else if (!teste.ImprimirDoJeitoMacula && permiteFalarComFenwick)
                    {
                        resultado = new string[] { nomeDoPersonagemPrincipal, "",
                        "Cien",
                        "Cooper", "Macula", "Macula",
                        "", "Macula", "Macula", nomeDoPersonagemPrincipal, nomeDoPersonagemPrincipal, "Macula",
                        nomeDoPersonagemPrincipal, "Macula", "Macula", ""};
                    }
                    else if (!teste.ImprimirDoJeitoMacula && !permiteFalarComFenwick)
                    {
                        resultado = new string[] { nomeDoPersonagemPrincipal, "",
                        "Cien",
                        "Cooper", "Macula", "Macula",
                        "", "Macula", "Macula", nomeDoPersonagemPrincipal, nomeDoPersonagemPrincipal, "Macula",
                        ""};
                    }

                        break;
                }
            case 13:
                {
                    resultado = new string[] { "Cooper",
                        nomeDoPersonagemPrincipal,
                        "Cooper",
                        "Hanna",
                        "Cooper",
                        "",
                        "",
                        "",
                        "",
                        "",

                        "Hanna",
                        "Cooper",
                        nomeDoPersonagemPrincipal,

                        "Cooper",
                        "",
                        nomeDoPersonagemPrincipal,
                        ""};

                    break;
                }
                case 14:
                {
                    SceneManager.LoadScene(0);
                    break;
                }
        }
        return resultado;
    }

    public Sprite[] UniaoDeGalhosSprites(int x)
    {
        Sprite[] resultado = new Sprite[] { };

        switch (x)
        {
            case 2:
                {
                    resultado = new Sprite[] { Narrador, Akira, Maya, Ran, Maya, Maya };
                    break;
                }
            case 3:
                {
                    resultado = new Sprite[] { Narrador,
                        Hanna,
                        Ran,
                        Narrador,
                        Ran,
                        Akira,
                        Ran,
                        Narrador,
                        Akira,
                        Narrador,
                        Akira,
                        Narrador,
                        Player,
                        Narrador,
                    
                        // Ato 1

                        Player,
                        Player,
                        Player,
                        Player,
                        Player,
                        Cien,
                        Gust,
                        Gust,
                        Cooper,
                        Cooper,
                        Player,
                        Cooper,
                        Player,
                        Cooper,
                        Player,
                        Cooper,
                        Player,
                        Cien,
                        Player,
                        Player,
                        Cooper,
                        Cooper,
                        Cooper };
                        break;
                }
            case 4:
                {
                    resultado = new Sprite[] { Iva,
                    Narrador,
                    Chefe,
                    Cooper,
                    Chefe,
                    Macula,
                    Macula,
                    Cien,
                    Macula,
                    Gust,
                    Gust,
                    Player,
                    Gust,
                    Gust,
                    Gust,
                    Macula};
        break;
                }
            case 5:
                {
                    resultado = new Sprite[] {Narrador,
                        Narrador,
                        Narrador,
                        Player,
                        Cien,
                        Macula,
                        Narrador,
                        Disha,
                        Disha,
                        Player };
                    break;
                }
            case 6:
                {
                    resultado = new Sprite[] { Narrador,
                        Narrador,
                        Narrador,
                        Player,
                        Player,
                        Narrador,
                        Iva };
                    break;
                }
            case 7:
                {
                    resultado = new Sprite[] { Finwick,
                    Finwick };
                    break;
                }
            case 8:
                {
                    resultado = new Sprite[] { Finwick,
                    Finwick};
                    break;
                }
            case 9:
                {
                    if (tabeladeAfinidades.Fenwick <= 5)
                    {
                        resultado = new Sprite[] { Finwick,
                        Finwick,
                        Finwick,
                        Cien,
                        Cien,
                        Player,
                        Player,
                        Gust };
                    }
                    else if (tabeladeAfinidades.Fenwick > 5)
                    {
                        resultado = new Sprite[] { Finwick,
                        Finwick,
                        Finwick,
                        Finwick,
                        Cien,
                        Cien,
                        Player,
                        Player,
                        Gust };
                    }

                        
                    break;
                }
            case 12:
                {
                    if (teste.ImprimirDoJeitoMacula && permiteFalarComFenwick)
                    {
                        resultado = new Sprite[] { Player, Narrador, Cien, 
                            Cooper, Macula, Macula,
                            Narrador, Macula, Macula, Player, Player, Macula,
                            Player, Macula, Macula, Player };
                    }
                    else if (teste.ImprimirDoJeitoMacula && !permiteFalarComFenwick)
                    {
                        resultado = new Sprite[] { Player, Narrador, Cien,
                            Cooper, Macula, Macula,
                            Narrador, Macula, Macula, Player, Player, Macula,
                            Narrador };
                    }
                    else if (!teste.ImprimirDoJeitoMacula && permiteFalarComFenwick)
                    {
                        resultado = new Sprite[] { Player, Narrador, Cien,
                            Cooper, Macula, Macula,
                            Narrador, Macula, Macula, Player, Player, Macula,
                            Player, Macula, Macula, Player };
                    }
                    else if (!teste.ImprimirDoJeitoMacula && !permiteFalarComFenwick)
                    {
                        resultado = new Sprite[] { Player, Narrador, Cien,
                            Cooper, Macula, Macula,
                            Narrador, Macula, Macula, Player, Player, Macula,
                            Narrador };
                    }
                        break;
                }
            case 13:
                {
                    resultado = new Sprite[] { Cooper,
                        Player,
                        Cooper,
                        Hanna,
                        Cooper,
                        Narrador,
                        Narrador,
                        Narrador,
                        Narrador,
                        Narrador,

                        Hanna,
                        Cooper,
                        Player,

                        Cooper,
                        Narrador,
                        Player,
                        Narrador };

                    break;
                }
        }
        return resultado;
    }

    public int UniaoDeGalhosOpcoes(int x)
    {
        int resultado = 0;
        switch (x)
        {
            case 2:
                {
                    resultado = 5;
                    break;
                }
            case 3:
                {
                    resultado = 35;
                    break;
                }
            case 4:
                {
                    resultado = 15;
                    break;
                }
            case 5:
                {
                    resultado = 9 ;
                    break;
                }
            case 6:
                {
                    resultado = 6;
                    break;
                }
            case 7:
                {
                    resultado = 1 ;
                    break;
                }
            case 8:
                {
                    resultado = 1;
                    break;
                }
            case 9:
                {
                    Debug.Log(tabeladeAfinidades.Fenwick);

                    if (tabeladeAfinidades.Fenwick <= 5)
                    {
                        resultado = 7;
                        falarComFinwick = 2;//0 = NULO, 1 = VERDADEIRO, 2 = FALSE

                        Debug.Log(falarComFinwick);
                    }
                    else if (tabeladeAfinidades.Fenwick > 5)
                    {
                        resultado = 8;
                        falarComFinwick = 1; //0 = NULO, 1 = VERDADEIRO, 2 = FALSE
                    }
                    break;
                }
            case 12:
                {
                    if (teste.ImprimirDoJeitoMacula && permiteFalarComFenwick)
                    {
                        resultado = 15;
                    }
                    else if (teste.ImprimirDoJeitoMacula && !permiteFalarComFenwick)
                    {
                        resultado = 12;
                    }
                    else if (!teste.ImprimirDoJeitoMacula && permiteFalarComFenwick)
                    {
                        resultado = 15;
                    }
                    else if (!teste.ImprimirDoJeitoMacula && !permiteFalarComFenwick)
                    {
                        resultado = 12;
                    }
                        break;
                }
            case 13:
                {
                    //resultado = 16; ESSE É O CERTO

                    resultado = 17;
                    break;
                }
        }
        return resultado;
    }

    public bool UniaoDeGalhosTipoOpcao(int x)
    {
        bool resultado = true;
        switch (x)
        {
            case 2:
                {
                    resultado = true;
                    break;
                }
            case 3:
                {
                    resultado = true;
                    break;
                }
            case 4:
                {
                    resultado = true;
                    break;
                }
            case 5:
                {
                    resultado = true;
                    break;
                }
            case 6:
                {
                    resultado = true;

                    break;
                }
            case 7:
                {
                    resultado = true;

                    break;
                }
            case 8:
                {
                    resultado = true;
                    break;
                }
            case 9:
                {
                    ////////
                    resultado = false;
                    break;
                }
            case 12:
                {
                    /////
                    resultado = true;
                    break;
                }
            case 13:
                {
                    /////
                    resultado = true;
                    break;
                }
        }
        return resultado;
    }

    public Sprite[] UniaoDeGalhosBackground(int x)
    {
        Sprite[] sprite = new Sprite[] { };
        switch (x)
        {
            case 2:
                {
                    sprite = new Sprite[] { cenaCB, cenaCB, cenaCB, cenaCB, cenaCB, cenaCB };
                    break;
                }
            case 3:
                {
                    sprite = new Sprite[] { cenaSB, cenaSB, cenaSB, cenaSB, cenaSB, cenaSB, cenaSB, cenaSB, cenaSB, cenaSB, cenaSB, cenaFP, cenaRP, cenaRP, cenaRP,
                    cenaRP, cenaBC, cenaBC, cenaBC, cenaBC, cenaBC, cenaBC, cenaBC, cenaBC, cenaBC, cenaBC, cenaBC, cenaBC, cenaBC, cenaBC, cenaBC, cenaBC, cenaBC, cenaBC, cenaBC, cenaBC };
                    break;  
                }
            case 4:
                {
                    sprite = new Sprite[] { cenaRC, cenaFP, cenaEF, cenaEF, cenaEF, cenaEF, cenaCF, cenaCF, cenaCF, cenaCF, cenaSG, cenaSG, cenaSG, cenaSG, cenaSG, cenaCF};
                    break;
                }
            case 5:
                {
                    sprite = new Sprite[] { cenaSC, cenaSF, cenaCF, cenaCF, cenaCF, cenaRP, cenaRP, cenaRP };
                    break;
                }
            case 6:
                {
                    sprite = new Sprite[] { cenaRC, cenaQI, cenaQI, cenaQI, cenaQI, cenaQI, cenaRC };
                    break;
                }
            case 7:
                {
                    sprite = new Sprite[] { cenaRP, cenaRP };
                    break;
                }
            case 8:
                {
                    sprite = new Sprite[] { cenaRP, cenaRP };
                    break;
                }
            case 9:
                {
                    if (tabeladeAfinidades.Fenwick <= 5)
                    {
                        sprite = new Sprite[] { cenaRP, cenaRP, cenaRP, cenaCF, cenaCF, cenaCF, cenaSG, cenaSG };
                    }
                    else if (tabeladeAfinidades.Fenwick > 5)
                    {
                        sprite = new Sprite[] { cenaRP, cenaRP, cenaRP,  cenaRP, cenaCF, cenaCF, cenaCF, cenaSG, cenaSG };
                    }
                    break;
                }
            case 12:
                {
                    if (teste.ImprimirDoJeitoMacula && permiteFalarComFenwick)
                    {
                        sprite = new Sprite[] { cenaCF, cenaCF, cenaCF, cenaSC, cenaSC, cenaSC, cenaBT, cenaBT, cenaBT, cenaBT, cenaBT, cenaBT, cenaBT, cenaBT, cenaBT, cenaBT };
                    }
                    else if (teste.ImprimirDoJeitoMacula && !permiteFalarComFenwick)
                    {
                        sprite = new Sprite[] { cenaCF, cenaCF, cenaCF, cenaSC, cenaSC, cenaSC, cenaBT, cenaBT, cenaBT, cenaBT, cenaBT, cenaBT, cenaBT };
                    }
                    else if (!teste.ImprimirDoJeitoMacula && permiteFalarComFenwick)
                    {
                        sprite = new Sprite[] { cenaCF, cenaCF, cenaCF, cenaSC, cenaSC, cenaSC, cenaBT, cenaBT, cenaBT, cenaBT, cenaBT, cenaBT, cenaBT, cenaBT, cenaBT, cenaBT };
                    }
                    else if (!teste.ImprimirDoJeitoMacula && !permiteFalarComFenwick)
                    {
                        sprite = new Sprite[] { cenaCF, cenaCF, cenaCF, cenaSC, cenaSC, cenaSC, cenaBT, cenaBT, cenaBT, cenaBT, cenaBT, cenaBT, cenaBT };
                    }
                        break;
                }
            case 13:
                {
                    sprite = new Sprite[] { cenaQI, cenaQI, cenaQI, cenaQI, cenaQI, cenaQI, cenaFP, cenaQI, cenaFP, cenaCF,

                    cenaCF, cenaCF, cenaCF,

                    cenaEF, cenaEF, cenaGG, cenaGG};

                    break;
                }
                
        }
        return sprite;
    }
}
