using UnityEngine;

public class ControleJogador : MonoBehaviour
{
    public float velocidade = 5f;
    private Rigidbody2D fisica;
    private Vector2 direcao;
    private int pontuacao = 0;
    // Não acho que um dia eu verei isso novamente. Mas será legal se acontecer :)
    // Projeto finalizado no dia 14/09/2026 às 06:00 (literalmente nesse horário kkkk)
    // Deus é o caminho!
    void Start()
    {
        fisica = GetComponent<Rigidbody2D>();
    }

    public void OnMove(UnityEngine.InputSystem.InputAction.CallbackContext input)
    {
        direcao = input.ReadValue<Vector2>();
    }

    void Update()
    {
        fisica.linearVelocity = direcao * velocidade;
    }

    void OnTriggerEnter2D(Collider2D colisao)
    {
        if (colisao.gameObject.tag == "Orb")
        {
            Destroy(colisao.gameObject);
            pontuacao++;
            Debug.Log("Orbes coletadas: " + pontuacao + "/10");

            if (pontuacao >= 10)
            {
                Debug.Log("Você venceu! Coletou todas as 10 Orbs!");
            }
        }
    }
}