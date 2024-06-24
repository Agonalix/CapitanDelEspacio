using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : MonoBehaviour
{
    public float movSpeed;
    float speedX;
    float speedY;
    Rigidbody2D rb;
    Camera _camera;
    public float reducedSpeed = 2.0f;
    public float speedReductionTime = 2.0f;
    float originalSpeed;
    bool isSpeedReduced = false;

    [SerializeField]
    float screenBorder;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
        originalSpeed = movSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        speedX = Input.GetAxis("Horizontal") * movSpeed;
        speedY = Input.GetAxis("Vertical") * movSpeed;
        rb.velocity = new Vector2(speedX, speedY);

        Vector2 screenPosition = _camera.WorldToScreenPoint(transform.position);

        if ((screenPosition.x < screenBorder && rb.velocity.x < 0) ||
            (screenPosition.x > _camera.pixelWidth - screenBorder && rb.velocity.x > 0))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if ((screenPosition.y < screenBorder && rb.velocity.y < 0) ||
            (screenPosition.y > _camera.pixelHeight - screenBorder && rb.velocity.y > 0))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
        if (isSpeedReduced)
        {
            StartCoroutine(RestoreSpeedAfterDelay());
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Meteorite")
        {
            movSpeed = reducedSpeed;
            isSpeedReduced = true;
        }
        if (collision.gameObject.tag == "Nave")
        {
            NaveScript naveController = collision.gameObject.GetComponent<NaveScript>();
            if (naveController != null)
            {
                naveController.SetIsKinematic(true); // Cambia isKinematic a true cuando el jugador toca la nave
            }
        }
        if (collision.gameObject.tag == "Moon")
        {

        }
    }

    IEnumerator RestoreSpeedAfterDelay()
    {
        yield return new WaitForSeconds(speedReductionTime);
        movSpeed = originalSpeed;
        isSpeedReduced = false;
    }



}
