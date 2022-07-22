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
            //Instantiate(bulletPrefab, firepoint); // 생성된 게임오브젝트를 해당 transform에 종속시킴
            Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        }
    }
}
