using UnityEngine;

public class PerigoMortal : MonoBehaviour
{
    private GerenciadorDeJogo gerenciador;

    void Start()
    {
        
        gerenciador = FindFirstObjectByType<GerenciadorDeJogo>();
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.CompareTag("Player"))
        {
            
            if (gerenciador != null)
            {
                gerenciador.AtivarGameOver();
            }
        }
    }
}