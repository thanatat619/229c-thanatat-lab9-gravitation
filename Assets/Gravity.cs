using UnityEngine;
using System.Collections.Generic;

public class Gravitation : MonoBehaviour
{
    Rigidbody rb;
    const float G = 0.006674f;

    // List of attractable objects
    public static List<Gravitation> otherObjectList;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (otherObjectList == null) {otherObjectList = new List<Gravitation>();}
        otherObjectList.Add(this);
    }
    private void FixedUpdate()
    {
        foreach (Gravitation obj in otherObjectList)
        {
            // ��ͧ�ѹ���������ç�֧�ٴ����ͧ
            if (obj != this) {AttractForce(obj);}
        }
    }
    void AttractForce(Gravitation other)
    {
        Rigidbody otherRb = other.rb;
        // �ҷ�ȷҧ�����ҧ�ѵ��
        Vector3 direction = rb.position - otherRb.position;
        // ������ҧ�����ҧ�ѵ��
        float distance = direction.magnitude;
        // ����ѵ��������˹����ǡѹ �����������
        if (distance == 0f) { return;}
        // ���ٵ����ç�֧�ٴ F = G*((m1*m2)/r^2)
        float forceMagnitude = G * ((rb.mass * otherRb.mass) / Mathf.Pow(distance, 2));
        // �����ȷҧ ��ҡѺ�ç�֧�ٴ�����
        Vector3 gravityForce = forceMagnitude * direction.normalized;
        // ����ç��������Ѻ�ѵ�����
        otherRb.AddForce(gravityForce);
    }

}