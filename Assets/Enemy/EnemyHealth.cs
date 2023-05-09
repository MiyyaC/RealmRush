using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoint = 5;
    [Tooltip("Adds amount to maxHitPoints when enemy dies.")]
    [SerializeField] int difficultyRamp = 1;
    int currentHitPoint = 0;

    Enemy enemy;

    // Start is called before the first frame update
    void OnEnable()
    {
        currentHitPoint = maxHitPoint;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        Debug.Log("test");
        currentHitPoint--;
        if(currentHitPoint <= 0)
        {
            gameObject.SetActive(false);
            maxHitPoint += difficultyRamp;
            enemy.RewardGold();
        }
    }
}
