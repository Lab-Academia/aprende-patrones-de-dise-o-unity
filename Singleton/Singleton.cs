using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Es un patron de diseño que garantiza que exista solo una instancia de esta clase.
/// Se puede acceder globalmente a la instancia usando Singleton.Instance;
/// La clase genera y destruye su propia instancia.
/// Poco eficaz para Testing. La unica manera de ver como esta siendo referenciada la instancia es 
/// recorriendo el codigo.
/// </summary>
public class Singleton : MonoBehaviour
{
    private static Singleton instance;
    public static Singleton Instance { get => instance; private set => instance = value; }

    void Awake()
    {
        if (!Instance)
            Instance = this;
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }
}

/// <summary>
/// Singleton generico de Tipo T.
/// </summary>
/// <typeparam name="T">Tipo del Singleton a Crear</typeparam>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance = default(T);
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    var singleton = new GameObject();
                    singleton.name = typeof(T).ToString();
                    instance = singleton.AddComponent<T>();
                }
            }
            return instance;
        }
    }
    public virtual void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = GetComponent<T>();

        DontDestroyOnLoad(this.gameObject);

        if (instance == null)
            return;
    }
}
