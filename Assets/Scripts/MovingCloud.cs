using UnityEngine;

public class MovingCloud : MonoBehaviour
{
    public float speed = 2f; // 移動速度
    public float distance = 3f; // 移動範囲（左右にどれくらい動くか）

    private float startX; // 初期位置のX座標
    private int direction = 1; // 移動方向（1:右、-1:左）
    private bool touchVacuum=true;

    void Start()
    {
;
        // 初期位置を保存
        startX = transform.position.x;
    }

    void FixedUpdate()
    {
        if(touchVacuum == true){
            CanMove();
        }
    }

private void CanMove(){

        // 現在の位置を計算
        float newX = transform.position.x + direction * speed * Time.deltaTime;

        // 範囲を超えたら方向を反転
        if (Mathf.Abs(newX - startX) > distance)
        {
            direction *= -1;
            newX = Mathf.Clamp(newX, startX - distance, startX + distance);
        }

        // 新しい位置を設定
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
}

     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("VacuumZone")) // Detect when exiting the vacuum zone
        {
            touchVacuum = false;
        }
    }



}
