using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnduracneMeter : MonoBehaviour {

    public Image meter;
    public AnimationCurve ani; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Color c = meter.color;

        meter.fillAmount = Player.player.endurance;
        c.a = ani.Evaluate(Player.player.endurance);
        meter.color = c;
	}
}
