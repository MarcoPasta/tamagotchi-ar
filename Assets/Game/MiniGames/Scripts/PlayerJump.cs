using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    void Update()
    {
        if (Input.touchCount > 0)
        {
            var charPos = transform.position;
            transform.DOJump(new Vector3(0, charPos.y + 0.04f, 1), 0.02f, 1, 0.225f);
        }
    }
}
