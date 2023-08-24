using CodeBase.Components;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreatePlayer(Vector3 at);
        void CreateObstaclesSpawner(Vector3 at);
        ScoreCounter CreateHud();
        void CreatePointSpawner(Vector3 transformPosition);
    }
}