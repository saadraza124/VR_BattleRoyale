using UnityEngine;
using System.Collections;
using System.Reflection;
//using UnityEditor.Profiling.Memory.Experimental;

public class shooter : MonoBehaviour
{

	// Reference to projectile prefab to shoot
	[SerializeField] Camera playercamera;
	public GameObject projectile;
	public float power = 10.0f;
	bool canShoot = false;
	bool checkClick = false;
	

	// Reference to AudioClip to play
	public AudioClip shootSFX;

	// Update is called once per frame
	void Update()
	{
		// Detect if fire button is pressed

		if (Input.GetButtonDown("Fire1"))
		{
			
			Ray ray = playercamera.ViewportPointToRay(new Vector3(.5f, .5f, 0));
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				if ((hit.collider.gameObject.tag == "portal") || (hit.collider.gameObject.tag == "launcher"))
				{
					canShoot = false;
				}
				else canShoot = true;
			}
			// if projectile is specified
			if (projectile && canShoot)
			{
				// Instantiante projectile at the camera + 1 meter forward with camera rotation
				GameObject newProjectile = Instantiate(projectile, transform.position + transform.forward, transform.rotation) as GameObject;

				// if the projectile does not have a rigidbody component, add one
				if (!newProjectile.GetComponent<Rigidbody>())
				{
					newProjectile.AddComponent<Rigidbody>();
				}
				// Apply force to the newProjectile's Rigidbody component if it has one
				newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * power, ForceMode.VelocityChange);

				// play sound effect if set
				if (shootSFX)
				{
					if (newProjectile.GetComponent<AudioSource>())
					{
						newProjectile.GetComponent<AudioSource>().PlayOneShot(default);
					}
					else
					AudioSource.PlayClipAtPoint(shootSFX, newProjectile.transform.position);
				}
			}
		}
	}
   
}







