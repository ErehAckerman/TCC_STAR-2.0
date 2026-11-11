using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
using System.Collections.Generic;

[System.Serializable]
public class EntradaRanking
{
    public string nome;
    public float tempoTotal;
}

[System.Serializable]
public class TabelaDeRanking
{
    public List<EntradaRanking> recordes = new List<EntradaRanking>();
}

public class GerenciadorDeMenu : MonoBehaviour
{
    [Header("Interface do Ranking")]
    [SerializeField] private GameObject painelRanking;
    [SerializeField] private TextMeshProUGUI textoMelhorTempo;

    private string caminhoDoArquivo;

    void Start()
    {
        caminhoDoArquivo = Application.persistentDataPath + "/recorde_tcc.json";

        
        painelRanking.SetActive(false);

        CarregarRanking();
    }

    public void AbrirPainelRanking()
    {
        painelRanking.SetActive(true);
    }

    public void FecharPainelRanking()
    {
        painelRanking.SetActive(false);
    }

    public void IniciarJogo()
    {
        SceneManager.LoadScene("Fase_01");
    }

    public void AbrirCreditos()
    {
        SceneManager.LoadScene("Tela_Creditos");
    }

    public void FecharJogo()
    {
        Application.Quit();
        Debug.Log("O jogo foi fechado!");
    }

    private void CarregarRanking()
    {
        if (File.Exists(caminhoDoArquivo))
        {
            string textoJson = File.ReadAllText(caminhoDoArquivo);
            TabelaDeRanking tabela = JsonUtility.FromJson<TabelaDeRanking>(textoJson);

            textoMelhorTempo.text = "";

            for (int i = 0; i < tabela.recordes.Count; i++)
            {
                EntradaRanking jogador = tabela.recordes[i];

                int minutos = Mathf.FloorToInt(jogador.tempoTotal / 60f);
                int segundos = Mathf.FloorToInt(jogador.tempoTotal % 60f);
                int milissegundos = Mathf.FloorToInt((jogador.tempoTotal * 1000f) % 1000f);

                
                textoMelhorTempo.text += $"{i + 1}º Lugar - {jogador.nome}: {minutos:00}:{segundos:00}.{milissegundos:000}\n";
            }
        }
        else
        {
            textoMelhorTempo.text = "Ainda não há recordes espaciais.\nSeja o primeiro a escapar!";
        }
    }
}