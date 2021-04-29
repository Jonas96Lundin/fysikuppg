using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bouncing : MonoBehaviour
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
	//[SerializeField]
	//InputField inputFriktionsKoeffsient;

	[SerializeField]
	Text currentVelX;
	[SerializeField]
	Text currentVelY;

	Vector3 startPos;
	Vector3 velocity;
	float angle = -30f;
	float a, aF, aG;

	//float Fn, Ff;

	private void Start()
	{
		//UI
		inputVelocity.text = initialVelocity.ToString();
		//inputFriktionsKoeffsient.text = friktionsKoeffsient.ToString();

		startPos = transform.position;

		velocity.x = initialVelocity * Mathf.Cos(angle * Mathf.PI / 180f);
		velocity.y = initialVelocity * Mathf.Sin(angle * Mathf.PI / 180f);


		currentVelX.text = "Current Velocity X: " + (Mathf.Round(velocity.x * 100) / 100).ToString();
		currentVelY.text = "Current Velocity Y: " + (Mathf.Round(velocity.y * 100) / 100).ToString();

		//Fn = mass * gravitation * Mathf.Cos(angle * Mathf.PI / 180f);
		//Ff = friktionsKoeffsient * Fn;
		//a = Ff / mass;
		aF = friktionsKoeffsient * gravitation * Mathf.Cos(angle * Mathf.PI / 180f);
		aG = gravitation * Mathf.Sin(angle * Mathf.PI / 180f);
		a = aF +  aG;
	}

	private void Update()
	{
		//if (onGround)
		//{

		//}
		if (velocity.magnitude >= 0.1)
		{
			velocity.x += a * Mathf.Cos(angle * Mathf.PI / 180f) * Time.deltaTime;
			velocity.y += a * Mathf.Sin(angle * Mathf.PI / 180f) * Time.deltaTime;

			currentPosX.text = "Current x position: " + Mathf.Round(transform.position.x * 100f) / 100f;
			currentPosY.text = "Current y position: " + Mathf.Round(transform.position.y * 100f) / 100f;
		}
		
		if (Input.GetKeyDown(KeyCode.Space))
		{
			initialVelocity = float.Parse(inputVelocity.text);
			//friktionsKoeffsient = float.Parse(inputFriktionsKoeffsient.text);

			transform.position = startPos;

			velocity.x = initialVelocity * Mathf.Cos(angle * Mathf.PI / 180f);
			velocity.y = initialVelocity * Mathf.Sin(angle * Mathf.PI / 180f);

			aF = friktionsKoeffsient * gravitation * Mathf.Cos(angle * Mathf.PI / 180f);
			aG = gravitation * Mathf.Sin(angle * Mathf.PI / 180f);
			a = aF + aG;
		}
	}


	private void FixedUpdate()
	{
		Move();
	}


	private void Move()
	{
		transform.position += velocity * Time.fixedDeltaTime;
	}


}



























//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class Physics : MonoBehaviour
//{
//	[SerializeField]
//	float initialPositionX = 0f;
//	[SerializeField]
//	float initialPositionY = 0f;

//	[SerializeField]
//	float initialAngle = 100f;
//	[SerializeField]
//	float initialVelocity = 100f;

//	float initialSpeedX, initialSpeedY;

//	[SerializeField]
//	float gravitation = -9.82f;


//	[SerializeField]
//	InputField inputPosX;
//	[SerializeField]
//	InputField inputPosY;
//	[SerializeField]
//	InputField inputVelocity;
//	[SerializeField]
//	InputField inputAngle;

//	[SerializeField]
//	Text currentPosX;
//	[SerializeField]
//	Text currentPosY;

//	[SerializeField]
//	Text currentVelX;
//	[SerializeField]
//	Text currentVelY;

//	public bool onGround = false;


//	Vector3 velocity;
//	float studs, timeSinceLastBounce = float.MaxValue;

//	private void Start()
//	{
//		inputPosX.text = initialPositionX.ToString();
//		inputPosY.text = initialPositionY.ToString();
//		inputVelocity.text = initialVelocity.ToString();
//		inputAngle.text = initialAngle.ToString();

//		transform.position = new Vector3(initialPositionX, initialPositionY, 0);

//		velocity.x = Mathf.Cos(initialAngle * Mathf.PI / 180) * initialVelocity;
//		velocity.y = Mathf.Sin(initialAngle * Mathf.PI / 180) * initialVelocity;

//		currentVelX.text = "Current Velocity X: " + (Mathf.Round(velocity.x * 100) / 100).ToString();
//		currentVelY.text = "Current Velocity Y: " + (Mathf.Round(velocity.y * 100) / 100).ToString();

//	}

//	private void Update()
//	{
//		if (Input.GetKeyDown(KeyCode.Space))
//		{
//			//velocity = Vector3.zero;
//			gravitation = -9.82f;
//			timeSinceLastBounce = float.MaxValue;
//			transform.position = new Vector3(float.Parse(inputPosX.text), float.Parse(inputPosY.text), 0);
//			velocity.x = Mathf.Cos(float.Parse(inputAngle.text) * Mathf.PI / 180) * float.Parse(inputVelocity.text);
//			velocity.y = Mathf.Sin(float.Parse(inputAngle.text) * Mathf.PI / 180) * float.Parse(inputVelocity.text);
//			onGround = false;
//			currentVelX.text = "Current Velocity X: " + (Mathf.Round(velocity.x * 100) / 100).ToString();
//			currentVelY.text = "Current Velocity Y: " + (Mathf.Round(velocity.y * 100) / 100).ToString();
//			onGround = false;
//		}

//		//if (!onGround)
//		//{
//		//          velocity.y += gravitation * Time.deltaTime;
//		//      }
//		velocity.y += gravitation * Time.deltaTime;


