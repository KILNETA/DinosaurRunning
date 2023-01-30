using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject Itme_Ground;
    public GameObject Itme_GroundStyle;
    public GameObject Itme_Obstacle;
    private int fpsOfCreateObstacle = 0;
    private int fpsOfCreateObstacle_count = 0;

    static public int Score = 0;
    static int ScoreCount = 0;
    public TextMeshProUGUI Item_ScoreText;

    void Awake()
    {
        fpsOfCreateObstacle = Random.Range(0, 240);
        Application.targetFrameRate = 60;
    }

    // Start is called before the first frame update
    void Start()
    {
        var vItme_Ground = Itme_Ground.transform.localPosition;
        var vItme_GroundStyle = Itme_GroundStyle.transform.localPosition;
        for (int i = 0; i <= 1; i++) {
            vItme_Ground.x += 36.5f;
            vItme_GroundStyle.x += 36.5f;
            var itemGround = Instantiate(Itme_Ground, vItme_Ground, Quaternion.identity);
            itemGround.name = Itme_Ground.name + "_" + i;
            var itemGroundStyle = Instantiate(Itme_GroundStyle, vItme_GroundStyle, Quaternion.identity);
            itemGroundStyle.name = Itme_GroundStyle.name + "_" + i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Dinosaur.GameStart == false || Dinosaur.GameLose == true)
            return;

        ScoreCount++;
        if (ScoreCount >= 60)
        {
            ScoreCount = 0;
            Score++;
            Item_ScoreText.text = Score.ToString();
        }

        fpsOfCreateObstacle_count++;
        if (fpsOfCreateObstacle_count >= fpsOfCreateObstacle)
        {
            var vItme_Obstacle = Itme_Obstacle.transform.localPosition;
            var itemObstacle = Instantiate(Itme_Obstacle, vItme_Obstacle, Quaternion.identity);
            itemObstacle.name = Itme_Obstacle.name + "_";
            fpsOfCreateObstacle_count = 0;
            fpsOfCreateObstacle = Random.Range(50, 210);
        }
    }
}
