using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    private Text scoreText;

    private int score;

    // Start is called before the first frame update
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        gameoverText = GameObject.Find("GameOverText");

        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (transform.position.z < visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        var contactObject = collision.gameObject;
        
        if (contactObject.CompareTag("SmallStarTag"))
        {
            score += 10;
        }
        else if (contactObject.CompareTag("LargeStarTag"))
        {
            score += 50;
        }
        else if (contactObject.CompareTag("SmallCloudTag"))
        {
            score += 80;
        }
        else if (contactObject.CompareTag("LargeCloudTag"))
        {
            score += 160;
        }

        scoreText.text = $"Score:{score}";
    }
}
