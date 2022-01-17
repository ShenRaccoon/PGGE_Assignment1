using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TPC
{
    public class TPCTrack : TPCBase
    {
        public TPCTrack(Transform camera, Transform player) : base(camera, player)
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
}
