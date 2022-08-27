using UnityEngine.SceneManagement;

namespace Kogane
{
    public sealed class SceneLoadHistoryData
    {
        public string        Path          { get; }
        public string        Name          { get; }
        public int           BuildIndex    { get; }
        public LoadSceneMode LoadSceneMode { get; }

        internal SceneLoadHistoryData( Scene scene, LoadSceneMode mode )
        {
            Path          = scene.path;
            Name          = scene.name;
            BuildIndex    = scene.buildIndex;
            LoadSceneMode = mode;
        }
    }
}