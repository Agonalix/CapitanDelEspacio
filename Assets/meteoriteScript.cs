using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float force = 10f;  // Magnitud de la fuerza que se aplicar�
    public float movementDrag = 5f;  // Resistencia al movimiento, para ralentizar el meteorito

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = movementDrag;  // Establece la resistencia al movimiento
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Calcula la direcci�n desde el jugador hacia el meteorito
            Vector2 direction = (transform.position - collision.transform.position).normalized;
            // Aplica una fuerza en la direcci�n opuesta, con una magnitud menor que la fuerza original
            rb.AddForce(direction * force * 0.5f, ForceMode2D.Impulse);
        }
    }

    void Update()
    {
        // Resetea la posici�n si el meteorito se sale de los l�mites de la pantalla
        if (transform.position.x > 10f || transform.position.x < -10f ||
            transform.position.y > 10f || transform.position.y < -10f)
        {
            // Resetea la posici�n a un lugar aleatorio dentro de ciertos l�mites
            transform.position = new Vector2(Random.Range(-8f, 8f), Random.Range(-4f, 4f));
            // Detiene cualquier movimiento y rotaci�n del meteorito
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;  // Detiene la rotaci�n
        }
    }
}
