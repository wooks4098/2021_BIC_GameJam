using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerMove : MonoBehaviour
{
    NavMeshAgent Agent;

    [SerializeField] Transform[] MovePos;
    public int MoveNum;
    Animator ani;
    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
        SetMove();
    }

    private void Update()
    {
        if (Agent.hasPath)
        {
            //에이전트의 이동방향
            Vector3 direction = Agent.desiredVelocity;
            //회전각도(쿼터니언)산출
            Quaternion targetangle = Quaternion.LookRotation(direction);
            //선형보간 함수를 이용해 부드러운 회전
            ani.transform.rotation = Quaternion.Slerp(ani.transform.rotation, targetangle, Time.deltaTime * 8.0f);
        }
        if (Agent.velocity.sqrMagnitude >= 0.2f * 0.2f && Agent.remainingDistance <= 0.5f)
        {
            SetMove();
        }
    }

    public void ChangeMovePos(Transform[] Pos)
    {
        MovePos = Pos;
        MoveNum = 0;
    }

    public void SetMove()
    {

        Agent.SetDestination(MovePos[MoveNum].position);
        MoveNum++;
        if (MoveNum >= MovePos.Length)
            MoveNum = 0;
    }

    const float waypointGizomRadious = 0.3f;

    //private void OnDrawGizmosSelected()
    //{
    //    if (MovePos.Length == 0)
    //        return;
    //    for (int i = 0; i < MovePos.Length; i++)
    //    {
    //        int j = GetNextIndex(i);
    //        Gizmos.DrawSphere(GetWaypoint(i), waypointGizomRadious);
    //        Gizmos.DrawLine(GetWaypoint(i), GetWaypoint(j));
    //    }
    //}

    private void OnDrawGizmos()
    {
        for (int i = 0; i < MovePos.Length; i++)
        {
            if (MovePos.Length == 0)
                return;
            int j = GetNextIndex(i);
            Gizmos.DrawSphere(GetWaypoint(i), waypointGizomRadious);
            Gizmos.DrawLine(GetWaypoint(i), GetWaypoint(j));
        }
    }

    public int GetNextIndex(int i)
    {
        if (i + 1 >= MovePos.Length)
            return 0;
        return i + 1;
    }

    public Vector3 GetWaypoint(int i)
    {
        return MovePos[i].position;
    }
}
