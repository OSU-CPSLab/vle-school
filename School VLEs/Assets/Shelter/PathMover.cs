using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMover : MonoBehaviour
{
    public MovmentPath path;
    public float speed = 1.0f;

    public Transform hips;

    private int moveIndex = 1;
    private float distFromGround;
    private bool isMoving;
    private bool isRotating = false;

    private int stop = 0;

    [SerializeField] private GameObject player;
    
    private void Start()
    {
        distFromGround = Mathf.Abs(path.movmentPoints[0].transform.position.y - transform.position.y);
        transform.position = path.movmentPoints[0].transform.position + Vector3.up * distFromGround;
    }

    private void Update()
    {
        GetComponent<Animator>().SetBool("IsWalking", isMoving);

        if (isMoving)
        {
            MoveToNextPoint();
            RotateTowardsTarget(path.movmentPoints[moveIndex].transform.position);
        }

        if (moveIndex - 1 >= 0 && path.movmentPoints[moveIndex - 1].playerPoint && !isMoving) 
        {
            RotateTowardsTarget(player.transform.position);
        }

        Vector3 destination = path.movmentPoints[moveIndex].transform.position;
        destination.y = transform.position.y;

        if (Vector3.Distance(transform.position, path.movmentPoints[moveIndex].transform.position + Vector3.up * distFromGround) < 0.1f)
        {
            isMoving = false;
            moveIndex++;


            if (!path.movmentPoints[moveIndex - 1].stoppingPoint)
                BeginMovement();
            else
            {
                stop++;
                GetComponent<Animator>().SetInteger("CurrentZone", stop);
            }
        }
    }

    private void MoveToNextPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, path.movmentPoints[moveIndex].transform.position + Vector3.up * distFromGround, speed * Time.deltaTime);
    }

    public void RotateTowardsTarget(Vector3 target)
    {
        Vector3 dir = target - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 10.0f).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    public void TurnAround()
    {
        RotateTowardsTarget(-transform.forward);
    }

    public void BeginMovement()
    {
        isMoving = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + hips.forward);
    }
}
