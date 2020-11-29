using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
  //HingeJointコンポーネントを入れる
  private HingeJoint myHingeJoint;

  //初期の傾き
  private float defaultAngle = 20;
  //弾いた時の傾き
  private float flickAngel = -20;

  // Start is called before the first frame update
  void Start()
  {
    //HingeJoingコンポーネント取得
    this.myHingeJoint = GetComponent<HingeJoint>();

    //フリッパーの傾きを設定
    SetAngle(this.defaultAngle);
  }

  // Update is called once per frame
  void Update()
  {
    //左矢印キー or "A"キーを押した時、左フリッパーを動かす
    if ((Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag") ||
        (Input.GetKeyDown(KeyCode.A) && tag == "LeftFripperTag"))
    {
      SetAngle(this.flickAngel);
    }
    //右矢印キー or "D"キーを押した時、右フリッパーを動かす
    if ((Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag") ||
        (Input.GetKeyDown(KeyCode.D) && tag == "RightFripperTag"))
    {
      SetAngle(this.flickAngel);
    }
    //下矢印キー or "S"キーを押したとき、両方のフリッパーを動かす
    if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
    {
      SetAngle(this.flickAngel);
    }


    //矢印キー離された時、フリッパーを元に戻す
    if ((Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag") ||
        (Input.GetKeyUp(KeyCode.A) && tag == "LeftFripperTag"))
    {
      SetAngle(this.defaultAngle);
    }
    if ((Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag") ||
        (Input.GetKeyUp(KeyCode.D) && tag == "RightFripperTag"))
    {
      SetAngle(this.defaultAngle);
    }
    if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
    {
      SetAngle(this.defaultAngle);
    }
  }

  //フリッパーの傾きを設定
  public void SetAngle(float angle)
  {
    JointSpring jointSpr = this.myHingeJoint.spring;
    jointSpr.targetPosition = angle;
    this.myHingeJoint.spring = jointSpr;
  }

    
}
