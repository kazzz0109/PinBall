using UnityEngine;
using System.Collections;
public class FripperController : MonoBehaviour {
	//HingiJointコンポーネントを入れる
	private HingeJoint myHingeJoint;

	//初期の傾き
	private float defaultAngle = 20;
	//弾いた時の傾き
	private float flickAngle = -20;

	// Use this for initialization
	void Start () {
		//HingeJointコンポーネント取得
		this.myHingeJoint = GetComponent<HingeJoint>();

		//フリッパーの傾きを設定
		SetAngle(this.defaultAngle);
	}

	// Update is called once per frame
	void Update () {

		//左矢印キーを押した時左フリッパーを動かす
		if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.flickAngle);
		}
		//右矢印キーを押した時右フリッパーを動かす
		if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.flickAngle);
		}

		//矢印キー離された時フリッパーを元に戻す
		if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.defaultAngle);
		}
		if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.defaultAngle);
		}

		//タッチ用
		for (int i = 0; i < Input.touchCount; i++)
		{
			var pos = Input.touches[i].position;
			int width  = Screen.width;

			Touch touch = Input.touches[i];
			if (touch.phase == TouchPhase.Began) {
				if (pos.x < width / 2 && tag == "LeftFripperTag") {
					SetAngle (this.flickAngle);
				}
				if (pos.x > width / 2 && tag == "RightFripperTag") {
					SetAngle (this.flickAngle);
				}
			}

			if (touch.phase == TouchPhase.Ended) {
					if (pos.x < width / 2 && tag == "LeftFripperTag") {
						SetAngle (this.defaultAngle);
					}
					if (pos.x > width / 2 && tag == "RightFripperTag") {
						SetAngle (this.defaultAngle);
					}
				}
			}
	}

	//フリッパーの傾きを設定
	public void SetAngle (float angle){
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;
	}
}