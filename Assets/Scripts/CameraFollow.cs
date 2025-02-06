using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    //let camera follow target
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float lerpSpeed = 1.0f;

        private Vector3 offset;

        private Vector3 targetPos;

        private float startCameraPosZ;

        private void Start()
        {
            startCameraPosZ = transform.position.z;
            if (target == null) return;

            offset = transform.position - target.position;
        }

        private void FixedUpdate()
        {
            if (target == null) return;

            targetPos = target.position + offset;
            targetPos.z = startCameraPosZ;
            transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
        }

    }
}
