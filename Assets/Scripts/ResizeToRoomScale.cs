using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ResizeToRoomScale : MonoBehaviour
{
    public float meshWidth = 2;
    public float meshHeight = 2;

   // This will resize the given object to match the player play area
    void Start()
    {
        var rect = new HmdQuad_t();
        if (SteamVR_PlayArea.GetBounds(SteamVR_PlayArea.Size.Calibrated, ref rect))
        {
            var corners = new HmdVector3_t[] { rect.vCorners0, rect.vCorners1, rect.vCorners2, rect.vCorners3 };
            Vector3 scale = transform.localScale;
            var width = Mathf.Abs(corners[0].v0 - corners[1].v0) / meshWidth * scale.x;
            var length = Mathf.Abs(corners[0].v2 - corners[3].v2) / meshHeight * scale.y;
            scale.Set(length, width, scale.z);
            transform.localScale = scale;                    
        }
    }
}
