using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    public GameObject bulletPrefab; // 생성할 Object의 원본 Prefab
    public float spawnRateMin = 0.5f; // 생성되는 최소 주기
    public float spawnRateMax = 1f; // 생성되는 최대 주기

    private Transform target; // 발사할 대상
    private float spawnRate; // 생성 주기
    private float timeAfterSpawn; // 최근 생성 후 지난 시간


    // Start is called before the first frame update
    void Start()
    {
        // 최근 생성 후 지난 시간 초기화
        timeAfterSpawn = 0f; 
        // Random.Range(최소, 최대) 사용 >> 범위 중 난수 생성
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        // FindObjectOfType<오브젝트>() 사용 >> 조준 대상으로 설정
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        // timeAfterSpawn을 갱신
        timeAfterSpawn += Time.deltaTime;

        // 누적된 시간 >= 생성 주기
        if (timeAfterSpawn >= spawnRate)
        {
            // 누적된 시간을 리셋
            timeAfterSpawn = 0f;

            // bulletPrefab의 복제본
            // transform.position 위치와 transform.rotation 회전으로 생성
            GameObject bullet
                = Instantiate(bulletPrefab, transform.position, transform.rotation);
            // 생성된 bullet의 정면 방향이 target을 향하도록 회전
            bullet.transform.LookAt(target);

            // 난수 랜덤 지정
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
