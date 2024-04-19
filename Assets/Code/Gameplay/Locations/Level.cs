using System.Collections.Generic;
using Unity.VisualScripting;

namespace Envirenment.Locations {
   public class Level {
      private readonly List<int> _passedRoomIDs;

      public int LocationNum { get; private set; }
      public int LocationID  { get; private set; }
      public int RoomID      { get; private set; }

      public IRoom        Room         { get; private set; }
      public LocationsSet LocationsSet { get; }

      public IReadOnlyList<int> PassedRoomIDs => _passedRoomIDs;
      public Location           Location      => LocationsSet.Locations[LocationNum]/*[LocationID]*/;



      public Level(LocationsSet locationsSet) {
         LocationsSet   = locationsSet;
         _passedRoomIDs = new List<int>();
      }



      public void SetLocation(int locationNum, int locationID) {
         if (locationID == LocationNum)
            return;

         LocationNum = locationNum;
         LocationID  = locationID;

         _passedRoomIDs.Clear();
      }

      public void SetRoom(int roomID, IRoom room) {
         RoomID = roomID;
         Room   = room;

         _passedRoomIDs.Add(roomID);
      }



      public override string ToString() {
         return $"<color={Location.Color.ToHexString()}>{Location.Title}</color> {LocationNum}:{RoomID}";
      }
   }
}