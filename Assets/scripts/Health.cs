using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int HP = 1;

    public bool IsEnemy = true;

    public void Damage(int damageCount)
    {
        HP -= damageCount;

        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Shot shot = otherCollider.gameObject.GetComponent<Shot>();
        if (shot != null)
        {
            if (shot.IsEnemyShot != IsEnemy)
            {
                Damage(shot.Damage);

                Destroy(shot.gameObject);
            }
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
