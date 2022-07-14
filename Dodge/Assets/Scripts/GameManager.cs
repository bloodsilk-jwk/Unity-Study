using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; //���ӿ��� �� Ȱ��ȭ�� �ؽ�Ʈ ���� ������Ʈ
    public Text TimeText;
    public Text RecordText;

    private float surviveTime; // ������ �ð�
    private bool isGameover;

    void Start()
    {
        surviveTime = 0;
        isGameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameover)
        {
            //���� �ð� ����
            surviveTime += Time.deltaTime;
            //������ ���� �ð��� timeText �ؽ�Ʈ ������Ʈ�� �̿��� ǥ��
            TimeText.text = "Time : " + (int)surviveTime;
        }
        else
        {
            //���ӿ����� ���¿��� RŰ�� ���� ���
            if (Input.GetKeyDown(KeyCode.R))
            {
                //MainScene ���� �ε�
                SceneManager.LoadScene("SampleScene"); // ����� ���� Scene �̸�
            }
        }
    }
    // ���� ������ ���ӿ��� ���·� �����ϴ� �޼���
    // >> �÷��̾� ��� �� 
    public void EndGame()
    {
        //���� ���¸� ���ӿ��� ���·� ��ȯ
        isGameover = true;
        //���ӿ��� �ؽ�Ʈ ���� ������Ʈ�� Ȱ��ȭ
        gameoverText.SetActive(true);

        //BestTime Ű�� ����� ���������� �ְ� ��� ��������
        float bestTime = PlayerPrefs.GetFloat("BestTime");
        // >> ����� ��ǻ�Ϳ� ���÷� ����

        //���������� �ְ���Ϻ��� ���� ���� �ð��� �� ũ�ٸ�
        if (surviveTime > bestTime)
        {
            //�ְ� ��� ���� ���� ���� �ð� ������ ����
            bestTime = surviveTime;
            //����� �ְ� ����� BestTime Ű�� ����
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        //�ְ� ����� recordText �ؽ�Ʈ ������Ʈ�� �̿��� ǥ��
        RecordText.text = "Best Time: " + (int)bestTime;
    }
}