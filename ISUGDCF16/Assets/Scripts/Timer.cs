using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

    public Text clockText;
    private float startTime;
    private bool complete = false;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if(complete) {
            return;
        }

        float t = Time.time - startTime;
        string mins = ((int)t / 60).ToString();
        string secs = (t % 60).ToString("f2");

        clockText.text = mins + ":" + secs;
	}

    //called once track is finished
    public void finished() {
        complete = true;
        clockText.color = Color.green;
    }
}
