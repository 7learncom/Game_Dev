using UnityEngine;
using System.Collections;

namespace DungeonCellar.Examples
{
	[AddComponentMenu("Dungeon Cellar/Player Movement")]
	[RequireComponent(typeof(CharacterController))]
	public class PlayerMovement : MonoBehaviour
	{
		public float MovementSpeed = 10;
		public float GravityScale = 2.0f;

		private CharacterController controller;
		private Vector3 velocityFromGravity;


		private void Start()
		{
			controller = GetComponent<CharacterController>();
		}

		private void Update()
		{
			float horiz = Input.GetAxisRaw("Horizontal");
			float vert = Input.GetAxisRaw("Vertical");

			Vector3 velocity = transform.forward * vert + transform.right * horiz;
			velocity = velocity.normalized * MovementSpeed;

			if (!controller.isGrounded)
			{
				velocityFromGravity += Physics.gravity * GravityScale * Time.deltaTime;
				velocity += velocityFromGravity;
			}
			else
				velocityFromGravity = Vector3.zero;

			controller.Move(velocity * Time.deltaTime);
		}
	}
}
