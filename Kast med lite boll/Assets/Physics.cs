using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Physics : MonoBehaviour
{
	[SerializeField]
	float initialPositionX = 0f;
	[SerializeField]
	float initialPositionY = 0f;

	[SerializeField]
	float initialAngle = 100f;
	[SerializeField]
	float initialVelocity = 100f;

	float initialSpeedX, initialSpeedY;

	[SerializeField]
	float gravitation = -9.82f;


	[SerializeField]
	InputField inputPosX;
	[SerializeField]
	InputField inputPosY;
	[SerializeField]
	InputField inputVelocity;
	[SerializeField]
	InputField inputAngle;

	[SerializeField]
	Text currentPosX;
	[SerializeField]
	Text currentPosY;


	Vector3 velocity;
	float studs;

	private void Start()
	{
		inputPosX.text = initialPositionX.ToString();
		inputPosY.text = initialPositionY.ToString();
		inputVelocity.text = initialVelocity.ToString();
		inputAngle.text = initialAngle.ToString();

		transform.position = new Vector3(initialPositionX, initialPositionY, 0);

		velocity.x = Mathf.Cos(initialAngle * Mathf.PI / 180) * initialVelocity;
		velocity.y = Mathf.Sin(initialAngle * Mathf.PI / 180) * initialVelocity;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			transform.position = new Vector3(float.Parse(inputPosX.text), float.Parse(inputPosY.text), 0);
			velocity.x = Mathf.Cos(float.Parse(inputAngle.text) * Mathf.PI / 180) * float.Parse(inputVelocity.text);
			velocity.y = Mathf.Sin(float.Parse(inputAngle.text) * Mathf.PI / 180) * float.Parse(inputVelocity.text);
		}

		velocity.y += gravitation * Time.deltaTime;
		Move();

		currentPosX.text = "Current x position: " + Mathf.Round(transform.position.x * 100f) / 100f;
		currentPosY.text = "Current y position: " + Mathf.Round(transform.position.y * 100f) / 100f;
	}


	private void Move()
	{
		transform.position += velocity * Time.deltaTime;
	}


	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Roof")
		{
			velocity.y = other.gameObject.GetComponent<studsYta>().studskoefficient * -velocity.y;
		}
		else if (other.tag == "Wall")
		{
			velocity.x = other.gameObject.GetComponent<studsYta>().studskoefficient * -velocity.x;
		}
		else if (other.tag == "Floor")
		{
			velocity.y = other.gameObject.GetComponent<studsYta>().studskoefficient * -velocity.y;
			gravitation = 0f;
		}
		
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Floor")
		{
			gravitation = -9.82f;
		}
	}
}
