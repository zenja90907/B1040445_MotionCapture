using UnityEngine;

public class Lady : MonoBehaviour
{
    private Animator ani;     //動畫元件
    private Rigidbody rig;    //剛體元件

    [Header("速度"), Range(0f, 80f)]
    public float speed = 1.5f;

    private string parRun = "跑步開關";
    private string parAtk = "攻擊觸發";
    private string parDam = "受傷觸發";
    private string parJump = "跳躍開關";
    private string parDead= "死亡開關";

    private void Start()
    {
        ani = GetComponent<Animator>(); //動畫元件欄位-取得元件<泛型>();
        rig = GetComponent<Rigidbody>();
    }
    //FixedUpdate 1格執行0.002秒
    private void FixedUpdate()
    {
        Walk();
        Attack();
        Jump();
    }

    //定義方法
    //修飾詞 傳回類型 方法名稱(參數){敘述}
    //void無回傳

    ///<summary>
    ///角色的走路功能
    ///</summary>
    private void Walk()
    {
        // 動畫:跑步-按下前後時true
        ani.SetBool(parRun, Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal")!=0);
        //rig.AddForce(0,0, Input.GetAxisRaw("Vertical") * speed);               //以世界座標移動
        rig.AddForce(transform.forward * Input.GetAxisRaw("Vertical") * speed);  //以區域座標移動
    }

    ///<summary>
    ///攻擊
    ///</summary>
    private void Attack()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        ani.SetTrigger(parAtk);
    }

    ///<summary>
    ///跳躍
    ///</summary>
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ani.SetTrigger(parJump);
    }

    ///<summary>
    ///受傷
    ///</summary>
    private void Hurt()
    {
        ani.SetTrigger(parDam);
    }

    ///<summary>
    ///死亡
    ///</summary>
    private void Dead()
    {
        ani.SetBool(parDead, true);
    }
    
}
