using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class moveplat : MonoBehaviour
{
  public float PlatSpeed;
    public float XMoveDirection;
    
    // Update is called once per frame
    void Update()
    {
    RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0));
    gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * PlatSpeed;
    if(hit.distance<0.3f)
    {
        Flip();
       
        }
       
    }

    
    void Flip()
    {
        if(XMoveDirection > 0)
        {
            XMoveDirection = -1;
        }
        else
        {
            XMoveDirection = 1;
        }
    }
}
