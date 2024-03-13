using UnityEngine;
using UnityEngine.AI;

public class HumanController : MonoBehaviour
{
    private NavMeshAgent agent;
    public float panicDistance = 1f; // Dinozorları algılama mesafesi

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        GameObject[] dinosaurs = GameObject.FindGameObjectsWithTag("Dinosaur");
        foreach (var dino in dinosaurs)
        {
            if (Vector3.Distance(transform.position, dino.transform.position) <= panicDistance)
            {
                Debug.Log("Dinozordan kaç dinodan kaç!");
                Vector3 fleeDirection = transform.position - dino.transform.position;
                Vector3 newGoal = transform.position + fleeDirection.normalized * panicDistance;
                agent.SetDestination(newGoal);
                break; // En yakın dinozordan kaç
            }
        }
    }
}
