using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public new PolygonCollider2D collider;
    private List<string> GroundImageUrl = new List<string>{
            "cactus1",
            "cactus2"
        };
    List<List<Vector2>> colliderMode = new List<List<Vector2>>{
        new List<Vector2>{
            new Vector2(0.55f,-1.93f),
            new Vector2(0.55f,0.39f),
            new Vector2(-0.15f,0.8f),
            new Vector2(-0.63f,0.07f),
            new Vector2(-0.63f,-1.93f)
        },
        new List<Vector2>{
            new Vector2(1.8f,-1.93f),
            new Vector2(1.8f,-0.39f),
            new Vector2(1.36f,0.65f),
            new Vector2(-1.4f,0.65f),
            new Vector2(-1.8f,-0.02f),
            new Vector2(-1.8f,-1.93f)
        }
    };

    // Start is called before the first frame update
    void Start()
    {
        int random = Random.Range(0, 2);
        GetComponent<SpriteRenderer>().sprite =
            Resources.Load<Sprite>(GroundImageUrl[random]);
        collider.SetPath(0, colliderMode[random]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Dinosaur.GameStart == true && this.name != "Cactus")
        {
            if (GetComponent<Transform>().localPosition.x < -50.5f)
            {
                Destroy(gameObject);
            }
            var v1 = this.transform.localPosition;
            transform.Translate(Vector3.left * (Time.deltaTime * 16));
        }

    }
}
