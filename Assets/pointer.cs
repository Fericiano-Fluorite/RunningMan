using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pointer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject memuStart;
    public GameObject memuQuit;
    public int curPos = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (curPos == 0) {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, memuStart.transform.position.y);
        }

        if (curPos == 1) {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, memuQuit.transform.position.y);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.DownArrow)) {
            curPos = 1 - curPos;
        }

        if (Input.GetKeyDown(KeyCode.Return)){
            if (curPos == 0) {
                SceneManager.LoadScene("main");
                return;
            }
            if (curPos == 1) {
                Application.Quit();
                return;
            }
        }

    }
}
