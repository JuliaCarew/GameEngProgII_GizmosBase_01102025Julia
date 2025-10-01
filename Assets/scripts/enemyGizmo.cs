using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class enemyGizmo : MonoBehaviour
{
    public string alertIcon = "alert_icon.png";
    public Color enemyGizmoColor;
    [Range(0f, 100f)]  public float radius = 10f;

    public Transform player;

    [Header("Toggle Gizmos")]
    public bool drawName = true;
    public bool drawIcon = true;
    public bool drawRadius = true;
    public bool drawDistToPlayer = true;


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = enemyGizmoColor;

        // draw name label
        if (drawName) UnityEditor.Handles.Label(transform.position + Vector3.up * 1.5f, $"{gameObject.name}");

        // draw icon
        if (drawIcon) Gizmos.DrawIcon(transform.position + Vector3.up * 2f, alertIcon, true);

        if (drawRadius)  Gizmos.DrawWireSphere(transform.position, radius);

        if (drawDistToPlayer)
        {
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
}
