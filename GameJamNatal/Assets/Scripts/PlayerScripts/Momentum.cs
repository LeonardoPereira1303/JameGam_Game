using UnityEngine;

public class PlayerMovement2DWithMomentum : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5f;         // Velocidade máxima
    public float acceleration = 10f; // Controle da aceleração
    public float deceleration = 5f; // Controle da desaceleração
    public float momentumFactor = 0.9f; // Fator de momentum (0 a 1)

    private Vector2 velocity;       // Velocidade atual
    private Vector2 inputDirection; // Direção de entrada do jogador
    private Rigidbody2D rb;        // Referência ao Rigidbody2D

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtém o Rigidbody2D anexado ao objeto
    }

    void Update()
    {
        // Captura a entrada do jogador (teclas WASD ou setas)
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        inputDirection = new Vector2(horizontal, vertical).normalized;

        // Calcula o momentum
        if (inputDirection.magnitude > 0)
        {
            // Aceleração quando há entrada do jogador
            velocity = Vector2.Lerp(velocity, inputDirection * speed, acceleration * Time.deltaTime);
        }
        else
        {
            // Desaceleração gradual quando não há entrada
            velocity = Vector2.Lerp(velocity, Vector2.zero, deceleration * Time.deltaTime);
        }

        // Aplica o momentum
        velocity *= momentumFactor;
    }

    void FixedUpdate()
    {
        // Move o personagem usando física
        rb.velocity = velocity;

        // Rotaciona o personagem para a direção do movimento
        if (velocity.magnitude > 0.1f)
        {
            float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
        }
    }
}
