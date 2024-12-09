using UnityEngine;

public class ShopDrag : MonoBehaviour
{
    private Vector2 lastTouchPosition; // Bir önceki dokunma pozisyonu
    private bool isDragging = false; // Ekranın sürüklenip sürüklenmediğini takip eder

    public float sensitivity = 0.1f; // Ekran kaydırma hassasiyeti

    void Update()
    {
        // Dokunma kontrolü
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // İlk dokunma başladığında pozisyonu kaydet
                lastTouchPosition = touch.position;
                isDragging = true;
            }
            else if (touch.phase == TouchPhase.Moved && isDragging)
            {
                // Dokunma sırasında hareket ediliyorsa pozisyon farkını hesapla
                Vector2 touchDelta = touch.position - lastTouchPosition;

                // X ekseninde objeyi hareket ettir
                transform.position += new Vector3(touchDelta.x * sensitivity, 0, 0);

                // Son dokunma pozisyonunu güncelle
                lastTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                // Dokunma sona erdiğinde sürüklemeyi durdur
                isDragging = false;
            }
        }

        // Mouse desteği (opsiyonel)
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            lastTouchPosition = Input.mousePosition;
            isDragging = true;
        }
        else if (Input.GetMouseButton(0) && isDragging)
        {
            Vector2 touchDelta = (Vector2)Input.mousePosition - lastTouchPosition;
            transform.position += new Vector3(touchDelta.x * sensitivity, 0, 0);
            lastTouchPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
#endif
    }
}