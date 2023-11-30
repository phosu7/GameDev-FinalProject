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
            GetComponent<AudioSource>().PlayOneShot(ammo);



            //AudioSource.PlayClipAtPoint(ammo, transform.position);
            if (this.tag == "Boba")
            {
                projectileThrower.AddBoba(projectileThrower.ammoSize, 0, 0);
            }

            if (this.tag == "BlueBoba")
            {
                projectileThrower.AddBoba(0, 2, 0);
            }

            if (this.tag == "RedBoba")
            {
                projectileThrower.AddBoba(0, 0, 1);
            }
            // projectileThrower.AddBoba(projectileThrower.ammoSize, 0, 0);
            Debug.Log("i picked up boba");
            Destroy(gameObject);
        }

    }


}
