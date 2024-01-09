using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
	[SerializeField] GameObject projectilePrefab;
	[SerializeField] float projectileSpeed = 10f;
	[SerializeField] float projectileLifetime = 5f;
	[SerializeField] float firingRate = 0.2f;

	bool isFiring;

	Coroutine firingCoroutine;

    public bool GetIsFiring()
    {
    	return isFiring;
    }

    public void StartFiring()
    {
    	isFiring = true;
    }

    public void StopFiring()
    {
    	isFiring = false;
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
    	if(isFiring && firingCoroutine == null)
    	{
    		firingCoroutine = StartCoroutine(FireContinuously());
    	}
    	else if(!isFiring && firingCoroutine != null)
    	{
    		StopCoroutine(firingCoroutine);
    		firingCoroutine = null;
    	}
    }

    IEnumerator FireContinuously()
    {
    	while(true)
    	{
    		GameObject instance = Instantiate(projectilePrefab,
    										 transform.position,
    										 Quaternion.identity);

    		Rigidbody2D myRigidbody = instance.GetComponent<Rigidbody2D>();
    		if(myRigidbody != null)
    		{
    			myRigidbody.velocity = transform.up * projectileSpeed;
    		}

    		Destroy(instance, projectileLifetime);
    		yield return new WaitForSeconds(firingRate);
    	}
    }
}
