using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
    private Vector3 pos;
    Vector3 bulletFirePos;
    Vector3 boomFirePos;
    // Start is called before the first frame update
    void Start() {
        pos = this.transform.position;
        bulletFirePos = new Vector3(0,0,1);
        boomFirePos = new Vector3(1, 0, 0);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            //得到对象
            GameObject bullet = ObjectPoolManager.instance.Get("Bullet", bulletFirePos, Quaternion.identity);
            //添加力
            bullet.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,500));
        }

        if (Input.GetMouseButtonDown(1)) {
            //得到对象
            GameObject boom = ObjectPoolManager.instance.Get("Boom", boomFirePos, Quaternion.identity);
            //添加力
            boom.GetComponent<Rigidbody>().AddForce(new Vector3(500, 0, 0));
        }
    }
}
