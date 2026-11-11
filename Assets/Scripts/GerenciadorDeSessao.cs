using UnityEngine;

public class GerenciadorDeSessao : MonoBehaviour
{
    // O Singleton: Todos podem ACESSAR (get), mas só este script pode DEFINIR (private set)
    public static GerenciadorDeSessao instancia { get; private set; }

    
    public float tempoTotalDoJogo { get; private set; }

    void Awake()
    {
        // Garante que só existe uma única instância ativa 
        if (instancia != null && instancia != this)
        {
            Destroy(gameObject);
            return;
        }

        instancia = this;

        
        DontDestroyOnLoad(gameObject);
    }

    public void SomarTempoDaFase(float tempoDaFase)
    {
        tempoTotalDoJogo += tempoDaFase;
        Debug.Log($"Tempo total acumulado: {tempoTotalDoJogo}");
    }

    public void DestruirSessao()
    {
        // Limpa a memória para que uma nova partida comece 
        Destroy(gameObject);
    }
}