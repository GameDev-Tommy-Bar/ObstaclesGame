using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSingel : MonoBehaviour
{
    public int PlayerSpeed = 10;
    public bool faceRight = true;
    public int PlayerJumpPower = 1250;
    public float moveX;
    public bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        PlayerMover();
    }

    void PlayerMover()
    {
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
        if (moveX < 0.0f && faceRight == false)
        {
            FlipPlayer();
        }
        else if (moveX > 0.0f && faceRight)
        {
            FlipPlayer();
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(
            moveX * PlayerSpeed,
            gameObject.GetComponent<Rigidbody2D>().velocity.y
        );
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * PlayerJumpPower);
        isGrounded = false;
    }

    void FlipPlayer()
    {
        faceRight = !faceRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other) { }

    void PlayerRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if (hit.distance < 0.9f && hit.collider.tag == "Enemy")
        {
            Debug.Log("tuch the enemy");
            Destroy(hit.collider.gameObject);
        }
    }
}
