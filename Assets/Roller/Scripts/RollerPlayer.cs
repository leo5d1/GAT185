using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerPlayer : MonoBehaviour
{
    [SerializeField] private Transform view;
    [SerializeField] private int maxForce = 5;

    private int score = 0;
    private Vector3 force;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        view = Camera.main.transform;
        Camera.main.GetComponent<RollerCamera>().SetTarget(transform);
    }

    void Update()
    {
        Vector3 direction = Vector3.zero;

        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        Quaternion viewSpace = Quaternion.AngleAxis(view.rotation.eulerAngles.y, Vector3.up);
        force = viewSpace *  direction * maxForce;

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * maxForce, ForceMode.Impulse);
        }

        RollerGameManager.Instance.SetHealth(50);
    }

	private void FixedUpdate()
	{
		rb.AddForce(force);
	}

    public void AddPoints(int points)
    {
        score += points;
        RollerGameManager.Instance.SetScore(score);
    }
}
