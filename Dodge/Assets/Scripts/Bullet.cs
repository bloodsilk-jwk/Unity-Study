using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        // Rigidbody를 찾아 bulletRigidbody에 할당
        bulletRigidbody = GetComponent<Rigidbody>();

        // 속도 = 방향 * 속력
        bulletRigidbody.velocity = transform.forward * speed;

        // 3초 뒤에 자멸
        Destroy(gameObject, 3f);
    }

    // OnTrigger 계열 >> 둘 중 하나라도 Trigger 콜라이더인 경우
    // Enter : 충돌했을 때
    // Stay : 충돌하는 동안
    // Exit : 충돌이 끝나는 순간

    // OnCollison 계열 >> 둘 다 Collision 콜라이더인 경우
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // 상대방 게임 오브젝트에서 PlayerController 가져오기
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.Die();
            }
        }
    }
}
