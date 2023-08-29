using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    
    // ����ģʽ
    public static ObjectPool Instance { get; private set; }

    // ����Ҫ�洢������
    [SerializeField] private GameObject Object;
    // ʹ�ö��д������
    private Queue<GameObject> objectPool = new Queue<GameObject>();

    // Ĭ������
    public int defaultCount = 16;
    // �������
    public int maxCount = 32;

    private void Awake()
    {
        Instance = this;
        Init(defaultCount);
    }

    // �Գ��ӽ��г�ʼ��
    private void Init(int count = 16)
    {
        GameObject obj;
        for(int i = 0; i < count; i++)
        {
            // �������岢����Լ�ȡ����Ծ
            obj = Instantiate(Object);
            // �����ɵ���������Ϊ����ص��Ӷ���
            obj.transform.SetParent(transform);
            Push(obj);
        }
    }

    public void Push(GameObject obj)
    {
        obj.SetActive(false);
        objectPool.Enqueue(obj);
    }

    public GameObject Get()
    {
        GameObject res;

        // ���������û�����壬���½�һ��
        if (objectPool.Count == 0) {
            Init(1);
        }
        // �ӳ�����ȡ��һ������
        res = objectPool.Dequeue();
        res.SetActive(true);

        return res;
    }
}
