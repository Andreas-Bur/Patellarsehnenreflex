using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Namensausgabe : MonoBehaviour {

    public Camera main;
    private Ray ray;
    bool mousePressed = false;
    GameObject modell_obj;
    SkinnedMeshRenderer modell_mesh_renderer;

    void Start () {
        modell_obj = GameObject.Find("Modell_v3.1_FBX/modell_b1Mesh");
        modell_mesh_renderer = modell_obj.GetComponent<SkinnedMeshRenderer>();
    } 


    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            updateColliders();
            checkCollision();
        }

        
    }

    void updateColliders()
    {
        Debug.Log("updateColliders");

        modell_obj.GetComponent<MeshCollider>().sharedMesh = null;
        modell_obj.GetComponent<MeshCollider>().sharedMesh = modell_obj.GetComponent<MeshFilter>().mesh;
        //modell_mesh_renderer.BakeMesh(modell_obj.GetComponent<MeshCollider>().sharedMesh);
    }

    void checkCollision()
    {
        ray = main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray);
        int i = 0;
        //Debug.Log(""+hits.Length);
        while (i < hits.Length)
        {
            RaycastHit hit = hits[i];
            Debug.Log(hit.collider.gameObject.name);
            i++;
        }
        /*RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
            if (hit.rigidbody != null)
                Debug.Log(""+hit.rigidbody.name);*/
    }
}
