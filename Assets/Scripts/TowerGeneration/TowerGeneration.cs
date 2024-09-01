using System;
using System.Threading;
using UnityEngine;
using UnityObject = UnityEngine.Object;
namespace TowerGeneration
{
    public class TowerGeneration : MonoBehaviour
    {
        [SerializeField] private UnityObject towerFactory;
        [SerializeField] private Transform tower;
        private IAsyncTowerFactory TowerFactory => (IAsyncTowerFactory) towerFactory;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private void OnValidate()
        {
            if (towerFactory is not null && towerFactory is IAsyncTowerFactory == false)
            {
                towerFactory = null;
                throw new InvalidOperationException($"Tower factory should be derived from IAsyncTowerFactory{nameof(IAsyncTowerFactory)}");
            }
        }

        private void OnDisable()
        {
            _cancellationTokenSource.Cancel();
        }

        [ContextMenu(nameof(Generate))]
        public async void Generate()
        {
            await TowerFactory.CreatAsync(tower);
        }
    }
}