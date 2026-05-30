using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStratLoading_qidao : MonoBehaviour
{
    public TextMeshProUGUI T;

    // ��ͨ����ʼ�������ã�0=����1=����
    private int _rFlag = 0;
    private int _gFlag = 0;
    private int _bFlag = 0;
    private int _aFlag = 0;

    // �������ã��ɶ�������ÿ��ͨ�����ٶȣ�
    private readonly float _rStep = 1f / 255f;
    private readonly float _gStep = 1f / 255f;
    private readonly float _bStep = 1f / 255f;
    private readonly float _aStep = 1.5f / 255f;

    void Update()
    {
        UpdateTextColor();
    }


    // ���ķ�����ͳһ������ɫѭ��
    void UpdateTextColor()
    {
        Color color = T.color;
        // ����ͨ�÷�������ÿ��ͨ�����Զ�����ֵ�ͷ���flag
        // �����ʱ�����rgb�ˣ��ʲ������Ĳ��ÿ�
        //color.r = CycleColorChannel(color.r, ref _rFlag, _rStep);
        //color.g = CycleColorChannel(color.g, ref _gFlag, _gStep);
        //color.b = CycleColorChannel(color.b, ref _bFlag, _bStep);
        color.a = CycleColorChannel(color.a, ref _aFlag, _aStep);
        T.color = color;
    }

    // ������currentValue=��ǰֵ��flag=�����ǣ����ô��ݣ���step=�仯����
    private float CycleColorChannel(float currentValue, ref int flag, float step)
    {
        if (flag == 0) // ����
        {
            currentValue -= step;
            if (currentValue <= 0)
            {
                currentValue = 0f;
                flag = 1; // �л�Ϊ����
            }
        }
        else // ����
        {
            currentValue += step;
            if (currentValue >= 1)
            {
                currentValue = 1f;
                flag = 0; // �л�Ϊ����
            }
        }
        return Mathf.Clamp01(currentValue); // ���ձ߽籣��
    }
}
