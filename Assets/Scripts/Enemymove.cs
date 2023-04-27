using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemymove : MonoBehaviour
{
    public float EnemySpeed;
    public float XMoveDirection;

    [SerializeField]
    string sceneName;

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity =
            new Vector2(XMoveDirection, 0) * EnemySpeed;
        if (hit.distance < 0.3f)
        {
            Flip();
            if (hit.collider != null)
            {
                if (hit.collider.tag == "player")
                {
                    Destroy(hit.collider.gameObject);
                    //restart the secne after destroy the player
                    SceneManager.LoadScene(sceneName);
                }
            }
        }
    }

    void Flip()
    {
        if (XMoveDirection > 0)
        {
            XMoveDirection = -1;
        }
        else
        {
            XMoveDirection = 1;
        }
    }
}
