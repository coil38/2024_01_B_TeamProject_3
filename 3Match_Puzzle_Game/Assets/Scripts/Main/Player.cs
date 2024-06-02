using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private GameObject selectedObject;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

            if (hit.collider != null)
            {
                selectedObject = hit.transform.gameObject;
                Debug.Log("선택한 적 : " + selectedObject.name);

                BulletSpawner bulletSpawner = FindObjectOfType<BulletSpawner>();
                if (bulletSpawner != null)
                {
                    bulletSpawner.SetTarget(selectedObject);
                }
            }
        }
    }
}