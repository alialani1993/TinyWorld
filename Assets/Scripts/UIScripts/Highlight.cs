using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Highlight : MonoBehaviour
{
    [SerializeField] public UnityEvent StartGame;
    [SerializeField] private SkinnedMeshRenderer _skinneMeshRenderer;
    [SerializeField] private List<Material> _defaultMat;
    [SerializeField] private List<Material> _mat;

    private void Awake()
    {
        Cursor.lockState = UnityEngine.CursorLockMode.None;
    }
    private void OnMouseOver()
    {
        _skinneMeshRenderer.SetMaterials(_mat);
        if (Input.GetMouseButtonDown(0))
        {
            StartGame.Invoke();
            _skinneMeshRenderer.SetMaterials(_defaultMat);
            Destroy(this);
        }
    }

    private void OnMouseExit()
    {
        _skinneMeshRenderer.SetMaterials(_defaultMat);
    }
}
