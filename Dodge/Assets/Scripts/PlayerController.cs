using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRigidbody;
    public float speed = 81;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // 수평 수직 축 입력 값 감지해서 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // 실제 이동 속도를 입력 값과 이동 속력을 통해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        // 3차원벡터 속도 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0, zSpeed);

        // Rigidbody에 속도를 할당
        playerRigidbody.velocity = newVelocity;
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
