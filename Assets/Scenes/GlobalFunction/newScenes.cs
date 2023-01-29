using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

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
        this.GetComponent<SpriteRenderer>().sprite =
            Resources.Load<Sprite>(GroundImageUrl[Random.Range(0, 3)]);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
