using System;
using System.Threading;
using DG.Tweening;
using TweenStructures;
using UnityEngine;
using UnityObject = UnityEngine.Object;
namespace TowerGeneration
{
    public class TowerGeneration : MonoBehaviour
    {
        [SerializeField] private UnityObject towerFactory;
        [SerializeField] private Transform tower;
        [SerializeField] private Vector3TweenData rotationData;
        
        
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

        private void OnDisable() =>
            _cancellationTokenSource.Cancel();
        

        [ContextMenu(nameof(Generate))]
        
        public async void Generate()
        {
            ApplayRotation(rotationData);
            await TowerFactory.CreatAsync(tower, _cancellationTokenSource.Token);
        }

        private void ApplayRotation(Vector3TweenData rotationData)
        {
            tower
                .DOBlendableLocalRotateBy(new Vector3(0, 360, 0), 1f, RotateMode.FastBeyond360)
                .SetEase(rotationData.Ease);
        }
    }
}