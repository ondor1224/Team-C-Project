using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Jain
{
    public class GameManager : MonoBehaviour
    {
        //생성 딜레이 시간
        public float delayTime;

        //몹 최대 생성 수
        public int enemyCount;

        //현재 스테이지
        public int stage;

        //보스가 현재 소환되어있는지 체크
        public int bossCheck;

        //오브젝트
        public GameObject enemyTower;
        public GameObject[] enemy;
        public GameObject[] boss;

        //모든 몹을 리스트화
        public List<GameObject> enemyList = new List<GameObject>();

        void Start()
        {
            StartCoroutine(EnemySpawn());
        }

        void Update()
        {

        }

        IEnumerator EnemySpawn()
        {
            yield return new WaitForSeconds(delayTime);
            while (true)
            {
                //보스 스테이지를 제외한 모든 스테이지에서 몹의 갯수가 정해진 갯수보다 작을때 실행
                if (enemyList.Count <= enemyCount && stage % 5 != 0)
                {
                    for (int i = 0; i < enemyCount; i++)
                    {
                        GameObject enemyMob = enemy[Random.Range(0, enemy.Length)];
                        enemyList.Add(Instantiate(enemyMob, enemyTower.transform.position + new Vector3(2.6f, 0f, 0f), enemyTower.transform.rotation));
                        yield return new WaitForSeconds(delayTime);
                    }
                }
                //보스 스테이지에서 보스가 한번도 소환되지 않았으면 실행
                else if (stage % 5 == 0 && bossCheck == 0)
                {
                    GameObject bossMob = boss[Random.Range(0, boss.Length)];
                    Instantiate(bossMob, enemyTower.transform.position + new Vector3(2.6f, 0f, 0f), enemyTower.transform.rotation);
                    yield return new WaitForSeconds(delayTime);
                    bossCheck = 1;
                }
                //모든 조건을 충족하지 않을때 실행
                else
                {
                    for (int i = 0; i < enemyCount; i++)
                    {
                        if (enemyList[i] == null)
                        {
                            enemyList.RemoveAt(i);
                        }
                    }
                }
            }
        }
    }
}
