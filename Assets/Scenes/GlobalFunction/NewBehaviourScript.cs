using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject Itme_Ground;
    public GameObject Itme_GroundStyle;
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
        if (fpsOfCreateObstacle_count >= fpsOfCreateObstacle) {
            if (fpsOfCreateObstacle < 180)
            {
                List<string> Obstacle_Mode =
                    new List<string> {
                        "GameCore/Prefab/Cactus",
                        "GameCore/Prefab/Cactus_big",
                    };

                var itemObstacle = Instantiate(
                    Resources.Load(Obstacle_Mode[Random.Range(0, 2)]),
                    new Vector3(55f, -6.22f, 90f),
                    Quaternion.identity
                    );
                fpsOfCreateObstacle_count = 0;
                fpsOfCreateObstacle = Random.Range(50, 210);
            }
            else if (fpsOfCreateObstacle >= 180)
            {
                List<float> Position_Mode =
                    new List<float> {
                        -3f,
                        -5f,
                        -6.35f,
                    };
                var itemObstacle = Instantiate(
                    Resources.Load("GameCore/Prefab/Bird"),
                    new Vector3(55f, Position_Mode[Random.Range(0, 3)], 90f),
                    Quaternion.identity
                    );
                fpsOfCreateObstacle_count = 0;
                fpsOfCreateObstacle = Random.Range(50, 210);
            }
        }
    }
}
