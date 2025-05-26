using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] _meshRenderer;
    [SerializeField] private List<Material> _defaultMat;
    [SerializeField] private List<Material> _mat;

    private void OnMouseOver()
    {
        for (int i = 0; i < _meshRenderer.Length; i++)
        {
            _meshRenderer[i].SetMaterials(_mat);
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < _meshRenderer.Length; i++)
            {
                _meshRenderer[i].SetMaterials(_defaultMat);
            }
            Debug.Log("Bye bye bye!");
            Application.Quit();
        }
    }

    private void OnMouseExit()
    {
        for (int i = 0; i < _meshRenderer.Length; i++)
        {
            _meshRenderer[i].SetMaterials(_defaultMat);
        }
    }
}
