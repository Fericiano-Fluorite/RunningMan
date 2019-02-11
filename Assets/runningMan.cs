using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class runningMan : MonoBehaviour
{
    public int startSpeed;
    public float jumpForce;
    public int groundMoveSpeed;
    public int airMoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(startSpeed, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)&& BeOnGround()) {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if(BeOnGround())
                GetComponent<Rigidbody2D>().velocity=new Vector2(groundMoveSpeed, 0);
            else
                GetComponent<Rigidbody2D>().velocity = new Vector2(airMoveSpeed, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if(BeOnGround())
                GetComponent<Rigidbody2D>().velocity = new Vector2(-groundMoveSpeed, 0);
            else
                GetComponent<Rigidbody2D>().velocity = new Vector2(-airMoveSpeed, 0);
        }

    }
    bool BeOnGround() {
        Bounds bounds = GetComponent<Collider2D>().bounds;
        float range = bounds.size.y * 0.1f;
        Vector2 v = new Vector2(bounds.center.x, bounds.min.y - range);
        RaycastHit2D hit = Physics2D.Linecast(v, bounds.center);
        return (hit.collider.gameObject != gameObject);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.transform.tag == "Finish") {
            SceneManager.LoadScene("success");
        }
    }
}
