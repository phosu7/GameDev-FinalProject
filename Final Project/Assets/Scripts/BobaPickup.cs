using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobaPickup : MonoBehaviour
{
    [SerializeField] AudioClip ammo;

    private void OnTriggerEnter2D(Collider2D other)
    {
        ProjectileThrower projectileThrower = other.gameObject.GetComponentInChildren<ProjectileThrower>();

        if (projectileThrower)
        {
            AudioSource.PlayClipAtPoint(ammo, transform.position);
            projectileThrower.AddBoba(projectileThrower.ammoSize);

            Destroy(gameObject);
        }

    }


}
