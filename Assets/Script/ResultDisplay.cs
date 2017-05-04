using UnityEngine;
using UnityEngine.UI;

public class ResultDisplay : MonoBehaviour {

    public Text score;

	void Start () {

        score = GetComponent<Text>();

        //score.text = "助けた人数" + people.GetScore().ToString() + "名";
	}
}