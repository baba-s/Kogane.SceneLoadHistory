# UniSceneLoadHistory

シーン遷移の履歴を管理するクラス

## 使用例

```cs
using Kogane;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Example : MonoBehaviour
{
    private SceneLoadHistory m_history;

    private void Awake()
    {
        // シーン遷移の履歴の保存最大件数
        var historyCount = 5;

        // シーン遷移の監視を開始
        m_history = new SceneLoadHistory( historyCount );
    }

    private void OnDestroy()
    {
        // シーン遷移の監視を終了
        m_history.Dispose();
    }

    private void Update()
    {
        if ( Input.GetKeyDown( KeyCode.Alpha1 ) )
        {
            SceneManager.LoadScene( "Example1", LoadSceneMode.Additive );
        }
        if ( Input.GetKeyDown( KeyCode.Alpha2 ) )
        {
            SceneManager.LoadScene( "Example2", LoadSceneMode.Additive );
        }
        if ( Input.GetKeyDown( KeyCode.Alpha3 ) )
        {
            SceneManager.LoadScene( "Example3", LoadSceneMode.Additive );
        }
    }

    private void OnGUI()
    {
        // シーン遷移の履歴を表示
        foreach ( var x in m_history )
        {
            GUILayout.Label( $"{x.Path},{x.LoadSceneMode}" );
        }
    }
}
```
