using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour {
    public static ObjectPoolManager instance;
    public Dictionary<string, Stack> pool = new Dictionary<string, Stack>();//对象池,存放对象的名称及存放已经生成的对象对应的栈

    void Awake() {
        instance = this;
    }

    void Start() {
    }

    void Update() {

    }
    /// <summary>
    /// 提供了一个从对象池中获取gameObject和放回gameObject的方法 当需要获取一个物体时
    /// 会首先通过这个物体的名字进行一次判断，如果字典中已经存在了存放该名字的栈且栈内元素的个数大于0时
    /// 直接从栈内Pop出该gameObject 如果没有或者栈已经空了的情况下 则使用Instantiate来创建一个新的gameObject
    /// </summary>
    /// <param name="prefabName">指定需要加载的对象名称</param>
    /// <param name="position">位置</param>
    /// <param name="rotation">旋转角度</param>
    /// <returns></returns>
    public GameObject Get(string prefabName, Vector3 position, Quaternion rotation) {
        Debug.Log(prefabName);
        string key = prefabName + "(Clone)";
        GameObject getItem;
        //若池子存在子弹对象并且子弹对象的数量 大于0
        if (pool.ContainsKey(key)&& pool[key].Count > 0) {
            Stack list = pool[key];
            getItem = list.Pop() as GameObject;//出栈,弹出对象供方法调用者使用
            getItem.SetActive(true);//激活对象,在场景中显示
            //设置位置旋转的信息
            getItem.transform.position = position;
            getItem.transform.rotation = rotation;
        }
        //池子中不存在该对象,实例化一个
        else {
            getItem = Instantiate(Resources.Load(prefabName), position, rotation) as GameObject;
        }
        if (getItem != null) {
            getItem.GetComponent<Destroy>().Init();   // 初始化相关状态return getItem;
        }
        return getItem;
    }
    //将对象放回池子中
    public void Return(GameObject go) {
        string key = go.name;
        if (pool.ContainsKey(key)) {
            pool[key].Push(go);
            Debug.Log("存在");
        }
        //池中不包含对象信息则添加对象信息,新建存储栈
        else {
            Debug.Log("不存在");
            pool.Add(key, new Stack());
            pool[key].Push(go);
        }
        go.gameObject.SetActive(false);
    }
}
