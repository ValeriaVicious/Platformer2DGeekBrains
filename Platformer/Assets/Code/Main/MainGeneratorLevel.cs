using UnityEngine;


namespace PlatformerGeekBrains.Level
{
    public sealed class MainGeneratorLevel : MonoBehaviour
    {
        #region Fields

        [SerializeField] private GeneratorLevelView _generatorLevelView;
        private GeneratorLevelController _generatorLevelController;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _generatorLevelController = new GeneratorLevelController(_generatorLevelView);
            _generatorLevelController.Awake();
        }

        #endregion
    }
}
