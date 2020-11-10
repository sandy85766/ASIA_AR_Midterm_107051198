
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("男1")]
    public Transform boy;
    [Header("男2")]
    public Transform man;
    [Header("虛擬搖桿")]
    public FixedJoystick joystick;
    [Header("旋轉速度"), Range(0.1f, 20f)]
    public float turn = 2.5f;
    [Header("縮放"), Range(0f, 5f)]
    public float size = 0.3f;
    [Header("男1動畫元件")]
    public Animator aniboy;
    [Header("男2動畫元件")]
    public Animator animan;


    private void Start()
    {
        print("開始事件執行中");
    }

    private void Update()
    {
        print("更新事件");
        print(joystick.Vertical);
        boy.Rotate(0, joystick.Horizontal * turn, 0);
        man.Rotate(0, joystick.Horizontal * turn, 0);

        boy.localScale += new Vector3(1, 1, 1) * joystick.Vertical * size;
        man.localScale += new Vector3(1, 1, 1) * joystick.Vertical * size;

        boy.localScale = new Vector3(1, 1, 1) * Mathf.Clamp(boy.localScale.x, 0.5f, 3.5f);
        man.localScale = new Vector3(0.3f, 0.3f, 0.3f) * Mathf.Clamp(boy.localScale.x, 0.5f, 3.5f);
    }

    public void PlayAnimation(string aniName)
    {
        print(aniName);
        aniboy.SetTrigger(aniName);
        animan.SetTrigger(aniName);

    }
}
