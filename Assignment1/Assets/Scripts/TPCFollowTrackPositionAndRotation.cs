using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TPC
{
    public class TPCFollowTrackPositionAndRotation : TPCFollow
    {
        public TPCFollowTrackPositionAndRotation(Transform cameraTransform, Transform playerTransform) : base(cameraTransform, playerTransform)
        {

        }

        public override void Tick()
        {
            Quaternion initialRotation = Quaternion.Euler(GameConstants.CameraAngleOffset);
            cameraTransform.rotation = Quaternion.Lerp(cameraTransform.rotation, playerTransform.rotation * initialRotation, Time.deltaTime * GameConstants.Damping);
            RepositionCamera();
            base.Tick();
        }
    }

}
