using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class monsterBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public int initialSpeed;
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(initialSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Rigidbody2D>().velocity.x <=1) {
            GetComponent<Rigidbody2D>().velocity = new Vector2(initialSpeed, 0);
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.tag == "Player")
        {
            SceneManager.LoadScene("Fail");
        }
    }
}
