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
    float initialVelocity = 100f;

    float initialSpeedX, initialSpeedY;

    [SerializeField]
    float gravitation = -9.82f;

    float friktionsKoeffsient = 1f;
    float a, aF, aG;
    float angle = -30f;

    //
    float speed;
    float r, angleSpeed;


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


    private RaycastHit hit;

    private void Start()
    {
        inputPosX.text = initialPositionX.ToString();
        inputPosY.text = initialPositionY.ToString();
        inputVelocity.text = initialVelocity.ToString();
        inputAngle.text = initialAngle.ToString();

        transform.position = new Vector3(initialPositionX, initialPositionY, 0);

        velocity.x = Mathf.Cos(initialAngle * Mathf.PI / 180) * initialVelocity;
        velocity.y = Mathf.Sin(initialAngle * Mathf.PI / 180) * initialVelocity;

        //
        speed = initialVelocity;
        //angle = initialAngle;
        angle = Vector3.Angle(transform.position, Vector3.right);
        r = gameObject.GetComponent<SphereCollider>().radius / 2;
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
			onGround = false;
        }

        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 100);



        //if (transform.position.y > -0.09f)
        //{
        //    velocity.y += gravitation * Time.deltaTime;
        //}
        //if (!onGround)
        //{
        //          velocity.y += gravitation * Time.deltaTime;
        //      }
        //else
        //{
        //          velocity += w * friktionsKoeffsient * Time.deltaTime;
        //      }
        //      //velocity.y += gravitation * Time.deltaTime;

        //      if(Mathf.Abs(Vector3.Dot(w, velocity)) > 0.9f)
        //{
        //          onGround = true;
        //      }
        //else
        //{
        //          onGround = false;
        //      }

        //velocity += w * friktionsKoeffsient;
        //velocity.y += gravitation;

        Debug.Log(w);

        currentPosX.text = "Current x position: " + Mathf.Round(transform.position.x * 100f) / 100f;
        currentPosY.text = "Current y position: " + Mathf.Round(transform.position.y * 100f) / 100f;

        if (hit.distance > 0.5f)
        {
            velocity.y += gravitation * Time.deltaTime;
        }
		else
		{
            aG = gravitation * Mathf.Sin(angle * Mathf.PI / 180f);
            velocity.x += Mathf.Cos(angle * Mathf.PI / 180) * aG * Time.deltaTime;
            velocity.y += Mathf.Sin(angle * Mathf.PI / 180) * aG * Time.deltaTime;    
        }


        //
        
        //velocity.y += gravitation;

        angleSpeed = Mathf.Sqrt(3 / 2 * Mathf.Pow(speed, 2) / Mathf.Pow(r, 2));

        //transform.rotation = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z + angleSpeed);

        

	}

    private void FixedUpdate()
    {
		Move();
		transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z + angleSpeed));
    }


    private void Move()
    {
        transform.position += velocity * Time.fixedDeltaTime;
    }

	private void OnCollisionEnter(Collision collision)
	{
		//u = Vector3.Dot(velocity, collision.GetContact(0).normal) * collision.GetContact(0).normal;
		//w = velocity - u;
		//velocity = collision.gameObject.GetComponent<studsYta>().friktionskoefficient * w - collision.gameObject.GetComponent<studsYta>().studskoefficient * u;


		u = Vector3.Dot(velocity, collision.GetContact(0).normal) * collision.GetContact(0).normal;
		w = velocity - u;
		friktionsKoeffsient = collision.gameObject.GetComponent<studsYta>().friktionskoefficient;
        //velocity = collision.gameObject.GetComponent<studsYta>().friktionskoefficient * w;
        //onGround = true;

        angle = Vector3.Angle(transform.position, w);
    }
	//private void OnCollisionStay(Collision collision)
	//{
	//	u = Vector3.Dot(velocity, collision.GetContact(0).normal) * collision.GetContact(0).normal;
	//	w = velocity - u;
	//	friktionsKoeffsient = collision.gameObject.GetComponent<studsYta>().friktionskoefficient;
	//}

	//private void OnCollisionExit(Collision collision)
	//{
 //       //onGround = false;
 //   }
}
