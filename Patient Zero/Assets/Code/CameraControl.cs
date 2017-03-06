using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraControl : MonoBehaviour {
    public Transform Target;

    public float Smoothing = 5f;


    private Vector3 offsetFromTarget;

	internal void Start () {
        offsetFromTarget = transform.position - Target.position;
	}

    private void ZoomOut(){
        if (Camera.main.orthographicSize < 52)
        {
            Camera.main.orthographicSize++;
        }
    }

    private void ZoomIn()
    {
        if (Camera.main.orthographicSize > 8)
        {
            Camera.main.orthographicSize--;
        }
    }

    internal void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Target.position + offsetFromTarget, Smoothing*Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ZoomOut();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ZoomIn();
        }
    }
}
