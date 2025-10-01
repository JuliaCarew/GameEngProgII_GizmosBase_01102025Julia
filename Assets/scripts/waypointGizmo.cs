using UnityEngine;

public class waypointGizmo : MonoBehaviour
{
    [Range(0f, 100f)] public float range = 15f;
    public string icon = "idle_icon.png";
    public Color spawnColor;

    private void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, icon);

        Gizmos.color = spawnColor;
        Gizmos.DrawSphere(transform.position, range);
    }
}
