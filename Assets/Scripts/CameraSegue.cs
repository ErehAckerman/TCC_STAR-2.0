using UnityEngine;

public class CameraSegue : MonoBehaviour
{
    [Header("Configurações de Alvo")]
    [SerializeField] private Transform alvo;

    
    [SerializeField] private Vector3 distanciaDaCamera = new Vector3(0f, 0f, -10f);

    void LateUpdate()
    {
        
        if (alvo != null)
        {
            transform.position = alvo.position + distanciaDaCamera;
        }
    }
}