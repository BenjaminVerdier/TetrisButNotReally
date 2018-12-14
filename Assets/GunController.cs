using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    public GameObject gun;
    public Transform bulletSpawn;

    public int force;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        gun.transform.localRotation = Quaternion.FromToRotation(transform.forward, ray.direction);
        if (Input.GetMouseButtonDown(0)) {
            SpawnBullet();
        }
    }

    void SpawnBullet() {
        GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        bullet.transform.localScale = new Vector3(.1f, .1f, .1f);
        bullet.transform.position = bulletSpawn.position;
        bullet.transform.rotation = bulletSpawn.rotation;

        Rigidbody rb = bullet.AddComponent<Rigidbody>();

        rb.AddForce(bullet.transform.forward * force, ForceMode.Impulse);

        bullet.AddComponent<BulletDespawn>();
    }
}
