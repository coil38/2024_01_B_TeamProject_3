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
                if (selectedObject != null)
                {
                    // ������ ���õ� ���� Ÿ�� �̹����� ��Ȱ��ȭ
                    Transform previousCanvas = selectedObject.transform.Find("Canvas");
                    if (previousCanvas != null)
                    {
                        Transform previousTargetImage = previousCanvas.Find("TargetImage");
                        if (previousTargetImage != null)
                        {
                            previousTargetImage.gameObject.SetActive(false);
                        }
                    }
                }

                selectedObject = hit.transform.gameObject;

                if (selectedObject.tag == "Enemy")
                {
                    Transform canvas = selectedObject.transform.Find("Canvas");
                    if (canvas != null)
                    {
                        Transform targetImage = canvas.Find("TargetImage");
                        if (targetImage != null)
                        {
                            targetImage.gameObject.SetActive(true);
                            Debug.Log("������ �� : " + selectedObject.name);
                        }
                    }

                    BulletSpawner bulletSpawner = FindObjectOfType<BulletSpawner>();
                    if (bulletSpawner != null)
                    {
                        bulletSpawner.SetTarget(selectedObject);
                    }
                }
            }
        }
    }
}