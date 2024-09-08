using System;
using System.Diagnostics;
using UnityEngine;

namespace ArchipelagoRandomizer
{
    public class GPS
    {
        private static readonly TimeSpan updateInterval = TimeSpan.FromSeconds(1);
        public static GPS Instance = new();
        private Stopwatch UpdateTimer = Stopwatch.StartNew();

        Entity player;

        GPS()
        {
            Events.OnPlayerSpawn += OnPlayerSpawn;
            Events.OnRoomChanged += OnRoomChanged;
        }

        private Vector2 GetPosition()
        {
            if (player == null)
            {
                return Vector2.zero;
            }

            return new Vector2(
                player.transform.position.x,
                player.transform.position.z
            );
        }

        private void OnPlayerSpawn(Entity player, GameObject _camera, PlayerController _controller)
        {
            this.player = player;
            UpdatePosition();
        }

        private void OnRoomChanged(Entity _entity, LevelRoom toRoom, LevelRoom _fromRoom, EntityEventsOwner.RoomEventData _data)
        {
            var levelName = toRoom.LevelRoot.LevelData.LevelName;
            APHandler.Instance.SetLevelName(levelName);
        }

        public void OnPlayerGetMoveDir(PlayerController playerController)
        {
            if (!playerController.isMoving)
            {
                return;
            }

            UpdatePosition();
        }

        public void UpdatePosition()
        {
            if (UpdateTimer.Elapsed < updateInterval)
            {
                return;
            }

            UpdateTimer.Reset();
            UpdateTimer.Start();

            APHandler.Instance.SetPosition(GetPosition());
        }
    }
}
