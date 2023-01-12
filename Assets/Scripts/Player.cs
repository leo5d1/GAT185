using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Range(1, 100), Tooltip("Controls the speed of the Player")] public float speed = 5;
    public float rotationRate = 180;
    public GameObject prefab;
    public Transform bulletSpawn;

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
        Vector3 direction = Vector3.zero;

        direction.z = Input.GetAxis("Vertical");

        
        if (Input.GetKey(KeyCode.Space)) direction.y = 1;
        if (Input.GetKey(KeyCode.LeftShift)) speed = 100;

        Vector3 rotation = Vector3.zero;

        rotation.y = Input.GetAxis("Horizontal");

        Quaternion rotate = Quaternion.Euler(rotation * rotationRate * Time.deltaTime);
        transform.rotation = transform.rotation * rotate;

        transform.Translate((direction * speed) * Time.deltaTime);

        if (Input.GetMouseButton(0))
        {
            Instantiate(prefab, bulletSpawn.position, bulletSpawn.rotation);
        }
    }
}
