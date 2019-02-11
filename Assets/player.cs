using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public int velocity;
    public int upDistance = 150;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(velocity, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ground())
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, upDistance));
        }
        else if (Input.GetKey(KeyCode.RightArrow) && ground())
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && ground())
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 0);
        }
    //    else if((Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.RightArrow))&& ground())
      //  {
      //      GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
     //   }
    }
    bool ground()
    {
        Bounds bound = GetComponent<Collider2D>().bounds;
        float distance = bound.size.y * 0.1f;
        Vector2 v = new Vector2(bound.center.x, bound.min.y - distance);
        RaycastHit2D hit = Physics2D.Linecast(v, bound.center);
        return (hit.collider.gameObject != gameObject);

    }
}
