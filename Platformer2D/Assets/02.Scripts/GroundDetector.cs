using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public bool isDetected
    {
        get => _detectedGround != null ? true : false;
    }

    public bool isIgnoringGround { get; private set; }
    public bool isGroundChanged
    {
        get => _previousGround != _lastGround? true : false;
    }

    private CapsuleCollider2D _col;
    private Vector2 _size;
    private Vector2 _center;

    private Collider2D _detectedGround;
    private Collider2D _lastGround;
    private Collider2D _ignoringGround;
    private Collider2D _previousGround;

    [SerializeField] private LayerMask _targetLayer;

    public void IgnoreLastGround()
    {
        _ignoringGround = _lastGround;
        if (_ignoringGround != null)
            StartCoroutine(E_IgnoreGroundUntilPassedIt(_ignoringGround));
    }
    private void Awake()
    {
        _col = GetComponent<CapsuleCollider2D>();
        _size.x = _col.size.x / 2;
        _size.y = 0.005f;
    }

    private void FixedUpdate()
    {
        _center.x = transform.position.x - _col.offset.x;
        _center.y = transform.position.y - _size.y / 2 - 0.01f;
        _detectedGround = Physics2D.OverlapBox(_center, _size, 0, _targetLayer);
        if (_detectedGround != null)
        {
            _lastGround = _detectedGround;
        }
        else
        {
            _previousGround = _lastGround;
        }
    }

    IEnumerator E_IgnoreGroundUntilPassedIt(Collider2D targetCol)
    {
        isIgnoringGround = true;
        Physics2D.IgnoreCollision(_col, targetCol, true);
        float targetColCenter = targetCol.transform.position.y + targetCol.offset.y;

        //�÷��̾ Ÿ�� �׶��带 ���������� üũ
        yield return new WaitUntil(() =>
        {
            return _col.transform.position.y < targetColCenter - targetCol.offset.y;
        });
        
        yield return new WaitUntil(() =>
        {
            bool isPassed = false;
            if (targetCol != null)
            {
                targetColCenter = targetCol.transform.position.y + targetCol.offset.y;

                //�ö󰡸鼭 ���, �������鼭 ��� üũ
                if (_col.transform.position.y > targetColCenter + _col.size.y +_size.y ||
                    _col.transform.position.y + _col.size.y < targetColCenter - _col.size.y - _size.y)
                {
                    isPassed = true;
                }
            }
            else
            {
                isPassed = true;
            }
            return isPassed;

        });

        Physics2D.IgnoreCollision(_col, targetCol, false);
        isIgnoringGround = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(_center, _size);
    }
}