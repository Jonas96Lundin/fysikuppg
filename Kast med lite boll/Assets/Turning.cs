using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turning : MonoBehaviour
{
	[SerializeField]
	float velocity = 10f;
	[SerializeField]
	float gravitation = 9.82f;
	[SerializeField]
	float friktionsKoeffsient = 1f;

	[SerializeField]
	Text currentPosX;
	[SerializeField]
	Text currentPosY;
	[SerializeField]
	InputField inputVelocity;
	[SerializeField]
	InputField inputFriktionsKoeffsient;
	[SerializeField]
	Text collision;
	[SerializeField]
	Dropdown radius;

	Vector3 startPos;
	float r;
	bool turn;

	private void Start()
	{
		inputVelocity.text = velocity.ToString();
		inputFriktionsKoeffsient.text = friktionsKoeffsient.ToString();

		startPos = new Vector3(r, 0, -50);
		r = 50;
	}

	private void Update()
	{
		if(transform.position.z >= 0 || turn)
		{
			turn = true;
			//Ff = Fc
			//friktionskoeffsient * mass * gravitation = mass * Mathf.Pow(velocity, 2) / r
			if (velocity < Mathf.Sqrt(friktionsKoeffsient * gravitation * r))
			{
				Turn();
			}
			else
			{
				collision.gameObject.SetActive(true);
				Debug.LogWarning("Bilen kommer att glida");
			}
		}
		else
		{
			Move();
		}



		if (Input.GetKeyDown(KeyCode.Space))
		{
			collision.gameObject.SetActive(false);

			velocity = float.Parse(inputVelocity.text);
			friktionsKoeffsient = float.Parse(inputFriktionsKoeffsient.text);

			startPos = new Vector3(r, 0, -50);
			transform.position = startPos;
			transform.rotation = Quaternion.Euler(Vector3.zero);
			turn = false;

		}
	}


	private void Move()
	{
		transform.position += transform.forward * velocity * Time.deltaTime;
	}

	private void Turn()
	{
		transform.RotateAround(Vector3.zero, Vector3.up, -velocity * Time.deltaTime);
	}

	public void ChangeRadius()
	{
		r = float.Parse(radius.options[radius.value].text);
	}
}
