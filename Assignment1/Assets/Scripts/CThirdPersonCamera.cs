using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public float mDamping = 0.1f;
    public Vector3 mPositionOffset;

    // Start is called before the first frame update
    void Start()
    {
        myCameras.Add(CameraType.TRACK, new TPC.TPCTrack(cameraTransform, playerTransform));
        myCameras.Add(CameraType.TRACKPOSITION, new TPC.TPCFollowTrackPosition(cameraTransform, playerTransform));
        myCameras.Add(CameraType.TRACKPOSITIONROTATION, new TPC.TPCFollowTrackPositionAndRotation(cameraTransform, playerTransform));
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
