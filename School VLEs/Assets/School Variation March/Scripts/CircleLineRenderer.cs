using UnityEngine;

public static class CircleLineRenderer
{
    public static void DrawCircle(this GameObject container, float radius, float lineWidth, GameObject sign, Material color)
    {
        var segments = 360;
        var line = container.AddComponent<LineRenderer>();
        line.material = color;
        line.useWorldSpace = false;
        line.startWidth = lineWidth;
        line.endWidth = lineWidth;
        line.positionCount = segments + 1;

        var pointCount = segments + 1;
        var points = new Vector3[pointCount];

        Vector3 localPosition = new Vector3(sign.transform.position.x, sign.transform.position.y, sign.transform.position.z);

        for (int i = 0; i < pointCount; i++)
        {
            var rad = Mathf.Deg2Rad * (i * 360f / segments);
            points[i] = new Vector3(localPosition.x + Mathf.Sin(rad) * radius, localPosition.y, localPosition.z + Mathf.Cos(rad) * radius);
        }

        line.SetPositions(points);
    }
}