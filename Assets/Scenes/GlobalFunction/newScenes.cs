using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;



public class newScenes : MonoBehaviour
{


    private List<string> GroundImageUrl = new List<string>{
            "ground1",
            "ground2",
            "ground3",
        };

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite =
            Resources.Load<Sprite>(GroundImageUrl[Random.Range(0, 3)]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Dinosaur.GameStart == true)
        {
            if (GetComponent<Transform>().localPosition.x < -50.5f)
            {
                var v = this.transform.localPosition;
                v.x += 108.5f;
                var item = Instantiate(this, v, Quaternion.identity);
                item.name = this.name;
                Destroy(gameObject);
            }
            var v1 = this.transform.localPosition;
            transform.Translate(Vector3.left * (Time.deltaTime * 16));
        }
    }
}
