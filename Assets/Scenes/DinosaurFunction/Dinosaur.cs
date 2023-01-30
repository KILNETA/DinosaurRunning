using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Dinosaur : MonoBehaviour
{
    static public bool GameLose = false;
    static public bool GameStart = false;
    public Animator dinosaurAni;
    public new PolygonCollider2D collider;
    public BoxCollider2D groundCollider;
    public TextMeshProUGUI  Item_MainText;

    List<List<Vector2>> colliderMode = new List<List<Vector2>>{
        new List<Vector2>{
            new Vector2(0.5f,-0.07f),
            new Vector2(0.5f,0.53f),
            new Vector2(-1.7f,0.53f),
            new Vector2(-1.7f,-0.96f),
            new Vector2(-1.27f,-1.4f),
            new Vector2(-1.15f,-1.85f),
            new Vector2(-0.38f,-1.85f),
            new Vector2(-0.38f,-1.36f)
        },
        new List<Vector2>{
            new Vector2(1.08f,-1.23f),
            new Vector2(1.36f,-1f),
            new Vector2(1.36f,-0.39f),
            new Vector2(-1.83f,-0.39f),
            new Vector2(-1.83f,-0.87f),
            new Vector2(-1.27f,-1.4f),
            new Vector2(-1.15f,-1.85f),
            new Vector2(-0.38f,-1.85f),
            new Vector2(-0.38f,-1.23f)
        }
    };

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (
            GameLose == false &&
            (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) &&
            collider.IsTouching(groundCollider)

        )
        {
            rb.AddForce(new Vector2(0, 35), ForceMode2D.Impulse);
            if (GameStart == false)
            {
                dinosaurAni.SetBool("GameStart", true);
                GameStart = true;
            }
            Item_MainText.text = "";
        }

        if (GameStart == false)
            return;

        if (Input.GetKey(KeyCode.DownArrow))
        {
            dinosaurAni.SetBool("Squat",true);
            collider.SetPath(0,colliderMode[1]);
        }
        else
        {
            dinosaurAni.SetBool("Squat",false);
            collider.SetPath(0, colliderMode[0]);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            GameStart = false;
            GameLose = true;
            dinosaurAni.SetBool("GameLose", true);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            Item_MainText.text = "Game Over!";
        }
    }
}
