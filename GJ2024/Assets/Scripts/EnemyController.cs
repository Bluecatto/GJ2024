using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent Nav;
    public GameObject target;
    private Rigidbody targetrb;
    private float AttackCooldownTimer;

    [Header("Enemy Settings")]
    [SerializeField] private float AttackCooldown;
    [SerializeField] private float AttackDamage;
    [SerializeField] private float healthPoints;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(this.GetComponent<Collider>(), target.GetComponent<Collider>());
        targetrb = target.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AttackCooldownTimer >= 0f)
        {
            AttackCooldownTimer -= Time.deltaTime;
        }
        else if (Vector3.Distance(target.transform.position, transform.position) <= 10f)
        {
            StartCoroutine(EnemyAttack());
        }
        if (Vector3.Distance(target.transform.position, transform.position) >= 1.25f)
        {
            Nav.SetDestination(target.transform.position);
        }

    }

    public IEnumerator EnemyAttack()
    {
        AttackCooldownTimer = AttackCooldown;
        Lunge();
        yield return new WaitForSeconds(1f);
        if (Vector3.Distance(target.transform.position, transform.position) <= 2.5f)
        {
            Debug.Log($"Enemy {this.name} ({healthPoints} hp) attacks {target.name}");
            targetrb.velocity += Vector3.ClampMagnitude((target.transform.position - transform.position) * 20f, 4f);
        }
    }

    public void Lunge()
    {
        Nav.velocity += Vector3.ClampMagnitude((target.transform.position - transform.position)*6f, 4f);
    }

    public void TakeDamage(float damage)
    {
        healthPoints -= damage;
        if (healthPoints <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
