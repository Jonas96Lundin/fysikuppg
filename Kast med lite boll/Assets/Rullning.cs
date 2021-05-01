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

    Vector3 u, w;

    private Vector3 velocity;
    private float currentSpeed;

    private void Start()
    {
        inputPosX.text = initialPositionX.ToString();
        inputPosY.text = initialPositionY.ToString();
        inputVelocity.text = initialVelocity.ToString();
        inputAngle.text = initialAngle.ToString();

        r = gameObject.GetComponent<SphereCollider>().radius / 2;

        transform.position = new Vector3(initialPositionX, initialPositionY, 0);
		velocity.x = Mathf.Cos(initialAngle * Mathf.PI / 180) * initialVelocity;
		velocity.y = Mathf.Sin(initialAngle * Mathf.PI / 180) * initialVelocity;
        //currentSpeed = initialVelocity;
        //angle = initialAngle;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = new Vector3(float.Parse(inputPosX.text), float.Parse(inputPosY.text), 0);
			velocity.x = Mathf.Cos(float.Parse(inputAngle.text) * Mathf.PI / 180) * float.Parse(inputVelocity.text);
			velocity.y = Mathf.Sin(float.Parse(inputAngle.text) * Mathf.PI / 180) * float.Parse(inputVelocity.text);
            //currentSpeed = float.Parse(inputVelocity.text);
        }

        //Debug.Log(w);
        //Debug.Log(u);
        //Debug.Log("Angle: " + angle);
        //Debug.Log("Velocity: " + velocity);

        currentPosX.text = "Current x position: " + Mathf.Round(transform.position.x * 100f) / 100f;
        currentPosY.text = "Current y position: " + Mathf.Round(transform.position.y * 100f) / 100f;


		if(transform.position.x > 55)
		{
			angle = 15;
		}
		else if(transform.position.x > 32)
		{
			angle = 0;
		}
		else if(transform.position.x > 9)
		{
			angle = -20;
		}
		else
		{
			angle = 0;
		}

		aG = -gravity * Mathf.Sin(angle * Mathf.PI / 180f);
		velocity.x += Mathf.Cos(angle * Mathf.PI / 180) * aG * Time.deltaTime;
		currentSpeed = velocity.x / Mathf.Cos(angle * Mathf.PI / 180);
		velocity.y = Mathf.Sin(angle * Mathf.PI / 180) * currentSpeed;


		angleSpeed = Mathf.Sqrt(3 / 2 * Mathf.Pow(currentSpeed, 2) / Mathf.Pow(r, 2));
        Debug.Log(currentSpeed);
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
}
