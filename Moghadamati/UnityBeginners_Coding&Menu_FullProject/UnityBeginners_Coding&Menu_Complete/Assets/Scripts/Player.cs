using UnityEngine;

public class Player : MonoBehaviour
{
	public float moveX;
	public float moveZ;
	public float speed;

	private GameController gc;

	private void Start()
	{
		gc = GameObject.Find("GameController").GetComponent<GameController>();
	}

	private void Update()
	{
		PlayerMovement();
	}

	private void PlayerMovement()
	{
		transform.position = new Vector3(moveX, 0.137f, moveZ);

		if (!gc.isGameFinished)
		{
			if (Input.GetKey(KeyCode.A))
				moveX -= speed * Time.deltaTime;

			if (Input.GetKey(KeyCode.D))
				moveX += speed * Time.deltaTime;

			if (Input.GetKey(KeyCode.W))
				moveZ += speed * Time.deltaTime;

			if (Input.GetKey(KeyCode.S))
				moveZ -= speed * Time.deltaTime;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Scores")
		{
			gc.score += 1;
			speed += 0.75f;
			transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
			Destroy(other.gameObject);
		}

		if (other.gameObject.tag == "Enemy")
			gc.Lose();
	}
}
