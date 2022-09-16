using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public bool IsTowerExist => _towerBuilt;
    private Tower _towerBuilt;
    private Renderer _renderer;
    private Color _originalColor;
    [SerializeField] private Color _buildAvailableColor;
    [SerializeField] private Color _buildNotAvailableColor;
    
    public void Clear()
    {
        if (_towerBuilt != null)
            Destroy(_towerBuilt.gameObject);
        _towerBuilt = null;
    }
    public bool TryBuildTowerHere(string towerName)
    {
        bool isOK = false;

        if (IsTowerExist)
        {
            Debug.Log("�ش���ġ�� Ÿ���� �Ǽ��� �� �����ϴ�.");
            return false;
        }

        if (TowerAssets.instance.TryGetTower(towerName, out GameObject tower))
        {
            GameObject built = Instantiate(tower,
                                           transform.position + Vector3.up * 0.5f,
                                           Quaternion.identity,
                                           transform);
            _towerBuilt = built.GetComponent<Tower>();
            _towerBuilt.node = this;
            isOK = true;
        }
        return isOK;
    }

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _originalColor = _renderer.material.color;
    }

    private void OnMouseEnter()
    {
        if (IsTowerExist)
            _renderer.material.color = _buildNotAvailableColor;
        else
            _renderer.material.color = _buildAvailableColor;        
        NodeManager.mouseOnNode = this;
    }

    private void OnMouseExit()
    {
        _renderer.material.color = _originalColor;
    }
}
