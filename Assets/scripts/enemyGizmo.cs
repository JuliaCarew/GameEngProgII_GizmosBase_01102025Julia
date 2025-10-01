using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class enemyGizmo : MonoBehaviour
{
    public string alertIcon = "alert_icon.png";
    public Color enemyGizmoColor;
    [Range(0f, 100f)]  public float radius = 10f;

    public Transform player;

    private void OnDrawGizmosSelected()
    {
        // draw name label
        UnityEditor.Handles.Label(transform.position + Vector3.up * 1.5f, $"{gameObject.name}");

        // draw icon
        Gizmos.color = enemyGizmoColor;
        Gizmos.DrawIcon(transform.position + Vector3.up * 2f, alertIcon, true);

        Gizmos.DrawWireSphere(transform.position, radius);

        // midpoint to player
        Vector3 midpoint = (transform.position + player.position) / 2f;

        // display distance
        float distance = Vector3.Distance(transform.position, player.position);

        // draw line to player
        Gizmos.DrawLine(transform.position, player.position);

        // display red text of distance to player
        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.red;
        UnityEditor.Handles.Label(midpoint, $"Distance: {distance:F2}", style);
    }
}
