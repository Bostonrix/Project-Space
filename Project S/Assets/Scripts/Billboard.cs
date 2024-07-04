using UnityEngine;

public class Billboard : MonoBehaviour
{
    public float desiredScale = 1.0f; // Adjust this value to set the desired screen space scale

    void Update()
    {
        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            // Calculate the direction to the camera
            Vector3 lookAtPosition = transform.position + mainCamera.transform.rotation * Vector3.forward;

            // Make the object face the camera
            transform.LookAt(lookAtPosition, mainCamera.transform.rotation * Vector3.up);

            // Calculate the distance from the camera
            float distance = Vector3.Distance(transform.position, mainCamera.transform.position);

            // Calculate the scale based on distance
            float scale = desiredScale * distance;

            // Set the scale
            transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}