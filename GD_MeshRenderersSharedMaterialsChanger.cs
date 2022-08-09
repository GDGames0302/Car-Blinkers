using UnityEngine;

public class GD_MeshRenderersSharedMaterialsChanger : MonoBehaviour
{
    [SerializeField]
    MeshRenderer[] meshRenderers;


    public void ChangeSharedMaterials(GD_MaterialsArrayObject materialsArrayObject)
    {
        for (int i = 0; i < meshRenderers.Length; i++)
        {
            meshRenderers[i].sharedMaterials = materialsArrayObject.materials;
        }
    }
}