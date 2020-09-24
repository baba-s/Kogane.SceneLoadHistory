using UnityEngine.SceneManagement;

namespace Kogane
{
	public sealed class SceneLoadHistoryData
	{
		private readonly Scene         m_scene;
		private readonly LoadSceneMode m_mode;

		public string        Path          => m_scene.path;
		public string        Name          => m_scene.name;
		public int           BuildIndex    => m_scene.buildIndex;
		public LoadSceneMode LoadSceneMode => m_mode;

		internal SceneLoadHistoryData( Scene scene, LoadSceneMode mode )
		{
			m_scene = scene;
			m_mode  = mode;
		}
	}
}