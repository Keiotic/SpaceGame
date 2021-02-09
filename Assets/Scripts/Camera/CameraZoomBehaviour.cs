using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraZoomBehaviour : MonoBehaviour
{
    public bool playerHasZoomControl = true;
    public float minimumZoom = 1;
    public float maximumZoom = 10;
    public float inputSizeCoefficient = 0.3f;
    public float lerpValue = 10;
    private float targetZoom = 0;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        targetZoom -= Input.GetAxisRaw("Zoom") * inputSizeCoefficient;
        targetZoom = Mathf.Clamp(targetZoom, minimumZoom, maximumZoom);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, lerpValue * Time.deltaTime);
    }
}
