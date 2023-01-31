using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Dinosaur.GameStart == false)
            return;

        transform.Translate(Vector3.left * (Time.deltaTime * 16));

        if (GetComponent<Transform>().localPosition.x < -50.5f)
        {
            Destroy(gameObject);
        }
    }
}
