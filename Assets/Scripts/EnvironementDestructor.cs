using UnityEngine;

public class EnvironementDestructor : MonoBehaviour
{
	private void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag == "environement" || collider.gameObject.tag == "obstacle")
		{
            Destroy(collider.gameObject);
		}
	}
}
