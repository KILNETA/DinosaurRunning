using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{

    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    // Start is called before the first frame update
    void Start()
    {

        GameObject Itme_Ground = GameObject.Find("Ground");
        var v = Itme_Ground.transform.localPosition;
        for (int i = 0; i <= 8; i++) {
            v.x += 5;
            Instantiate(Itme_Ground, v, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
