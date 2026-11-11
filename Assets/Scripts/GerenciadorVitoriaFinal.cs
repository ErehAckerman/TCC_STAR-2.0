using UnityEngine;
using TMPro;
using System.IO;

public class GerenciadorVitoriaFinal : MonoBehaviour
{
    [Header("Elementos da Tela")]
    [SerializeField] private TextMeshProUGUI textoTempoTotal;
    [SerializeField] private TMP_InputField campoNomeJogador;

    private float tempoFinalDoJogo = 0f;
    private string caminhoDoArquivo;

    void Start()
    {
        // Define o endereço seguro no HD apenas uma vez
        caminhoDoArquivo = Application.persistentDataPath + "/recorde_tcc.json";

        if (GerenciadorDeSessao.instancia != null)
        {
            
            tempoFinalDoJogo = GerenciadorDeSessao.instancia.tempoTotalDoJogo;

            int minutos = Mathf.FloorToInt(tempoFinalDoJogo / 60f);
            int segundos = Mathf.FloorToInt(tempoFinalDoJogo % 60f);
            int milissegundos = Mathf.FloorToInt((tempoFinalDoJogo * 1000f) % 1000f);

            textoTempoTotal.text = $"Tempo Total: {minutos:00}:{segundos:00}.{milissegundos:000}";
        }
    }

    public void AoClicarEmSalvar()
    {
        EntradaRanking novoRecorde = new EntradaRanking();
        novoRecorde.nome = campoNomeJogador.text;
        novoRecorde.tempoTotal = tempoFinalDoJogo;

        if (string.IsNullOrEmpty(novoRecorde.nome))
        {
            novoRecorde.nome = "Astronauta Anônimo";
        }

        TabelaDeRanking tabela;

        // Tenta ler o JSON no HD
        if (File.Exists(caminhoDoArquivo))
        {
            string jsonExistente = File.ReadAllText(caminhoDoArquivo);
            tabela = JsonUtility.FromJson<TabelaDeRanking>(jsonExistente);
        }
        else
        {
            tabela = new TabelaDeRanking();
        }

        tabela.recordes.Add(novoRecorde);

        // Ordena do menor tempo para o maior
        tabela.recordes.Sort((x, y) => x.tempoTotal.CompareTo(y.tempoTotal));

        // Mantém apenas o Top 5
        if (tabela.recordes.Count > 5)
        {
            tabela.recordes.RemoveAt(5);
        }

        // Salva de volta no HD 
        string novoJson = JsonUtility.ToJson(tabela, true);
        File.WriteAllText(caminhoDoArquivo, novoJson);

        Debug.Log("Lista de Top 5 salva com sucesso no disco!");

        // Confere se o Singleton existe 
        if (GerenciadorDeSessao.instancia != null)
        {
            GerenciadorDeSessao.instancia.DestruirSessao();
        }
    }
}