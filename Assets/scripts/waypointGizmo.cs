using UnityEditor;
using UnityEngine;

public class waypointGizmo : MonoBehaviour
{
    [Range(0f, 100f)] public float range = 15f;
    public string icon = "idle_icon.png";
    public Color spawnColor;

    // new
    public Transform[] connectedWaypoints;

    private void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, icon);

        Gizmos.color = spawnColor;
        Gizmos.DrawSphere(transform.position, range);

        foreach(Transform waypoint in connectedWaypoints)
        {
            var thickness = 3;

            Handles.DrawBezier(transform.position, waypoint.position, transform.position, waypoint.position, Color.magenta, null, thickness);
        }
    }
}
// draw from one waypoint to the next