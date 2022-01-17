using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameConstants
{
    public static Vector3 CameraAngleOffset { get; set; }
    public static Vector3 CameraPositionOffset { get; set; }
    public static float Damping { get; set; }
}

public abstract class TPCBase
{
    protected Transform cameraTransform;
    protected Transform playerTransform;

    public TPCBase(Transform camera, Transform player)
    {
        cameraTransform = camera;
        playerTransform = player;
    }

    public abstract void Tick();
}

public class TPCTrack : TPCBase
{
    public TPCTrack(Transform camera, Transform player): base(camera, player)
    {

    }
    public override void Tick()
    {
        const float playerHeight = 2.0f;
        Vector3 targetPos = playerTransform.position;
        targetPos.y += playerHeight;
        cameraTransform.LookAt(targetPos);
    }
}

public abstract class TPCFollow : TPCBase
{
    public TPCFollow(Transform camera, Transform player) : base(camera, player)
    {
        Vector3 forward = cameraTransform.rotation * Vector3.forward;
        Vector3 right = cameraTransform.rotation * Vector3.right;
        Vector3 up = cameraTransform.rotation * Vector3.up;

        Vector3 targetPos = playerTransform.position;

        Vector3 desiredPos = targetPos + forward * GameConstants.CameraAngleOffset.z + right * GameConstants.CameraAngleOffset.x + up * GameConstants.CameraAngleOffset.y;

        Vector3 position = Vector3.Lerp(cameraTransform.position, desiredPos, Time.deltaTime * GameConstants.Damping);
        cameraTransform.position = position;
    }
    public override void Tick()
    {
        const float playerHeight = 2.0f;
        Vector3 targetPos = playerTransform.position;
        targetPos.y += playerHeight;
        cameraTransform.LookAt(targetPos);
    }
}

public class TPCFollowTrackPosition : TPCFollow
{
    public TPCFollowTrackPosition(Transform cameraTransform, Transform playertransform) : base(cameraTransform, playertransform)
    {

    }

    public override void Tick()
    {
        Quaternion initialRotation = Quaternion.Euler(GameConstants.CameraAngleOffset);

        cameraTransform.rotation = Quaternion.RotateTowards(cameraTransform.rotation, initialRotation, Time.deltaTime * GameConstants.Damping);
        base.Tick();
    }
}

public class TPCFollowTrackPositionAndRotation : TPCFollow
{
    public TPCFollowTrackPositionAndRotation(Transform cameraTransform, Transform playerTransform) : base(cameraTransform, playerTransform)
    {

    }

    public override void Tick()
    {
        Quaternion initialRotation = Quaternion.Euler(GameConstants.CameraAngleOffset);
        cameraTransform.rotation = Quaternion.Lerp(cameraTransform.rotation, playerTransform.rotation * initialRotation, Time.deltaTime * GameConstants.Damping);
        base.Tick();
    }
}
public class CThirdPersonCamera : MonoBehaviour
{
    public Transform cameraTransform;
    public Transform playerTransform;

    //TPCTrack myCamera;
    public enum CameraType
    {
        TRACK,
        TRACKPOSITION,
        TRACKPOSITIONROTATION,
    }

    public CameraType myCameraType = CameraType.TRACK;
    Dictionary<CameraType, TPCBase> myCameras = new Dictionary<CameraType, TPCBase>();

    public Vector3 mAngleOffset;
    public float mDamping = 1.0f;
    public Vector3 mPositionOffset;

    // Start is called before the first frame update
    void Start()
    {
        myCameras.Add(CameraType.TRACK, new TPCTrack(cameraTransform, playerTransform));
        myCameras.Add(CameraType.TRACKPOSITION, new TPCFollowTrackPosition(cameraTransform, playerTransform));
        myCameras.Add(CameraType.TRACKPOSITIONROTATION, new TPCFollowTrackPositionAndRotation(cameraTransform, playerTransform));
        GameConstants.Damping = mDamping;
        GameConstants.CameraAngleOffset = mAngleOffset;
        GameConstants.CameraPositionOffset = mPositionOffset;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        myCameras[myCameraType].Tick();
    }
}
