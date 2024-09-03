using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace TowerGeneration
{
    public interface IAsyncTowerFactory
    {
        Task<Tower> CreatAsync(Transform tower, CancellationToken cancellationToken); 
    }
}