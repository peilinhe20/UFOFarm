using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerialReceive : MonoBehaviour
{
    //https://qiita.com/yjiro0403/items/54e9518b5624c0030531
    //��LURL��SerialHandler.c�̃N���X
    public SerialHandler serialHandler;

    public string[] A;
    public float SerialX, SerialY;

    void Start()
    {
        //�M������M�����Ƃ��ɁA���̃��b�Z�[�W�̏������s��
        serialHandler.OnDataReceived += OnDataReceived;
    }

    //��M�����M��(message)�ɑ΂��鏈��
    void OnDataReceived(string message)
    {
        var data = message.Split(
                new string[] { "\n" }, System.StringSplitOptions.None);
        try
        {
            A = data[0].Split(',');
            SerialX = float.Parse(A[0]);
            SerialY = float.Parse(A[1]);
            //SerialX = int.Parse(data[0]);
            Debug.Log(data[0]);//Unity�̃R���\�[���Ɏ�M�f�[�^��\��
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.Message);//�G���[��\��
        }
    }
}