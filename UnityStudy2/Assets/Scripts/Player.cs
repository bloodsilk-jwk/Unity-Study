using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 유니티의 기능을 사용하겠다

public class Player : MonoBehaviour // 이름은 파일명과 똑같게
{
    [SerializeField]
    private int m_hp; // 플레이어 체력
    private string m_name; // 플레이어 이름
    
    // Start is called before the first frame update
    void Start()
    {
        m_hp = 10;
        m_name = "player";

        Debug.Log("플레이어의 체력이 " + m_hp + "로 초기화 되었습니다.");
        Debug.Log("플레이어의 이름이 " + m_name + "로 초기화 되었습니다.");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            increaseHP();
            Debug.Log("플레이어의 체력이 " + m_hp + "가 되었습니다.");
        }
    }

    private void increaseHP()
    {
        m_hp += 1; // 기존 hp보다 1만큼 증가 >> 체력 증가
    }
}
