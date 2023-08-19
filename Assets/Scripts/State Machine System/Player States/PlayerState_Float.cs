using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Cinemachine;

[CreateAssetMenu(fileName = "PlayerState_Float", menuName = "Data/StateMachine/PlayerState/Float")]
public class PlayerState_Float : PlayerState
{
    [SerializeField] VoidEventChannel levelDefeated;
    [Header("随机移动坐标点的限制")]
    [SerializeField, Range(0.05f,0.95f)] float floatPositionClampMinx = 0.05f;
    [SerializeField, Range(0.05f, 0.95f)] float floatPositionClampMaxx = 0.95f;
    [SerializeField, Range(0.05f, 0.95f)] float floatPositionClampMiny = 0.05f;
    [SerializeField, Range(0.05f, 0.95f)] float floatPositionClampMaxy = 0.95f;
    [Header("移动到下一个点的时间")]
    [SerializeField] float floatToNextPositionTime = 3.0f;
    [Header("每个点停留时间范围")]
    [SerializeField] float stopMinTime = 1.0f;
    [SerializeField] float stopMaxTime = 3.0f;
    [SerializeField] ParticleSystem floatVFX;

    // 移动参数
    float floatPositionMinx;
    float floatPositionMaxx;
    float floatPositionMiny;
    float floatPositionMaxy;
    float speed;
    Camera mainCamera;
    Vector3 nextPosition;
    Transform currentTransform;

    // 停留参数
    bool IsMoveToPosition;
    float moveToPositionTime;
    float stopTime;

    public override void Enter()
    {
        base.Enter();

        GameObject gameObject = GameObject.Find("Main Camera");
        mainCamera = gameObject.GetComponent<Camera>();
        // 关闭虚拟摄像机的跟随
        gameObject.GetComponent<CinemachineBrain>().enabled = false;

        player.GetComponent<Collider>().layerOverridePriority = 10;

        Instantiate(floatVFX, player.transform.position + new Vector3(0.25f * player.transform.localScale.x, 0.5f, 0), Quaternion.identity, player.transform);

        levelDefeated.BroadCast();

        floatPositionMinx = mainCamera.ViewportToWorldPoint(new Vector3(floatPositionClampMinx, 0, 9)).x;
        floatPositionMaxx = mainCamera.ViewportToWorldPoint(new Vector3(floatPositionClampMaxx, 0, 9)).x;
        floatPositionMiny = mainCamera.ViewportToWorldPoint(new Vector3(0, floatPositionClampMiny, 9)).y;
        floatPositionMaxy = mainCamera.ViewportToWorldPoint(new Vector3(0, floatPositionClampMaxy, 9)).y;

        currentTransform = player.transform;

        RandomNextPosition();
    }

    public override void Update()
    {
        
    }

    public override void PhysicUpdate()
    {
        if(currentTransform.position == nextPosition && !IsMoveToPosition)
        {
            IsMoveToPosition = true;
            moveToPositionTime = Time.time;
        }
        if(IsMoveToPosition && Time.time - moveToPositionTime > stopTime)
        {
            RandomNextPosition();
        }
        else
        {
            currentTransform.position = Vector3.MoveTowards(currentTransform.position, nextPosition, speed * Time.fixedDeltaTime);
        }
    }

    void RandomNextPosition()
    {
        IsMoveToPosition = false;

        nextPosition = new Vector3(Random.Range(floatPositionMinx, floatPositionMaxx), Random.Range(floatPositionMiny, floatPositionMaxy), -1);

        speed = Vector3.Distance(currentTransform.position, nextPosition) / floatToNextPositionTime;

        stopTime = Random.Range(stopMinTime, stopMaxTime);
    }
}
