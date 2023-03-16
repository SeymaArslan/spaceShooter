using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour
{
	public float scrollSpeed;
	public float tileSizeZ;
	
	private Vector3 startPosition;
	
	void Start ()
	{
		startPosition = transform.position;
	}
	
	void Update ()
	{
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ); //Mathf.Repeat --> alduğu değerle döngü yapıyor yani dönmeyi sağlıyor.
		transform.position = startPosition + Vector3.forward * newPosition; // Vector3 boyut z
	}
}