using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour
{
    public new PolygonCollider2D collider;
    public bool colliderChange = false;
    public int colliderMode = 0;

    List<List<Vector2>> colliderNode = new List<List<Vector2>>{
        new List<Vector2>{
            new Vector2(-0.02f,-0.34f),
            new Vector2(0.8f,-0.34f),
            new Vector2(1f,0.04f),
            new Vector2(-0.3f,1f),
            new Vector2(-1.05f,0.16f),
            new Vector2(-0.65f,0.16f)
        },
        new List<Vector2>{
            new Vector2(-0.3f,-0.8f),
            new Vector2(0.85f,-0.2f),
            new Vector2(1f,0.04f),
            new Vector2(-0.55f,0.7f),
            new Vector2(-1.05f,0.16f),
            new Vector2(-0.45f,0.16f)
        }
    };

    private List<string> GroundImageUrl = new List<string>{
            "bird1",
            "bird2",
        };

    // Start is called before the first frame update
    void Start()
    {
        int LocationY = Random.Range(0, 3);

    }

    // Update is called once per frame
    void Update()
    {
        if (Dinosaur.GameStart == false)
            return;

        transform.Translate(Vector3.left * (Time.deltaTime * 20));

        if (GetComponent<Transform>().localPosition.x < -50.5f)
        {
            Destroy(gameObject);
        }

        if (colliderChange)
        {
            collider.SetPath(0, colliderNode[colliderMode]);
            GetComponent<SpriteRenderer>().sprite =
            Resources.Load<Sprite>(GroundImageUrl[colliderMode]);
            colliderChange = false;
        }
    }
}
