using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour 
	{

	public float speed;
	public float tilt;
	public Boundary boundary;

	private Rigidbody rb; //lisäsin tämän

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;
	private AudioSource audioSource; //lisäsin tämän 14.11. audio kohdassa


	void Update ()
	{
		if (Input.GetButton ("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			//GameObject clone = 
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation); // as GameObject;
			//audio.Play ();

			audioSource = GetComponent <AudioSource> (); //lisäsin tämän 14.11. audio kohdassa
			audioSource.Play(0); //lisäsin tämän 14.11. audio kohdassa
			Debug.Log ("started"); //lisäsin tämän 14.11. audio kohdassa

		}
	}



	void Start() //lisäsin tämän myös
	{
		rb = GetComponent<Rigidbody> ();
	
	}

		void FixedUpdate ()
		{
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.velocity = movement * speed; //muutin rigidbody > rb

		rb.position = new Vector3 
		(
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
		);

		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);

		}

	}
