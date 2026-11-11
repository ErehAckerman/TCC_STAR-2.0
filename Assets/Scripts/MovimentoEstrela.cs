using UnityEngine;

public class MovimentoEstrela : MonoBehaviour
{
    [Header("Física e Movimento")]
    [SerializeField] private Rigidbody2D meuRigidbody;
    [SerializeField] private float velocidade = 5f;

    [Header("Hiper Salto (Dash)")]
    [SerializeField] private int custoDoSalto = 3;
    [SerializeField] private float multiplicadorDeVelocidade = 4f;
    [SerializeField] private float tempoDoSalto = 0.2f;

    [Header("Interface")]
    [SerializeField] private UIManager gerenciadorDeUI;

    
    private int fragmentosColetados = 0;

    private float cronometroDoSalto;
    private bool emHiperSalto = false;
    private Vector2 entradaDeMovimento;

    void Update()
    {
        // O Update serve para ler botões e cronômetros apenas
        entradaDeMovimento.x = Input.GetAxisRaw("Horizontal");
        entradaDeMovimento.y = Input.GetAxisRaw("Vertical");

       
        if (Input.GetKeyDown(KeyCode.Space) && fragmentosColetados >= custoDoSalto && !emHiperSalto)
        {
            AlterarFragmentos(-custoDoSalto); 
            emHiperSalto = true;
            cronometroDoSalto = tempoDoSalto;
        }

       
        if (emHiperSalto)
        {
            cronometroDoSalto -= Time.deltaTime;
            if (cronometroDoSalto <= 0)
            {
                emHiperSalto = false;
            }
        }
    }

    void FixedUpdate()
    {
        
        if (emHiperSalto)
        {
            meuRigidbody.linearVelocity = entradaDeMovimento * velocidade * multiplicadorDeVelocidade;
        }
        else
        {
            meuRigidbody.linearVelocity = entradaDeMovimento * velocidade;
        }
    }

    // Só atualiza a tela quando o valor realmente muda
    public void AlterarFragmentos(int quantidade)
    {
        fragmentosColetados += quantidade;

        if (gerenciadorDeUI != null)
        {
            gerenciadorDeUI.AtualizarTextoFragmentos(fragmentosColetados);
        }
    }
}