using UnityEngine;

public class DeathTrap_6 : MonoBehaviour
{
	public GameObject spikeObject;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
			spikeObject.GetComponent<Animation>().Play();
	}
}
