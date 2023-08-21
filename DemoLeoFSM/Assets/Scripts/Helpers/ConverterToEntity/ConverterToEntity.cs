using Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace Helpers.ConverterToEntity
{
    [DisallowMultipleComponent]
    public class ConverterToEntity : MonoBehaviour
    {
        public BaseConverterComponent[] converters;
        
        [SerializeField] private bool convertOnStart;

        private IWorldService _worldService;

        [Inject]
        private void Construct(IWorldService worldService) =>
            _worldService = worldService;

        private void Start()
        {
            if (convertOnStart)
                Convert();
        }

        public int Convert()
        {
            int entity = _worldService.DefaultWorld.NewEntity();

            foreach (BaseConverterComponent converter in converters)
                converter.ConvertToEntity(_worldService.DefaultWorld, entity);

            return entity;
        }
    }
}