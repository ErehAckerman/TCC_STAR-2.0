using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [Header("Configurações da Fase")]
    [SerializeField] private string nomeDaProximaFase;

    [Header("Comunicação")]
    [SerializeField] private UIManager gerenciadorDeUI;

    private bool faseConcluida = false;

    void Update()
    {
        if (!faseConcluida) return;

        // Aceita tanto o Enter principal quanto o Enter do teclado numérico
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(nomeDaProximaFase);
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Menu_Principal");
        }
    }

    void OnTriggerEnter2D(Collider2D outro)
    {    // Confere se foi a estrela que encostou no portal
        if (outro.CompareTag("Player") && !faseConcluida)
        {
            faseConcluida = true;

            if (gerenciadorDeUI != null)
            {
                gerenciadorDeUI.ExibirTelaDeVitoria();
            }
        }
    }
}