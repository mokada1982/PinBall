using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//--------------------------------------------------
//追加
//--------------------------------------------------
using UnityEngine.UI;

public class CalcScore : MonoBehaviour
{
  //Score
  private int scoreVal;

  //Scoreを表示するテキスト
  private GameObject scoreText;

  //--------------------------------------------------
  // Start is called before the first frame update
  //--------------------------------------------------
  void Start()
  {
    //scoreの値を0にリセット
    scoreVal = 0;

    //シーン中のScoreTextオブジェクトを取得
    this.scoreText = GameObject.Find("ScoreText");
  }

  //--------------------------------------------------
  // Update is called once per frame
  //--------------------------------------------------
  void Update()
  {
    //scoreを表示
    this.scoreText.GetComponent<Text>().text = scoreVal.ToString() + "点";
  }

  //--------------------------------------------------
  //衝突時に呼ばれる関数
  //--------------------------------------------------
  void OnCollisionEnter(Collision other)
  {
    //衝突相手のタグを取得
    string nameStr = other.gameObject.tag;

    if (nameStr == "SmallStarTag")
    {
      scoreVal += 10;
    }
    else if (nameStr == "LargeStarTag")
    {
      scoreVal += 20;
    }
    else if (nameStr == "SmallCloudTag")
    {
      scoreVal += 50;
    }
    else if (nameStr == "LargeCloudTag")
    {
      scoreVal += 100;
    }
  }
}
