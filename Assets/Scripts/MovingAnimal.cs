using UnityEngine;

public class MovingAnimals : MonoBehaviour
{
    public float forceMagnitude = 0.2f; // 力の大きさ
    public float interval = 2f; // 力を加える間隔（秒）

    private Rigidbody2D rb;
    private float nextForceTime;
    private bool touchVacuum=true;

    void Start()
    {
        // Rigidbody2Dを取得
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(touchVacuum == true){
            CanMove();
        }
    }

private void CanMove(){

        if (Time.time >= nextForceTime && rb != null)
        {
            ApplyRandomDiagonalForce();
            nextForceTime = Time.time + interval; // 次の適用時間を設定
        }
}

     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("VacuumZone")) // Detect when exiting the vacuum zone
        {
            touchVacuum = false;
        }
    }

        private void ApplyRandomDiagonalForce()
    {
        // ランダムな斜め方向を決定（右上または左上）
        Vector2 forceDirection = Random.value > 0.5f ? new Vector2(1f, 1f) : new Vector2(-1f, 1f);
        forceDirection = forceDirection.normalized; // 単位ベクトルに変換

        // 力を加える
        rb.AddForce(forceDirection * forceMagnitude, ForceMode2D.Impulse);
    }

}
