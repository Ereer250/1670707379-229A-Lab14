using UnityEngine;
using UnityEngine.InputSystem; // ใช้ Input แบบใหม่ต้องเปิดในแพ็กเกจ

public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;   // จุดที่ยิงออก
    [SerializeField] private GameObject target;      // เป้าเล็ง / Crosshair
    [SerializeField] private GameObject bulletPrefab;

    void Start()
    {

    }

    void Update()
    {
        Vector2 screenPos = Mouse.current.position.ReadValue(); // อ่านตำแหน่งเมาส์ และเก็บไว้ที่ screenPos

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            // ยิง Ray เมื่อคลิกเมาส์ซ้าย โดยคำนวณจาก screenPos
            Ray ray = Camera.main.ScreenPointToRay(screenPos);
            Debug.DrawRay(ray.origin, ray.direction * 5f, Color.red, 5f);

            // รับจุดที่ Ray ชนกับวัตถุ
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            // ถ้า Ray ชน Collider
            if (hit.collider != null)
            {
                target.transform.position = new Vector2(hit.point.x, hit.point.y);
                Debug.Log($"Hit {hit.collider.gameObject.name}"); // ปริ้นชื่อวัตถุที่โดน
            }
        }
    }
}