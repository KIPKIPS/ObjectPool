using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Init() {
        StartCoroutine(ReturnToPool());
    }

    IEnumerator ReturnToPool() {
        yield return new WaitForSeconds(2f);
        //5秒之后调用该方法
        //将对象放回池中
        ObjectPoolManager.instance.Return(this.gameObject);
    }
}
