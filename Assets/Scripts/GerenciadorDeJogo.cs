using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorDeJogo : MonoBehaviour
{
    [Header("Interface")]
    [SerializeField] private GameObject painelGameOver;

    private bool jogoAcabou = false;

    void Start()
    {
        Time.timeScale = 1f;

        if (painelGameOver != null)
        {
            painelGameOver.SetActive(false);
        }
    }

    void Update()
    {
        
        if (!jogoAcabou) return;

        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Menu_Principal");
        }
    }

    public void AtivarGameOver()
    {
        jogoAcabou = true;

        if (painelGameOver != null)
        {
            painelGameOver.SetActive(true);
        }

        Time.timeScale = 0f;
    }
}