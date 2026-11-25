using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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

        //현재 스테이지에서 머무른 시간
        public float stageTime;

        //보스가 현재 소환되어있는지 체크
        public int bossCheck;

        //플레이어가 가진 돈
        public int money;

        float time;

        //오브젝트
        public GameObject shop;
        public GameObject enemyTower;
        public GameObject[] enemy;
        public GameObject[] boss;

        //모든 몹을 리스트화
        public List<GameObject> enemyList = new List<GameObject>();

        void Update()
        {
            time += Time.deltaTime;
            if (time > delayTime)
            {
                StartCoroutine(EnemySpawn());
                time = 0f;
            }
            //보스 스테이지를 제외한 스테이지에 머무른 시간을 체크하고 지정된 시간에 다다르면 스테이지 넘어가기
            if (bossCheck != 1)
            {
                if (stageTime >= 30f)
                {
                    foreach (GameObject obj in enemyList)
                    {
                        Destroy(obj);
                    }
                    enemyList.Clear();
                    stageTime = 0f;
                    stage += 1;
                    if (stage % 3 == 0)
                    {
                        money += 10;
                        shop.SetActive(true);
                        Time.timeScale = 0f;
                    }
                    else
                    {
                        if (stage % 3 == 1)
                        {
                            money += 100;
                        }
                        else
                        {
                            money += 10;
                        }
                    }
                }
                else
                {
                    stageTime += Time.deltaTime;
                }
            }
        }

        IEnumerator EnemySpawn()
        {
            yield return new WaitForSeconds(delayTime);
            {
                //보스 스테이지를 제외한 모든 스테이지에서 몹의 갯수가 정해진 갯수보다 작을때 실행
                if (enemyList.Count < enemyCount && stage % 3 != 0)
                {
                    GameObject enemyMob = enemy[Random.Range(0, enemy.Length)];
                    enemyList.Add(Instantiate(enemyMob, enemyTower.transform.position + new Vector3(2.6f, 0f, 0f), enemyMob.transform.rotation));
                    yield return new WaitForSeconds(delayTime);
                }
                //보스 스테이지에서 보스가 한번도 소환되지 않았으면 실행
                else if (stage % 3 == 0 && bossCheck == 0)
                {
                    bossCheck = 1;
                    int i = stage / 3;
                    GameObject bossMob = boss[i - 1];
                    Instantiate(bossMob, enemyTower.transform.position + new Vector3(2.6f, 0f, 0f), bossMob.transform.rotation);
                    yield return new WaitForSeconds(delayTime);
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
