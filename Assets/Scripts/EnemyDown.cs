using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDown : MonoBehaviour
{
    public float EnemySpeed;
    public float YMoveDirection;

    [SerializeField]
    string sceneName;

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit3d = Physics2D.Raycast(transform.position, new Vector2(0, YMoveDirection));
        gameObject.GetComponent<Rigidbody2D>().velocity =
            new Vector2(0, YMoveDirection) * EnemySpeed;
        if (hit3d.distance < 0.3f)
        {
            Flip();
            //
            if (hit3d.collider != null)
            {
                if (hit3d.collider.tag == "player")
                {
                    Destroy(hit3d.collider.gameObject);
                    SceneManager.LoadScene(sceneName);
                }
            }
        }
    }

    void Flip()
    {
        if (YMoveDirection > 0)
        {
            YMoveDirection = -1;
        }
        else
        {
            YMoveDirection = 1;
        }
    }
}
