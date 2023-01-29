using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinosaur : MonoBehaviour
{
    public bool GameStart = false;
    public Animator dinosaurAni;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(new Vector2(0, 20), ForceMode2D.Impulse);
            if (GameStart == false)
            {
                dinosaurAni.SetBool("GameStart", true);
                GameStart = true;
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            dinosaurAni.SetBool("Squat",true);
        }
        else
        {
            dinosaurAni.SetBool("Squat",false);
        }
    }
}
