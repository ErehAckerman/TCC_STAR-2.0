using UnityEngine;

public class Coletavel : MonoBehaviour
{
    [Header("Configurações do Coletável")]
    [SerializeField] private int valorDoFragmento = 1;

    void OnTriggerEnter2D(Collider2D outro)
    {
        // Confere se quem bateu no fragmento foi a Estrela
        if (outro.CompareTag("Player"))
        {
            
            MovimentoEstrela scriptDaEstrela = outro.GetComponent<MovimentoEstrela>();

            
            if (scriptDaEstrela != null)
            {
                
                scriptDaEstrela.AlterarFragmentos(valorDoFragmento);

                
                Destroy(gameObject);
            }
        }
    }
}