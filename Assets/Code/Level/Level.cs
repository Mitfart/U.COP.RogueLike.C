using System.Collections.Generic;
using Unity.VisualScripting;

namespace Level {
   public class Level {
      public int LocationNum { get; private set; }
      public int LocationID  { get; private set; }
      public int RoomID      { get; private set; }

      public Location Location => LocationsSet.Locations[LocationNum][LocationID];
      public Room     Room     { get; private set; }

      public LocationsSet       LocationsSet  { get; private set; }
      public IReadOnlyList<int> PassedRoomIDs => _passedRoomIDs;

      private readonly List<int> _passedRoomIDs;



      public Level(LocationsSet locationsSet) {
         LocationsSet   = locationsSet;
         _passedRoomIDs = new List<int>();
      }



      public void SetLocation(int locationNum, int locationID) {
         if (locationID == LocationNum) return;

         LocationNum = locationNum;
         LocationID  = locationID;

         _passedRoomIDs.Clear();
      }

      public void SetRoom(int roomID, Room room) {
         RoomID = roomID;
         Room   = room;

         _passedRoomIDs.Add(roomID);
      }



      public override string ToString() => $"<color={Location.Color.ToHexString()}>{Location.Title}</color> {LocationNum}:{RoomID}";
   }
}