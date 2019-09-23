using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{
	public int BulletPoolTotal = 10;
	public GameObject BulletPrefab;
	public GameObject[] BulletPool;
	GameObject BulletSpawnPoint;
	int CurrentBulletIndex = -1;

	// Start is called before the first frame update
	void Start()
	{
		Vector3 BulletSpawntPos = new Vector3(transform.position.x, transform.position.y + 0.035f, transform.position.z);
		Quaternion BulletSpawnRotate = Quaternion.Euler(transform.rotation.x + 90, transform.rotation.y, transform.rotation.z);

		BulletPool = new GameObject[BulletPoolTotal];
		BulletSpawnPoint = Instantiate(new GameObject(), BulletSpawntPos, BulletSpawnRotate);
		BulletSpawnPoint.name = "BulletSpawnPoint";
		BulletSpawnPoint.transform.SetParent(transform);

		for (int i = 0; i < BulletPoolTotal; i++)
		{
			BulletPool[i] = Instantiate(BulletPrefab, new Vector3(BulletSpawnPoint.transform.position.x, BulletSpawnPoint.transform.position.y, BulletSpawnPoint.transform.position.z), BulletSpawnPoint.transform.rotation);
			BulletPool[i].transform.SetParent(BulletSpawnPoint.transform);
			BulletPool[i].SetActive(false);
		}
	}
	private void Update()
	{
		if (Input.anyKeyDown)
		{
			GetBullet();
			Debug.Log(CurrentBulletIndex);
		}
	}

	public GameObject GetBullet()
	{

		CurrentBulletIndex++;
		if (CurrentBulletIndex > BulletPoolTotal - 2)
			CurrentBulletIndex = -1;
		return BulletPool[CurrentBulletIndex];
	}
}
