using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fysik
    : MonoBehaviour
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

    float friktionsKoeffsient = 1f;
    float a, aF, aG;
    float angle = -30f;


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

    Vector3 u, w;

    Vector3 velocity;
    float studs, timeSinceLastBounce = float.MaxValue;

    public bool onGround;

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
            velocity = Vector3.zero;
            gravitation = -9.82f;
            timeSinceLastBounce = float.MaxValue;
            transform.position = new Vector3(float.Parse(inputPosX.text), float.Parse(inputPosY.text), 0);
            velocity.x = Mathf.Cos(float.Parse(inputAngle.text) * Mathf.PI / 180) * float.Parse(inputVelocity.text);
            velocity.y = Mathf.Sin(float.Parse(inputAngle.text) * Mathf.PI / 180) * float.Parse(inputVelocity.text);
        }

  //      if (Mathf.Abs(velocity.magnitude) > 0.1f)
		//{
  //          velocity.y += gravitation * Time.deltaTime;
  //      }
        if(transform.position.y > -0.09f)
		{
            velocity.y += gravitation * Time.deltaTime;
        }
  //      if (!onGround)
		//{
  //          velocity.y += gravitation * Time.deltaTime;
  //      }
        //else if (velocity.x >= 0)
        //{

        //    aF = friktionsKoeffsient * gravitation * Mathf.Cos(/*angle*/90f * Mathf.PI / 180f);
        //    aG = gravitation * Mathf.Sin(/*angle*/ 90f * Mathf.PI / 180f);
        //    a = aF + aG;

        //    velocity.x += a * Mathf.Cos(angle * Mathf.PI / 180f) * Time.deltaTime;
        //    velocity.y += a * Mathf.Sin(angle * Mathf.PI / 180f) * Time.deltaTime;
        //}

        //Move();



        currentPosX.text = "Current x position: " + Mathf.Round(transform.position.x * 100f) / 100f;
        currentPosY.text = "Current y position: " + Mathf.Round(transform.position.y * 100f) / 100f;
    }

	private void FixedUpdate()
	{
        Move();
    }


	private void Move()
    {
        transform.position += velocity * Time.fixedDeltaTime;
    }

	private void OnCollisionEnter(Collision collision)
	{
		u = Vector3.Dot(velocity, collision.GetContact(0).normal) * collision.GetContact(0).normal;
		w = velocity - u;
		velocity = collision.gameObject.GetComponent<studsYta>().friktionskoefficient * w - collision.gameObject.GetComponent<studsYta>().studskoefficient * u;
		//onGround = true;
	}
	//private void OnCollisionStay(Collision collision)
	//{
 //       //u = Vector3.Dot(velocity, collision.GetContact(0).normal) * collision.GetContact(0).normal;
 //       //w = velocity - u;
 //       //velocity = collision.gameObject.GetComponent<studsYta>().friktionskoefficient * w - collision.gameObject.GetComponent<studsYta>().studskoefficient * u;
	//	//u = Vector3.Dot(velocity, collision.GetContact(0).normal) * collision.GetContact(0).normal;
	//	//w = velocity - u;
	//	//velocity = 0.9f * w - collision.gameObject.GetComponent<studsYta>().studskoefficient * u;
	//	//velocity = 0.9f * w - collision.gameObject.GetComponent<studsYta>().studskoefficient * u;
	//	//Sliding
	//	onGround = true;
	//}
	//private void OnCollisionExit(Collision collision)
	//{
 //       onGround = false;
	//}
}
