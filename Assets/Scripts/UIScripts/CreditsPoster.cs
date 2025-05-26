using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CreditsPoster : MonoBehaviour
{
    [SerializeField] public UnityEvent OpenCredits;
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private List<Material> _defaultMat;
    [SerializeField] private List<Material> _mat;

    private void OnMouseOver()
    {
        _meshRenderer.SetMaterials(_mat);
        if (Input.GetMouseButtonDown(0))
        {
            OpenCredits.Invoke();
            _meshRenderer.SetMaterials(_defaultMat);
        }
    }

    private void OnMouseExit()
    {
        _meshRenderer.SetMaterials(_defaultMat);
    }
}
