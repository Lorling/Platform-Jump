using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    
    // 单例模式
    public static ObjectPool Instance { get; private set; }

    // 池子要存储的物体
    [SerializeField] private GameObject Object;
    // 使用队列存放物体
    private Queue<GameObject> objectPool = new Queue<GameObject>();

    // 默认容量
    public int defaultCount = 16;
    // 最大容量
    public int maxCount = 32;

    private void Awake()
    {
        Instance = this;
        Init(defaultCount);
    }

    // 对池子进行初始化
    private void Init(int count = 16)
    {
        GameObject obj;
        for(int i = 0; i < count; i++)
        {
            // 生成物体并入队以及取消活跃
            obj = Instantiate(Object);
            // 将生成的物体设置为对象池的子对象
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

        // 如果池子中没有物体，就新建一个
        if (objectPool.Count == 0) {
            Init(1);
        }
        // 从池子中取出一个物体
        res = objectPool.Dequeue();
        res.SetActive(true);

        return res;
    }
}
