using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int _health = 30;

	private void OnTriggerEnter2D(Collider2D other)
	{
		DamageDealer damageDealer = other.GetComponent<DamageDealer>();
		if (damageDealer != null )
		{
			// Take damage
			TakeDamage(damageDealer.GetDamage());
		}
	}

	private void TakeDamage(int damage)
	{
		_health -= damage;

		if (_health <= 0)
		{
			Destroy(gameObject);
		}
	}
}
