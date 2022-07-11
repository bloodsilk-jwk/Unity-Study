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
        // Rigidbody�� ã�� bulletRigidbody�� �Ҵ�
        bulletRigidbody = GetComponent<Rigidbody>();

        // �ӵ� = ���� * �ӷ�
        bulletRigidbody.velocity = transform.forward * speed;

        // 3�� �ڿ� �ڸ�
        Destroy(gameObject, 3f);
    }

    // OnTrigger �迭 >> �� �� �ϳ��� Trigger �ݶ��̴��� ���
    // Enter : �浹���� ��
    // Stay : �浹�ϴ� ����
    // Exit : �浹�� ������ ����

    // OnCollison �迭 >> �� �� Collision �ݶ��̴��� ���
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // ���� ���� ������Ʈ���� PlayerController ��������
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.Die();
            }
        }
    }
}
