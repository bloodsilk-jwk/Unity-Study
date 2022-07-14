using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    public GameObject bulletPrefab; // ������ Object�� ���� Prefab
    public float spawnRateMin = 0.5f; // �����Ǵ� �ּ� �ֱ�
    public float spawnRateMax = 1f; // �����Ǵ� �ִ� �ֱ�

    private Transform target; // �߻��� ���
    private float spawnRate; // ���� �ֱ�
    private float timeAfterSpawn; // �ֱ� ���� �� ���� �ð�


    // Start is called before the first frame update
    void Start()
    {
        // �ֱ� ���� �� ���� �ð� �ʱ�ȭ
        timeAfterSpawn = 0f; 
        // Random.Range(�ּ�, �ִ�) ��� >> ���� �� ���� ����
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        // FindObjectOfType<������Ʈ>() ��� >> ���� ������� ����
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        // timeAfterSpawn�� ����
        timeAfterSpawn += Time.deltaTime;

        // ������ �ð� >= ���� �ֱ�
        if (timeAfterSpawn >= spawnRate)
        {
            // ������ �ð��� ����
            timeAfterSpawn = 0f;

            // bulletPrefab�� ������
            // transform.position ��ġ�� transform.rotation ȸ������ ����
            GameObject bullet
                = Instantiate(bulletPrefab, transform.position, transform.rotation);
            // ������ bullet�� ���� ������ target�� ���ϵ��� ȸ��
            bullet.transform.LookAt(target);

            // ���� ���� ����
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
