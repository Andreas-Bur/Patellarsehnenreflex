using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertRueckenmarkCam : MonoBehaviour {

    public static Camera cam;
	// Use this for initialization
	void Start () {
        cam = gameObject.GetComponent<Camera>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnPreCull()
    {
        cam.ResetWorldToCameraMatrix();
        cam.ResetProjectionMatrix();
        cam.projectionMatrix *= Matrix4x4.Scale(new Vector3(Kontrollskript.right ? 1 : -1, 1, 1));
    }

    private void OnPreRender()
    {
        GL.invertCulling = !Kontrollskript.right;
    }

    private void OnPostRender()
    {
        GL.invertCulling = false;
    }  
}
