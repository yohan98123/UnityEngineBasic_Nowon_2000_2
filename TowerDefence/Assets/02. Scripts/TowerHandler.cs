using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHandler : MonoBehaviour
{
    public static TowerHandler instance;
    public bool isSelected => _ghostTower;   
    private GameObject _ghostTower;
    private TowerInfo _selectedTowerInfo;
    private Camera _camera;
    private Ray _ray;
    private RaycastHit _hit;
    [SerializeField] private LayerMask _nodeLayer;

    public void SetTower(TowerInfo towerInfo)
    {
        _selectedTowerInfo = towerInfo;
        gameObject.SetActive(true);

        // �̹� �ٸ� Ÿ���� ���õǾ� �ִٸ�
        if (_ghostTower != null)
            Destroy(_ghostTower);

        // ��Ʈ Ÿ�� ���� ����
        if (TowerAssets.instance.TryGetGhostTower(_selectedTowerInfo.name, out GameObject ghostTowerPrefab))
        {
            _ghostTower = Instantiate(ghostTowerPrefab);
        }
        else
        {
            throw new System.Exception("��Ʈ Ÿ�� ���� ����");
        }
    }

    public void Clear()
    {
        _ghostTower = null;
        _selectedTowerInfo = null;
        gameObject.SetActive(false);
    }

    public void SetGhostTowerPosition(Vector3 targetPos)
    {
        _ghostTower.transform.position = targetPos;
    }

    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        instance = this;

        _camera = Camera.main;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_ghostTower == null)
            return;

        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(_ray, out _hit, Mathf.Infinity, _nodeLayer))
        {
            SetGhostTowerPosition(_hit.collider.transform.position);
            _ghostTower.SetActive(true);
        }
        else
        {
            _ghostTower.SetActive(false);
        }
    }
}
