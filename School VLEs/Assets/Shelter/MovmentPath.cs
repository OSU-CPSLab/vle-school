using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovmentPath : MonoBehaviour
{
    [System.Serializable]
    public class MovementPoint {
        public Transform transform;
        public bool stoppingPoint = false;
        public bool playerPoint = false;
    }

    //[SerializeField] private MovementPoint myPoint;

    public MovementPoint[] movmentPoints;

    private void OnDrawGizmos()
    {
        for (int i = 0; i < movmentPoints.Length; i++)
        {
            if (movmentPoints[i].stoppingPoint)
                Gizmos.color = Color.red;
            else
                Gizmos.color = Color.green;

            if (i + 1 < movmentPoints.Length && movmentPoints[i] != null)
            {
                Gizmos.DrawLine(movmentPoints[i].transform.position, movmentPoints[i + 1].transform.position);
            }
        }
    }
}
