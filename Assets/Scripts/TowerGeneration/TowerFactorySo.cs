using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System.Threading.Tasks;


namespace TowerGeneration
{
    [CreateAssetMenu(fileName = "TowerFactory", menuName = "ScriptableObjects/Tower/Factory")]
    public class TowerFactorySo : ScriptableObject, IAsyncTowerFactory

    {
        [SerializeField] private TowerSegment towerSegments;

        [Space] 
        [SerializeField] [Min(0)] private int segmentCount;
        [SerializeField] [Min(0.0f)] private float spawnTimePerSegment;

        [Space] 
        [SerializeField] private Material[] materials = Array.Empty<Material>();
        
        private int spawnTimePerSegmentMilliseconds => (int)(spawnTimePerSegment * 1000);
        
        public async Task<Tower> CreatAsync(Transform tower, CancellationToken cancellationToken)
        {
            Vector3 position = tower.position;
            var segments = new Queue<TowerSegment>(segmentCount);
            
            for (int i = 0; i < segmentCount; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                    break;
                
                TowerSegment segment = CreateSegment(tower, position, i);
                segments.Enqueue(segment);
                
                position = GetNextPositionAfter(segment.transform, position);
                
                await Task.Delay(spawnTimePerSegmentMilliseconds, cancellationToken);
            }

            return new Tower(segments);
        }
        
        private TowerSegment CreateSegment(Transform tower, Vector3 position, int numberOfInstance)
        {
            TowerSegment segment = Instantiate(towerSegments, position, tower.rotation, tower);
            
            Material material = GetSegmentMaterialBy(numberOfInstance);
            segment.SetMaterial(material);
            return segment;
        }

        private Vector3 GetNextPositionAfter(Transform segment, Vector3 currentPosition)
        {
            float segmentHigth = segment.localScale.y;
            return currentPosition + Vector3.up * segmentHigth;
        }

        private Material GetSegmentMaterialBy(int numberOfInstance)
        {
            int index = numberOfInstance % materials.Length;
            return materials[index];
        }

        

       
    }
}
