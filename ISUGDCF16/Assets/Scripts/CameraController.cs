using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public float cameraSpeed;
    private Transform anchor;
    private Vector3 euler = Vector3.zero;

    void Start() {
        anchor = transform.parent;
    }

    void Update() {
        //parent object follows player, euler angles Mouse X and Mouse Y
        anchor.transform.position = player.transform.position;

        euler.y += Input.GetAxis("Mouse X") * cameraSpeed * Time.deltaTime;
        euler.x += Input.GetAxis("Mouse Y") * cameraSpeed * Time.deltaTime;

        euler.x = Mathf.Clamp(euler.x, -30f, 70f);
        anchor.transform.eulerAngles = euler;
        anchor.transform.LookAt(player.transform);
    }
}
  