using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(CollisionEvent))]
public class Heal : Interactable
{
	[SerializeField] float heal = 0;

	void Start()
	{
		GetComponent<CollisionEvent>().onEnter += OnInteract;
	}

	public override void OnInteract(GameObject target)
	{
		if (target.TryGetComponent<Health>(out Health health))
		{
			health.OnApplyHealth(heal);
		}

		if (interactFX != null) Instantiate(interactFX, transform.position, Quaternion.identity);
		if (destroyOnInteract) Destroy(this.gameObject);
	}
}
