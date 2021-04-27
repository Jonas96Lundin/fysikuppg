using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sliding : MonoBehaviour
{
	[SerializeField]
	float initialVelocity = 10f;
	[SerializeField]
	float gravitation = -9.82f;
	[SerializeField]
	float friktionsKoeffsient = 1f;
	//[SerializeField]
	//float mass = 1f;

	[SerializeField]
	Text currentPosX;
	[SerializeField]
	Text currentPosY;
	[SerializeField]
	InputField inputVelocity;
	[SerializeField]
	InputField inputFriktionsKoeffsient;

	Vector3 startPos;
	Vector3 velocity;
	float angle = -30f;
	float a, aF, aG;

	//float Fn, Ff;

	private void Start()
	{
		//UI
		inputVelocity.text = initialVelocity.ToString();
		inputFriktionsKoeffsient.text = friktionsKoeffsient.ToString();

		startPos = transform.position;

		velocity.x = initialVelocity * Mathf.Cos(angle * Mathf.PI / 180f);
		velocity.y = initialVelocity * Mathf.Sin(angle * Mathf.PI / 180f);

		//Fn = mass * gravitation * Mathf.Cos(angle * Mathf.PI / 180f);
		//Ff = friktionsKoeffsient * Fn;
		//a = Ff / mass;
		aF = friktionsKoeffsient * gravitation * Mathf.Cos(angle * Mathf.PI / 180f);
		aG = gravitation * Mathf.Sin(angle * Mathf.PI / 180f);
		a = aF +  aG;
	}

	private void Update()
	{
		if (velocity.x >= 0)
		{
			velocity.x += a * Mathf.Cos(angle * Mathf.PI / 180f) * Time.deltaTime;
			velocity.y += a * Mathf.Sin(angle * Mathf.PI / 180f) * Time.deltaTime;
			Move();

			currentPosX.text = "Current x position: " + Mathf.Round(transform.position.x * 100f) / 100f;
			currentPosY.text = "Current y position: " + Mathf.Round(transform.position.y * 100f) / 100f;
		}
		
		if (Input.GetKeyDown(KeyCode.Space))
		{
			initialVelocity = float.Parse(inputVelocity.text);
			friktionsKoeffsient = float.Parse(inputFriktionsKoeffsient.text);

			transform.position = startPos;

			velocity.x = initialVelocity * Mathf.Cos(angle * Mathf.PI / 180f);
			velocity.y = initialVelocity * Mathf.Sin(angle * Mathf.PI / 180f);

			aF = friktionsKoeffsient * gravitation * Mathf.Cos(angle * Mathf.PI / 180f);
			aG = gravitation * Mathf.Sin(angle * Mathf.PI / 180f);
			a = aF + aG;
		}
	}


	private void Move()
	{
		transform.position += velocity * Time.deltaTime;
	}
}
