using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Textos da Tela")]
    [SerializeField] private TextMeshProUGUI textoTempo;
    [SerializeField] private TextMeshProUGUI textoFragmentos;

    [Header("Aviso do Dash")]
    [SerializeField] private Image iconeDash;
    [SerializeField] private Color corDesativado = Color.gray;
    [SerializeField] private Color corPronto = Color.green;
    [SerializeField] private int custoDoDash = 3;

    [Header("Tela de Vitória")]
    [SerializeField] private GameObject painelFimDeFase;
    [SerializeField] private TextMeshProUGUI textoTempoFinal;

    private float tempoAtual = 0f;
    private bool cronometroRodando = true;

    void Update()
    {
        if (!cronometroRodando) return;

        tempoAtual += Time.deltaTime;
        AtualizarRelogio();
    }

    private void AtualizarRelogio()
    {
        int minutos = Mathf.FloorToInt(tempoAtual / 60f);
        int segundos = Mathf.FloorToInt(tempoAtual % 60f);
        int milissegundos = Mathf.FloorToInt((tempoAtual * 1000f) % 1000f);

        if (textoTempo != null)
        {
            textoTempo.text = $"{minutos:00}:{segundos:00}.{milissegundos:000}";
        }
    }

    
    public void AtualizarTextoFragmentos(int quantidadeAtual)
    {
        if (textoFragmentos != null)
        {
            textoFragmentos.text = $"Fragmentos: {quantidadeAtual}";
        }

        if (iconeDash != null)
        {
            if (quantidadeAtual >= custoDoDash)
            {
                iconeDash.color = corPronto;
            }
            else
            {
                iconeDash.color = corDesativado;
            }
        }
    }

    
    public void ExibirTelaDeVitoria()
    {
        cronometroRodando = false;
        Time.timeScale = 0f;

        if (GerenciadorDeSessao.instancia != null)
        {
            GerenciadorDeSessao.instancia.SomarTempoDaFase(tempoAtual);
        }

        if (painelFimDeFase != null)
        {
            painelFimDeFase.SetActive(true);
        }

        if (textoTempoFinal != null)
        {
            textoTempoFinal.text = $"Seu Tempo: {textoTempo.text}";
        }
    }
}