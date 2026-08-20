using UnityEngine; // Importa a biblioteca principal da Unity

public class Cactus : MonoBehaviour // Define a classe Cactus que herda de MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    // Define a velocidade de movimento do cacto
    // SerializeField permite ajustar esse valor diretamente no Inspector

    [SerializeField] private float positionXtoDestroy = -12.0f;
    // Define a posição limite no eixo X onde o objeto será destruído
    // Esse valor representa o ponto em que o cacto já saiu da área visível da câmera

    void Update()
    {
        // Update é chamado a cada frame

        transform.Translate(Vector2.left * speed * Time.deltaTime);
        // Move o objeto continuamente para a esquerda
        // Vector2.left representa a direção (-1 no eixo X)
        // speed define a velocidade do movimento
        // Time.deltaTime garante que o movimento seja independente do FPS

        if (transform.position.x < positionXtoDestroy)
        {
            // Verifica se a posição do cacto no eixo X ultrapassou o limite definido

            Destroy(gameObject);
            // Remove o objeto da cena
            // Isso evita acúmulo de objetos fora da tela e melhora o desempenho do jogo
        }
    }
}