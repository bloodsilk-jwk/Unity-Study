using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����Ƽ�� ����� ����ϰڴ�

public class Player : MonoBehaviour // �̸��� ���ϸ�� �Ȱ���
{
    [SerializeField]
    private int m_hp; // �÷��̾� ü��
    private string m_name; // �÷��̾� �̸�
    
    // Start is called before the first frame update
    void Start()
    {
        m_hp = 10;
        m_name = "player";

        Debug.Log("�÷��̾��� ü���� " + m_hp + "�� �ʱ�ȭ �Ǿ����ϴ�.");
        Debug.Log("�÷��̾��� �̸��� " + m_name + "�� �ʱ�ȭ �Ǿ����ϴ�.");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            increaseHP();
            Debug.Log("�÷��̾��� ü���� " + m_hp + "�� �Ǿ����ϴ�.");
        }
    }

    private void increaseHP()
    {
        m_hp += 1; // ���� hp���� 1��ŭ ���� >> ü�� ����
    }
}
