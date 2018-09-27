using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour 
{
	#region Variables
	public float health = 50f;

	public void takeDamage(float amount)
	{
		health -= amount;
		if(health <= 0f)
		{
			Die();
		}
	}

	void Die()
	{
		Destroy(gameObject);
	}
	#endregion
}// Main Class
