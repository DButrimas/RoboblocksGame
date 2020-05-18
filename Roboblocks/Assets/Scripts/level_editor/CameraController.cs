using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Camera;
    public Transform Parent;
    private Vector3 LocalRotation;
    private float CameraDistance = 10f;
    public float MouseSensitivity = 4f;
    public float ScrollS = 2f;
    public float Orbit = 10f;
    public float ScrollD = 6f;
    public float moveSpeed;

    void Start()
    {

    }

    void Update()
    {

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && SelectedStatic.selected == null)
        {
            Parent.transform.position += Vector3.forward * moveSpeed;
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift) && SelectedStatic.selected == null)
        {
            Parent.transform.position += Vector3.back * moveSpeed;
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift) && SelectedStatic.selected == null)
        {
            Parent.transform.position += Vector3.left * moveSpeed;
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift) && SelectedStatic.selected == null)
        {
            Parent.transform.position += Vector3.right * moveSpeed;
        }
        if (Input.GetMouseButton(1))
        {
            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                LocalRotation.x += Input.GetAxis("Mouse X") * MouseSensitivity;
                LocalRotation.y += Input.GetAxis("Mouse Y") * MouseSensitivity;

                if (LocalRotation.y < 0f)
                {
                    LocalRotation.y = 0f;
                }
                else if (LocalRotation.y > 90f)
                {
                    LocalRotation.y = 90f;
                }
            }
            if (Input.GetAxis("Mouse ScrollWheel") != 0f)
            {
                float ScrollAmount = Input.GetAxis("Mouse ScrollWheel") * ScrollS;

                ScrollAmount *= (this.CameraDistance * 0.3f);

                this.CameraDistance += ScrollAmount * -1f;

                this.CameraDistance = Mathf.Clamp(this.CameraDistance, 1.5f, 100f);
            }


            Quaternion QT = Quaternion.Euler(LocalRotation.y, LocalRotation.x, 0);
            this.Parent.rotation = Quaternion.Lerp(this.Parent.rotation, QT, Time.deltaTime * ScrollD);

            if (this.Camera.localPosition.z != this.CameraDistance * -1f)
            {
                this.Camera.localPosition = new Vector3(0f, 0f, Mathf.Lerp(this.Camera.localPosition.z, this.CameraDistance * -1f, Time.deltaTime * ScrollD));
            }
        }
    }
    void FixedUpdate()
    {

    }
}