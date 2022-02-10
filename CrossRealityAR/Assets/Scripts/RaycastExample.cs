using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation; // We use this to access ARFoundation related classes and structs

// This script demonstrates how to use AR Raycasting. Place it on the AR Camera object
public class RaycastExample : MonoBehaviour
{
    [SerializeField] private ARRaycastManager aRRaycastManager; // Reference to the AR Raycast Manager component we use to cast rays into the real world
    [SerializeField] private Text uiText; // Text to display the distance from the device to the raycast hit position
    [SerializeField] private GameObject markerObject; // GameObject for visualizing the raycast hit position

    // Update is called once per frame
    void Update()
    {
        CastRay(); // Cast rays on each update
    }

    public void CastRay()
    {
        Ray ray = new Ray(transform.position, transform.forward); // A ray that starts at the cameras world position and moves along the forward vector of the camera
        List<ARRaycastHit> hits = new List<ARRaycastHit>(); // List of trackables hit by the raycast
        
        // Only run this if the raycast hit something
        if (aRRaycastManager.Raycast(ray, hits, UnityEngine.XR.ARSubsystems.TrackableType.AllTypes))
        {
            uiText.text = hits[0].sessionRelativeDistance.ToString(); // Update the UI text field to display the distance between the device and the point where the ray hit
            markerObject.transform.position = hits[0].pose.position; // Set the markers position to the point where the ray hit
            markerObject.SetActive(true); // Make sure the marker is visible
        }
        // If we didn't hit anything, update the text and hide the marker 
        else
        {
            uiText.text = "Nothing hit";
            markerObject.SetActive(false);
        }
    }
}
