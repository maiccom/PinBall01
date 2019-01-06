using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    //スコアを表示するテキスト
    private GameObject scoreText;

    //スコア
    private int score;

    // Use this for initialization
    void Start()
    {
        
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        //シーン中のScoreTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");

        //ScoreTextにスコアを表示
        this.scoreText.GetComponent<Text>().text = "SCORE:" + this.score;


    }

    // Update is called once per frame
    void Update()
    {

        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over!!";
        }
    }

    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {
        // タグによって加算するスコアを決める
        if (other.gameObject.tag == "SmallStarTag")
        {
            this.score += 10;
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            this.score += 20;
        }
        else if (other.gameObject.tag == "SmallCloudTag")
        {
            this.score += 15;
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            this.score += 25;
        }

        //ScoreTextにスコアを表示
        this.scoreText.GetComponent<Text>().text = "SCORE:" + this.score;
    }


}