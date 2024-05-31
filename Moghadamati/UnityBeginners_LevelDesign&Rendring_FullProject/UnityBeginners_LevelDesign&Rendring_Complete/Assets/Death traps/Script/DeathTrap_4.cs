using UnityEngine;

public class DeathTrap_4 : MonoBehaviour
{
	public float range;
	public float speed;
	float submittedTime;

	void Update()
	{
		transform.Translate(speed * Time.deltaTime, 0, 0);

		if (transform.localPosition.x >= range || transform.localPosition.x <= 0)
			if (Time.time > submittedTime + 1)
			{
				speed = -speed;
				submittedTime = Time.time;
			}
	}
}
