using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firepoint;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Instantiate(bulletPrefab, firepoint); // ������ ���ӿ�����Ʈ�� �ش� transform�� ���ӽ�Ŵ
            Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        }
    }
}
