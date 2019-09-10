using UnityEngine;
using UnityEngine.AI;


public class CharacterMovementNavmesh : MonoBehaviour
{
    public NavMeshAgent agent;

    public GameObject[] wayPoints;
    public GameObject currentPlayer;


    private GameObject nextWaypoint;
    private string difficulty = "easy";

    void Start()
    {
        nextWaypoint = wayPoints[Random.Range(0, wayPoints.Length)];
        agent.SetDestination(nextWaypoint.transform.position);
    }

    void Update()
    {

        if(agent.remainingDistance == 0f)
        {
            int random = Random.Range(0, 9);
            bool goAfterPlayer = false;
            switch(difficulty)
            {
                case "easy":
                    if (random >= 0 && random <= 1)
                        goAfterPlayer = true;
                    else
                        goAfterPlayer = false;
                    break;

                case "medium":
                    if (random >= 0 && random <= 2)
                        goAfterPlayer = true;
                    else
                        goAfterPlayer = false;
                    break;

                case "hard":
                    if (random >= 0 && random <= 3)
                        goAfterPlayer = true;
                    else
                        goAfterPlayer = false;
                    break;
            }

            if (goAfterPlayer == false)
            {
                nextWaypoint = wayPoints[Random.Range(0, wayPoints.Length)];
            }
            else
            {
                nextWaypoint = currentPlayer;
            }

            agent.SetDestination(nextWaypoint.transform.position);
        }

        if(Vector3.Distance(this.transform.position, currentPlayer.transform.position) < 4f)
        {
            // Follow the player
            agent.SetDestination(currentPlayer.transform.position);
        }
    }

    private void FixedUpdate()
    {
        CheckDoors();
    }

    void CheckDoors()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, 1f);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].tag == "OpenItem")
            {
                OpenObject openObject = hitColliders[i].GetComponent<OpenObject>();
                if(openObject.type == 0 && openObject.isOpen == false)
                {
                    openObject.ChangeState();
                }
                i = hitColliders.Length;
            }
            i++;
        }
    }
}