//		currentPosX.text = "Current x position: " + Mathf.Round(transform.position.x * 100f) / 100f;
//		currentPosY.text = "Current y position: " + Mathf.Round(transform.position.y * 100f) / 100f;

//		currentVelX.text = "Current Velocity X: " + (Mathf.Round(velocity.x * 100) / 100).ToString();
//		currentVelY.text = "Current Velocity Y: " + (Mathf.Round(velocity.y * 100) / 100).ToString();

//		Debug.Log(" Gravitation: " + gravitation);

//		//if (gravitation != 0)
//		//{
//		//    timeSinceLastBounce += Time.deltaTime;

//		//}
//	}

//	private void FixedUpdate()
//	{
//		Move();
//	}


//	private void Move()
//	{
//		transform.position += velocity * Time.fixedDeltaTime;
//	}

//	private void OnCollisionEnter(Collision collision)
//	{
//		//Vector3 u = Vector3.Dot(velocity, collision.GetContact(0).normal)/* / Vector3.Dot(collision.GetContact(0).normal, collision.GetContact(0).normal)*/ * collision.GetContact(0).normal;
//		//Vector3 w = velocity - u;
//		//velocity = 1f * w - collision.gameObject.GetComponent<studsYta>().studskoefficient * u;


//		////velocity = collision.gameObject.GetComponent<studsYta>().studskoefficient * Vector3.Reflect(velocity, Vector3.Normalize(collision.GetContact(0).normal
//		//Vector3 absVec = new Vector3(Mathf.Abs(collision.GetContact(0).normal.x), Mathf.Abs(collision.GetContact(0).normal.y), Mathf.Abs(collision.GetContact(0).normal.z));
//		//Debug.Log(Mathf.Abs(collision.GetContact(0).normal.x));
//		//Debug.Log(collision.gameObject.GetComponent<studsYta>().studskoefficient * Vector3.Dot(Vector3.Normalize(velocity), collision.GetContact(0).normal) * collision.GetContact(0).normal);
//		////velocity = collision.gameObject.GetComponent<studsYta>().studskoefficient * Vector3.Dot(Vector3.Normalize(velocity), collision.GetContact(0).normal) * velocity;
//		////velocity = Vector3.Cross(collision.gameObject.GetComponent<studsYta>().studskoefficient * Vector3.Dot(Vector3.Normalize(velocity), collision.GetContact(0).normal) * collision.GetContact(0).normal , velocity);
//		//velocity = Vector3.Cross(collision.gameObject.GetComponent<studsYta>().studskoefficient * Vector3.Dot(Vector3.Normalize(velocity), collision.GetContact(0).normal) * absVec, velocity);

//		//      if (timeSinceLastBounce < 0.2f/* && Mathf.Abs(velocity.y) < 0.2f*/)
//		//{
//		//	onGround = true;
//		//	//gravitation = 0;
//		//	//velocity.y = 0;
//		//}
//		//if (Mathf.Abs(velocity.x) < 0.1f)
//		//{
//		//          velocity.x = 0;
//		//}
//		//      if(Mathf.Abs(velocity.y) < 0.1f)
//		//{
//		//          velocity.y = 0;
//		//}
//		if (!onGround)
//		{
//			onGround = true;
//			Vector3 u = Vector3.Dot(velocity, collision.GetContact(0).normal)/* / Vector3.Dot(collision.GetContact(0).normal, collision.GetContact(0).normal)*/ * collision.GetContact(0).normal;
//			Vector3 w = velocity - u;
//			if (u.magnitude < 0.5f)
//			{
//				velocity = 1f * w/* - collision.gameObject.GetComponent<studsYta>().studskoefficient * u*/;
//			}
//			else if (w.magnitude < 0.5f)
//			{
//				velocity = /*1f * w */-collision.gameObject.GetComponent<studsYta>().studskoefficient * u;
//			}
//			else
//			{
//				velocity = 1f * w - collision.gameObject.GetComponent<studsYta>().studskoefficient * u;
//			}
//		}



//		//      if (!onGround)
//		//{
//		//          Vector3 u = Vector3.Dot(velocity, collision.GetContact(0).normal)/* / Vector3.Dot(collision.GetContact(0).normal, collision.GetContact(0).normal)*/ * collision.GetContact(0).normal;
//		//          Vector3 w = velocity - u;
//		//          velocity = 1f * w - collision.gameObject.GetComponent<studsYta>().studskoefficient * u;
//		//          timeSinceLastBounce = 0;
//		//          onGround = true;
//		//      }



//		Debug.Log(collision.gameObject.GetComponent<studsYta>().studskoefficient + " Gravitation: " + gravitation);
//	}
//	//private void OnTriggerEnter(Collider other)
//	//{
//	//    //if (other.tag == "Roof")
//	//    //{
//	//    //    velocity.y = other.gameObject.GetComponent<studsYta>().studskoefficient * -velocity.y;
//	//    //}
//	//    //else if (other.tag == "Wall")
//	//    //{
//	//    //    velocity.x = other.gameObject.GetComponent<studsYta>().studskoefficient * -velocity.x;
//	//    //}
//	//    //else if (other.tag == "Floor")
//	//    //{
//	//    //    velocity.y = other.gameObject.GetComponent<studsYta>().studskoefficient * -velocity.y;
//	//    //    gravitation = 0f;
//	//    //}

//	//}

//	//private void OnTriggerExit(Collider other)
//	//{
//	//    if (other.tag == "Floor")
//	//    {
//	//        gravitation = -9.82f;
//	//    }
//	//}

//	private void OnCollisionExit(Collision collision)
//	{
//		onGround = false;
//	}
//}

