using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rullning : MonoBehaviour
{
	[SerializeField]
	float initialPositionX = 0f;
	[SerializeField]
	float initialPositionY = 0f;

	[SerializeField]
	float initialAngle = 100f;
	[SerializeField]
	float initialVelocity = 10f;

	[SerializeField]
	float gravity = 9.82f;
	float a, aF, aG;

	float angle, r, angleSpeed;

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

	[SerializeField]
	Text currentAngleSpeed;
	[SerializeField]
	Text currentSpeed;

	Vector3 u, w;

	private Vector3 velocity;
	private float speed = 0;
	//private float hight;

	private void Start()
	{
		inputPosX.text = initialPositionX.ToString();
		inputPosY.text = initialPositionY.ToString();
		inputVelocity.text = initialVelocity.ToString();
		inputAngle.text = initialAngle.ToString();

		r = gameObject.GetComponent<SphereCollider>().radius;

		transform.position = new Vector3(initialPositionX, initialPositionY, 0);
		velocity.x = Mathf.Cos(initialAngle * Mathf.PI / 180) * initialVelocity;
		velocity.y = Mathf.Sin(initialAngle * Mathf.PI / 180) * initialVelocity;
		//currentSpeed = initialVelocity;
		//angle = initialAngle;
		speed = initialVelocity;
		//hight = 0;
		angleSpeed = initialVelocity / r;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			transform.position = new Vector3(float.Parse(inputPosX.text), float.Parse(inputPosY.text), 0);
			velocity.x = Mathf.Cos(float.Parse(inputAngle.text) * Mathf.PI / 180) * float.Parse(inputVelocity.text);
			velocity.y = Mathf.Sin(float.Parse(inputAngle.text) * Mathf.PI / 180) * float.Parse(inputVelocity.text);
			//currentSpeed = float.Parse(inputVelocity.text);
			speed = float.Parse(inputVelocity.text);
			//hight = 0;
			angleSpeed = initialVelocity / r;
		}

		if (transform.position.x > 55)
			angle = 15;
		else if (transform.position.x > 32)
			angle = 0;
		else if (transform.position.x > 9)
			angle = -20;
		else
			angle = 0;


		//float Fg = mass * -gravity;
		//float Fn = (float)(Fg * Mathf.Cos(angle));
		//float Fgx = (float)(Fg * Mathf.Sin(angle));
		//float I = 2 / 3 * mass * Mathf.Pow(r, 2);
		//float accelration = (Fgx / I);

		//Fgx = mass * -gravity * Mathf.Sin(angle);
		//accelration = mass * -gravity * Matf.Sin(angle) / (2 / 3 * mass * Matf.Pow(r, 2));

		float accelration = -gravity * Mathf.Sin(angle * Mathf.PI / 180) / /*(5f / 3f)*/(2f / 3f * Mathf.Pow(r, 2));

		speed += accelration * Time.deltaTime;
		angleSpeed += accelration / r * Time.deltaTime;
		velocity.x = Mathf.Cos(angle * Mathf.PI / 180) * speed;
		velocity.y = Mathf.Sin(angle * Mathf.PI / 180) * speed;
	}

	private void FixedUpdate()
	{
		Move();
		transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z - angleSpeed));

		currentPosX.text = "Current x position: " + Mathf.Round(transform.position.x * 100f) / 100f;
		currentPosY.text = "Current y position: " + Mathf.Round(transform.position.y * 100f) / 100f;
		currentAngleSpeed.text = "Current Angle Speed: " + Mathf.Round(angleSpeed * 100f) / 100f;
		currentSpeed.text = "Current Speed: " + Mathf.Round(speed * 100f) / 100f;
	}

	private void Move()
	{
		transform.position += velocity * Time.fixedDeltaTime;
	}
}
