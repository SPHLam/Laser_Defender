using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectTileSpeed = 10f;
    [SerializeField] float projectTileLifetime = 5f;
    [SerializeField] float fireRate = 0.25f;

    [Header("AI")]
    [SerializeField] bool useAI;
	[HideInInspector] public bool isFiring;
    Coroutine firingCoroutine;
	// Start is called before the first frame update
	void Start()
    {
		if (useAI)
		{
			isFiring = true;
		}
	}

    // Update is called once per frame
    void Update()
    {
        Fire();
    }
    void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
			firingCoroutine = StartCoroutine(FireContinuously());
		}
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while(true)
        {
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * projectTileSpeed;
            }
            Destroy(instance, projectTileLifetime);
            if (!useAI) 
			    yield return new WaitForSeconds(projectTileLifetime);
            else
				yield return new WaitForSeconds(Random.Range(1f, 2f));
		}
	}
}
