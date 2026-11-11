using UnityEngine;

public class Gravidade : MonoBehaviour
{
    [Header("Configurações do Buraco Negro")]
    [SerializeField] private float forcaDeAtracao = 2f;

    void OnTriggerStay2D(Collider2D outro)
    {
        if (outro.CompareTag("Player"))
        {
            // Puxa o jogador passo a passo até o centro deste objeto
            outro.transform.position = Vector2.MoveTowards(
                outro.transform.position,
                transform.position,
                forcaDeAtracao * Time.deltaTime
            );
        }
    }
}