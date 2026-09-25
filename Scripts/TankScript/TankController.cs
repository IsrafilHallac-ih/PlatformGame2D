using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public enum tankStatus {fire, receiveBlow,doMove }
    public tankStatus validState;

    [SerializeField]
    Transform TankObject;
    public Animator anim;

    [Header("MOVE")]
    public float MoveSpeed;
    public Transform TankLeftTarget, TankRightTarget;
    bool directionRight;

    [Header("GUN")]
    public GameObject bullet;
    public Transform bulletCentre;
    public float bulletDuration;
    float bulletCount;

    [Header("DAMAGE")]
    public float damageDuration;
    float damageCount;

    public GameObject TankCrushingBox;


    private void Start()
    {
        validState = tankStatus.fire;
    }

    private void Update()
    {
        switch (validState)
        {
            case tankStatus.fire:
                bulletCount -= Time.deltaTime;
                if (bulletCount<=0)
                {
                    bulletCount = bulletDuration;
                    var newBullet = Instantiate(bullet, bulletCentre.position, bulletCentre.rotation);
                    newBullet.transform.localScale = TankObject.localScale;
                }

                break;
            case tankStatus.receiveBlow:
                if (damageCount>0)
                {
                    damageCount -= Time.deltaTime;
                    if (damageCount<=0)
                    {
                        validState = tankStatus.receiveBlow;
                    }
                }
                break;
            case tankStatus.doMove:
                if (directionRight)
                {
                    TankObject.position += new Vector3(MoveSpeed * Time.deltaTime, 0f, 0f);
                    if (TankObject.position.x>TankRightTarget.position.x)
                    {
                        TankObject.localScale = Vector3.one;

                        directionRight = false;
                        MoveStopFNC();
                    }
                }
                else
                {
                    TankObject.position -= new Vector3(MoveSpeed * Time.deltaTime, 0f, 0f);
                    if (TankObject.position.x < TankLeftTarget.position.x)
                    {
                        TankObject.localScale = new Vector3(-1, 1, 1);

                        directionRight = true;
                        MoveStopFNC();
                    }
                }
                break;
                
        }

                if (Input.GetKeyDown(KeyCode.R))
                {
                    ReceiveBlowFNC();
                }
        
    }

    public void ReceiveBlowFNC()
    {
        TankCrushingBox.SetActive(true);
        validState = tankStatus.receiveBlow;
        damageCount = damageDuration;

        anim.SetTrigger("Vur");
    }
    
    public void MoveStopFNC()
    {
        validState = tankStatus.fire;
        bulletCount = bulletDuration;
        anim.SetTrigger("HareketDurdur");
    }
}
