using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DungeonCellar.Examples
{
	[AddComponentMenu("Dungeon Cellar/Camera Controller")]
	public class CameraController : MonoBehaviour
	{
		public GameObject YawObject;
		public GameObject PitchObject;
		public float RotationRate = 360;
		public float MinPitch = -85;
		public float MaxPitch = 85;
		public bool InvertY = false;

		private float yaw;
		private float pitch;


		private void Update()
		{
			float lookRight = Input.GetAxisRaw("Mouse X");
			float lookUp = Input.GetAxisRaw("Mouse Y");

			float rotationAmount = RotationRate * Time.deltaTime;
			lookRight *= rotationAmount;
			lookUp *= rotationAmount;

			yaw += lookRight;
			pitch += (InvertY) ? -lookUp : lookUp;
			pitch = Mathf.Clamp(pitch, MinPitch, MaxPitch);

			if (YawObject == PitchObject && YawObject != null)
				YawObject.transform.rotation = Quaternion.Euler(-pitch, yaw, 0);
			else
			{
				if(YawObject != null)
					YawObject.transform.localRotation = Quaternion.Euler(0, yaw, 0);

				if(PitchObject != null)
					PitchObject.transform.localRotation = Quaternion.Euler(-pitch, 0, 0);
			}
		}
	}
}
