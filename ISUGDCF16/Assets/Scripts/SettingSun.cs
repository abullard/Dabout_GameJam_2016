using UnityEngine;
using System.Collections;

public class SettingSun : MonoBehaviour {
    public float startX = 0f;
    public float startY = 1f;
    public float startZ = -15f;
    public float endX = 0f;
    public float endY = 1f;
    public float endZ = 15f;
    public float trajectoryHeight = 10f;
    Vector3 startPos;
    Vector3 endPos;
    Vector3 curPos;

    void Start()
    {
        startPos = new Vector3(startX, startY, startZ);
        endPos = new Vector3(endX, endY, endZ);
    }
    
    // Update is called once per frame
    void Update () {
        if(curPos.z == startZ)
        {
            startPos = new Vector3(startX, startY, startZ+1);
            endPos = new Vector3(endX, endY, endZ);
        }
        if (curPos.z == endZ)
        {
            startPos = new Vector3(endX, endY, endZ-1);
            endPos = new Vector3(startX, startY, startZ);
        }

        //get the current time within the lerping time range
        float cTime = Time.time * .2f;

        //calculate the straight line lerp position
        curPos = Vector3.Lerp(startPos, endPos, cTime);

        //add a value to Y, using Sine to give a curved trajectory in the Y direction
        curPos.y += trajectoryHeight * Mathf.Sin(Mathf.Clamp01(cTime) * Mathf.PI);

        //assign new position to the game object
        transform.position = curPos;
    }
}