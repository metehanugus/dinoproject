using UnityEngine;

[CreateAssetMenu(fileName = "New Dinosaur", menuName = "Dinosaur")]
public class Dinosaur : ScriptableObject
{
    public float health = 100f;
    public float speed = 5f;
    public float attackPower = 10f;
    public float attackRange = 1f;
    public float visionRange = 10f;

    // Bu alanı kullanarak, özellikle AI davranışları için planlarınızı yapabilirsiniz
    // Örneğin: saldırı türleri, özel yetenekler vs.
}
