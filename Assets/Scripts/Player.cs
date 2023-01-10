using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Range(1, 100), Tooltip("Controls the speed of the Player")] public float speed = 5;
    public GameObject prefab;

	private void Awake()
	{
        Debug.Log("awake");
	}

	void Start()
    {
        Debug.Log("start");
    }

    void Update()
    {
        //transform.position = new Vector3(2, 3, 4);
        //transform.rotation = Quaternion.Euler(30, 30, 30);
        //transform.localScale = Vector3.one * Random.value * 5;

        Vector3 direction = Vector3.zero;
        float rotation = 0;

        //direction.x = Input.GetAxis("Horizontal");
        //direction.z = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.A)) direction.x = -1;
        if (Input.GetKey(KeyCode.D)) direction.x = 1;
        if (Input.GetKey(KeyCode.W)) direction.z = 1;
        if (Input.GetKey(KeyCode.S)) direction.z = -1;
        if (Input.GetKey(KeyCode.Q)) rotation = 10;
        if (Input.GetKey(KeyCode.E)) rotation = -10;
        if (Input.GetKey(KeyCode.Space)) direction.y = 1;
        if (Input.GetKey(KeyCode.LeftShift)) speed = 10;

        if (direction.y > 0) direction.y -= 0.1f;

        transform.position += (direction * speed) * Time.deltaTime;
    
        

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("pew");
            GetComponent<AudioSource>().Play();
            var bTransform = Quaternion.Euler(90, 0, 0);
            var bPosition = transform.position;
            bPosition.x = transform.position.x - 0.7f;
            bPosition.z = transform.position.z + 1.2f;
            bPosition.y = transform.position.y + 0.5f;
            Instantiate(prefab, bPosition, bTransform);
        }
    }
}
