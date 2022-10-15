using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace Kogane
{
    public sealed class SceneLoadHistory
        : IDisposable,
          IEnumerable<SceneLoadHistoryData>,
          IReadOnlyList<SceneLoadHistoryData>
    {
        private readonly int                        m_max;
        private readonly List<SceneLoadHistoryData> m_list;

        public int Count => m_list.Count;

        public SceneLoadHistoryData this[ int index ] => m_list[ index ];

        public SceneLoadHistory() : this( 100 )
        {
        }

        public SceneLoadHistory( int max )
        {
            m_max  = max;
            m_list = new( max );

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded( Scene scene, LoadSceneMode mode )
        {
            var data = new SceneLoadHistoryData( scene, mode );
            m_list.Add( data );

            if ( m_list.Count <= m_max ) return;

            m_list.RemoveAt( 0 );
        }

        public void Clear()
        {
            m_list.Clear();
        }

        public void Dispose()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;

            Clear();
        }

        public IEnumerator<SceneLoadHistoryData> GetEnumerator()
        {
            foreach ( var x in m_list )
            {
                yield return x;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}