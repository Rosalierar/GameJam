using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabeladeAfinidades : MonoBehaviour
{
    [SerializeField] private GameObject tabela;

    [Header ("Positivos")]
    [SerializeField] private Slider sliderFenwick;
    [SerializeField] private Slider sliderMacula;
    [SerializeField] private Slider sliderCooper;
    [SerializeField] private Slider sliderDisha;
    [SerializeField] private Slider sliderRan;
    [SerializeField] private Slider sliderHanna;
    [SerializeField] private Slider sliderAkira;
    [SerializeField] private Slider sliderMaya;
    [SerializeField] private Slider sliderChefe;

    [Header("Negativos")]
    [SerializeField] private Slider sliderFenwickNegativo;
    [SerializeField] private Slider sliderMaculaNegativo;
    [SerializeField] private Slider sliderCooperNegativo;
    [SerializeField] private Slider sliderDishaNegativo;
    [SerializeField] private Slider sliderRanNegativo;
    [SerializeField] private Slider sliderHannaNegativo;
    [SerializeField] private Slider sliderAkiraNegativo;
    [SerializeField] private Slider sliderMayaNegativo;
    [SerializeField] private Slider sliderChefeNegativo;

    [Header("Negativos")]
    public float Fenwick;
    public float Macula;
    public float Cooper;
    public float Disha;
    public float Ran;
    public float Hanna;
    public float Akira;
    public float Maya;
    public float Chefe;

    [Header("Músicas")]
    public AudioSource audioSourceMusicaFundo;
    public AudioSource[] audioSourceFX;

    [Header("Sons")]

    [SerializeField] private AudioClip trovao;
    [SerializeField] private AudioClip casaAbandonada;
    [SerializeField] private AudioClip balada;
    [SerializeField] private AudioClip beco;
    [SerializeField] private AudioClip correddorFabrica;
    [SerializeField] private AudioClip foraDeCasa;
    [SerializeField] private AudioClip menu;
    [SerializeField] private AudioClip quartoInferno;
    [SerializeField] private AudioClip quartoPersonagem;
    [SerializeField] private AudioClip ruaPrincial;
    [SerializeField] private AudioClip salaChefe;
    [SerializeField] private AudioClip salaFuncionarios;
    [SerializeField] private AudioClip salaGeradores;
    [SerializeField] private AudioClip teletransportando;

    /*public bool boolTrovao;
    public bool boolcasaAbandonada;
    public bool boolbalada;
    public bool boolbeco;
    public bool boolcorreddorFabrica;
    public bool boolforaDeCasa;
    public bool boolmenu;
    public bool boolquartoInferno;
    public bool boolquartoPersonagem;
    public bool boolruaPrincial;
    public bool boolsalaChefe;
    public bool boolsalaFuncionarios;
    public bool boolsalaGeradores;
    public bool boolteletransportando;
    */

    //int momentoPerfeito = 0;

    private bool ativarDesativar = false;

    private void Start()
    {
        AudioClip[] sons = new AudioClip[] { trovao };

        TocarSons(quartoPersonagem, sons, 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ativarDesativar = !ativarDesativar;
            tabela.SetActive(ativarDesativar);
        }
    }

    public void FixedUpdate()
    {
        Fenwick = sliderFenwick.value + sliderFenwickNegativo.value;
        Macula = sliderMacula.value + sliderMaculaNegativo.value;
        Cooper = sliderCooper.value + sliderCooperNegativo.value;
        Disha = sliderDisha.value + sliderDishaNegativo.value;
        Ran = sliderRan.value + sliderRanNegativo.value;
        Hanna = sliderHanna.value + sliderHannaNegativo.value;
        Akira = sliderAkira.value + sliderAkiraNegativo.value;
        Maya = sliderMaya.value + sliderMayaNegativo.value;
        Chefe = sliderChefe.value + sliderChefeNegativo.value;
    }

    public void TocarSons(AudioClip fundo, AudioClip[] sons, int x)
    {
        audioSourceMusicaFundo.Stop();
        audioSourceMusicaFundo.clip = fundo;
        audioSourceMusicaFundo.volume = 0.3f;
        audioSourceMusicaFundo.Play();

        for (int i = 0; i < audioSourceFX.Length; i++)
        {
            audioSourceFX[i].Stop();

            audioSourceFX[i].clip = sons[i];
            audioSourceFX[i].volume = 0.3f;

            audioSourceFX[i].Play();
        }
    }

    // Função para atualizar a afinidade
    public void AtualizarAfinidadeFenwick(int novaAfinidade)
    {
        float _novaAfinidade = novaAfinidade;
        CalcularAfinidade(sliderFenwick, sliderFenwickNegativo, _novaAfinidade);
    }
    public void AtualizarAfinidadeMacula(int novaAfinidade)
    {
        float _novaAfinidade = novaAfinidade;
        CalcularAfinidade(sliderMacula, sliderMaculaNegativo, _novaAfinidade);
    }
    public void AtualizarAfinidadeCooper(int novaAfinidade)
    {
        float _novaAfinidade = novaAfinidade;
        CalcularAfinidade(sliderCooper, sliderCooperNegativo, _novaAfinidade);
    }
    public void AtualizarAfinidadeDisha(int novaAfinidade)
    {
        float _novaAfinidade = novaAfinidade;
        CalcularAfinidade(sliderDisha, sliderDishaNegativo, _novaAfinidade);
    }
    public void AtualizarAfinidadeRan(int novaAfinidade)
    {
        float _novaAfinidade = novaAfinidade;
        CalcularAfinidade(sliderRan, sliderRanNegativo, _novaAfinidade);
    }
    public void AtualizarAfinidadeHanna(int novaAfinidade)
    {
        float _novaAfinidade = novaAfinidade;
        CalcularAfinidade(sliderHanna, sliderHannaNegativo, _novaAfinidade);
    }
    public void AtualizarAfinidadeAkira(int novaAfinidade)
    {
        float _novaAfinidade = novaAfinidade;
        CalcularAfinidade(sliderAkira, sliderAkiraNegativo, _novaAfinidade);
    }
    public void AtualizarAfinidadeMaya(int novaAfinidade)
    {
        float _novaAfinidade = novaAfinidade;
        CalcularAfinidade(sliderMaya, sliderMayaNegativo, _novaAfinidade);
    }
    public void AtualizarAfinidadeChefe(int novaAfinidade)
    {
        float _novaAfinidade = novaAfinidade;
        CalcularAfinidade(sliderChefe, sliderChefeNegativo, _novaAfinidade);
    }

    public void CalcularAfinidade(Slider positivo, Slider negativo, float valor)
    {
        float calculo = (positivo.value + negativo.value) + valor;

        if (calculo >= 0)
        {
            negativo.value = 0f;
            positivo.value = calculo;
        }
        else if (calculo < 0)
        {
            positivo.value = 0f;
            negativo.value = -calculo;
        }
    }
}
