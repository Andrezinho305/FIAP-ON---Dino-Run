using UnityEngine;
// Importa a biblioteca principal da Unity, que fornece acesso a componentes, física, input e sistema de cena

public class DinoScript : MonoBehaviour
// Classe que controla o comportamento do personagem (dino), herdando de MonoBehaviour para funcionar na Unity
{
    [SerializeField] private float jumpForce = 8.0f;
    // Força aplicada no pulo do personagem
    // SerializeField permite ajustar esse valor diretamente no Inspector sem tornar a variável pública

    private Rigidbody2D rigidBody2D;
    // Referência ao componente de física 2D, responsável por movimentação e gravidade

    private AudioSource audioSource;
    // Componente responsável por reproduzir sons (ex: som do pulo)

    private bool onGround;
    // Indica se o personagem está tocando o chão (true = pode pular)

    private bool jumping;
    // Controla o momento em que o pulo será aplicado na física

    private void Awake()
    {
        // Awake é chamado assim que o objeto é carregado na cena

        rigidBody2D = GetComponent<Rigidbody2D>();
        // Busca e armazena o componente Rigidbody2D no próprio objeto

        audioSource = GetComponent<AudioSource>();
        // Busca e armazena o componente de áudio no objeto
    }

    private void Update()
    {
        // Update roda a cada frame (ideal para entrada de comando do jogador)

        if (Input.GetButtonDown("Jump") && onGround == true)
        {
            // Verifica se o botão de pulo foi pressionado E se o personagem está no chão

            audioSource.Play();
            // Reproduz o som de pulo

            jumping = true;
            // Ativa a flag para aplicar o pulo na física (FixedUpdate)
        }
    }

    private void FixedUpdate()
    {
        // FixedUpdate roda em intervalos fixos (ideal para física)

        if (jumping == true)
        {
            // Se o pulo foi acionado

            rigidBody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            // Aplica uma força instantânea para cima, simulando o impulso do pulo

            jumping = false;
            // Desativa a flag para evitar múltiplos pulos consecutivos
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Chamado quando ocorre uma colisão inicial com outro objeto

        if (collision.collider.tag == "Hazard")
        {
            // Se colidir com um objeto que tenha a tag "Cactus"

            Destroy(gameObject);
            // Destroi o personagem (game over)
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Chamado continuamente enquanto o personagem está colidindo com algo

        if (collision.collider.tag == "Ground")
        {
            // Se estiver em contato com o chão

            onGround = true;
            // Permite pular novamente
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Chamado quando o personagem para de colidir com algo

        if (collision.collider.tag == "Ground")
        {
            // Se saiu do chão

            onGround = false;
            // Impede pulo até tocar o chão novamente
        }
    }
}