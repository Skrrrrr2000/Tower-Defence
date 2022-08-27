using UnityEngine;

namespace _Scripts.Runtime
{
	public class CameraController : MonoBehaviour
	{
		//[SerializeField] Camera camera;

		public float panSpeed = 30f;
		public float panBorderThickness = 10f;

		//public float scrollSpeed = 5f;
		
		void Update()
		{
			if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
			{
				transform.Translate(Vector3.up * panSpeed * Time.deltaTime, Space.World);
			}
			if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
			{
				transform.Translate(Vector3.down * panSpeed * Time.deltaTime, Space.World);
			}
			if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
			{
				transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
			}
			if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
			{
				transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
			}

			transform.position = new Vector2(Mathf.Clamp(transform.position.x, -5f, 5f), Mathf.Clamp(transform.position.y, -6f, 6f));
			
		}
	}
}