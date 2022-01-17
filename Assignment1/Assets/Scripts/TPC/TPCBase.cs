using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


