using UnityEngine;

namespace CodeBase.Infrastructure.Services.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreatePlayer(Vector3 at);
        void CreatingObstaclesSpawner(Vector3 at);
        ScoreCounter CreateHud();
    }
}