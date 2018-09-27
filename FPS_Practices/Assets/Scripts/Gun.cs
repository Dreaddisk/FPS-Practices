using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour 
{
	#region variables
	public float damage = 10f;
	public float range = 100f;
	public float fireRate = 15f;
	public float impactForce = 30f;


	public Camera fpsCam;
	public ParticleSystem muzzleFlash;

	private Target _target;
	private float nextTimeToFire = 0f;
	#endregion

	#region UnityFunctions
	void Update()
	{
		if(Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire)
		{
			nextTimeToFire = Time.time + 1f / fireRate;
			Shoot();
		}
	}
	
	#endregion

	void Shoot()
	{
		muzzleFlash.Play();
		RaycastHit hit;
		Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
		if  (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
		{			
			Debug.Log(hit.transform.name);
			Debug.DrawRay(transform.position, forward, Color.red);

			 _target = hit.transform.GetComponent<Target>();

			if(_target != null)
			{
				_target.takeDamage(damage);
			}
		}
	}
}
