using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
   private static T _instance;
   public static T Instance
   {
       get
       {
           if (_instance == null)
           {
               // Updated for Unity 6 to avoid deprecation warnings
               _instance = FindFirstObjectByType<T>();
               
               // If no instance exists, create a new one
               if (_instance == null)
               {
                   GameObject singletonObject = new GameObject(typeof(T).Name);
                   _instance = singletonObject.AddComponent<T>();
               }
           }
           return _instance;
       }
   }

   protected virtual void Awake()
   {
       // Ensure only one instance exists
       if (_instance != null && _instance != this)
       {
           Destroy(gameObject);
       }
       else
       {
           _instance = this as T;
           DontDestroyOnLoad(gameObject);
       }
   }
}
