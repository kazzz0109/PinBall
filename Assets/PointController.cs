using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PointController : MonoBehaviour {
	private GameObject pointText;
	private int point = 0;
	// Use this for initialization
	void Start () {
		this.pointText = GameObject.Find("PointText");
		this.pointText.GetComponent<Text> ().text = "0";
	}
	
	// Update is called once per frame
	void Update () {
		string p = point.ToString ();
		this.pointText.GetComponent<Text> ().text = p;
	}
	void OnCollisionEnter(Collision other) {

		if (other.gameObject.tag == "SmallStarTag") {
			point += 10;
		} else if (other.gameObject.tag == "LargeStarTag") {
			point += 20;
		}else if(other.gameObject.tag == "SmallCloudTag" || other.gameObject.tag == "LargeCloudTag") {
			point += 30;
		}
	}
}
