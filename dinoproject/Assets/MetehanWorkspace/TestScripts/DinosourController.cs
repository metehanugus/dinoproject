using UnityEngine;
using UnityEngine.AI;

public class DinosaurController : MonoBehaviour
{
    public Dinosaur dinosaurData;
    private NavMeshAgent agent;
    private GameObject player;
    public float detectionRadius = 25f; // İnsan algılama radiusu
    private bool isAttackingHuman = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = dinosaurData.speed;
        player = GameObject.FindGameObjectWithTag("Player"); // Oyuncunun konumunu al
        agent.SetDestination(player.transform.position); // Başlangıçta oyuncuya doğru hareket et
    }

    private void Update()
    {
        if (!isAttackingHuman) // Eğer bir insanla meşgul değilse, oyuncuya doğru ilerle
        {
            //Debug.Log("Dinozor playere ilerliyor");
            agent.SetDestination(player.transform.position);
        }

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Human"))
            {
                // İnsan NPC'yi algıla ve ona doğru hareket et
                agent.SetDestination(hitCollider.transform.position);
                //Debug.Log("Dinozor bir insana ilerliyor");
                isAttackingHuman = true;

                if (Vector3.Distance(transform.position, hitCollider.transform.position) <= dinosaurData.attackRange)
                {
                    // İnsan NPC'yi öldür
                    Destroy(hitCollider.gameObject);
                    //Debug.Log("Dinozor bir insanı öldürdü!");
                    isAttackingHuman = false; // İnsan saldırısı bittikten sonra bu flag'i sıfırla
                }
                break; // En yakın insanı hedef al ve döngüyü sonlandır
            }
        }
    }
}
