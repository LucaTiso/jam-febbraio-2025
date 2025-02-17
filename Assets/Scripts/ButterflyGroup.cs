using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyGroup : MonoBehaviour
{
    [SerializeField]
    private List<EnemyButterfly> enemyButterflyList;

    [SerializeField]
    private List<ButterflyInfo> butterflyInfo;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            for(int i=0; i< butterflyInfo.Count; i++)
            {
                ButterflyInfo info= butterflyInfo[i];

                EnemyButterfly butterfly = enemyButterflyList[i];

                StartCoroutine(ActivateButterfly(info, butterfly, collision.gameObject));
            }

        }
    }

    IEnumerator ActivateButterfly(ButterflyInfo info, EnemyButterfly butterfly,GameObject player)
    {
        yield return new WaitForSeconds(info.activationDelay);
        butterfly.Activate(info.speed, info.rotationSpeed, info.changeDirectionAngle, info.direction, info.posX, info.posY, player);

    }
}
