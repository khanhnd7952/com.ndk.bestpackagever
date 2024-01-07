
using UnityEngine;

// Copy meshes from children into the parent's Mesh.
// CombineInstance stores the list of meshes.  These are combined
// and assigned to the attached Mesh.

namespace lib.ndk.Tool.CombineMesh
{
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
    public class CombineMeshExample : MonoBehaviour
    {
        void Start()
        {
            MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
            CombineInstance[] combine = new CombineInstance[meshFilters.Length];
        
            int i = 0;
            while (i < meshFilters.Length)
            {
                combine[i].mesh = meshFilters[i].sharedMesh;
                combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
                meshFilters[i].gameObject.SetActive(false);
        
                i++;
            }
            transform.GetComponent<MeshFilter>().mesh = new Mesh();
            transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
            transform.gameObject.SetActive(true);
        }
        [SerializeField] private string savePath;


        // [Button]
        // public void CreateMesh()
        // {
        //     MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        //     CombineInstance[] combine = new CombineInstance[meshFilters.Length];
        //
        //     int i = 0;
        //     while (i < meshFilters.Length)
        //     {
        //         combine[i].mesh = meshFilters[i].sharedMesh;
        //         combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
        //         //meshFilters[i].gameObject.SetActive(false);
        //
        //         i++;
        //     }
        //
        //     transform.GetComponent<MeshFilter>().mesh = new Mesh();
        //     transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
        //     transform.gameObject.SetActive(true);
        //
        //     var mesh = new Mesh();
        //     mesh.CombineMeshes(combine);
        //     AssetDatabase.CreateAsset(mesh, Application.dataPath + savePath);
        //     AssetDatabase.SaveAssets();
        // }
    }
}