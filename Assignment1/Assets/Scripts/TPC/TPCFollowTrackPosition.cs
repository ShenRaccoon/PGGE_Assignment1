using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPC
{
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
}
