using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class Badge_Repository
    {
        //this is my fake database
        //i'm calling this database _badgeDictionary
        //this dictionary is a keyvalue pair of type int(key), Badge(value)
        //idea is that the int value(key) will point to a specific Badge(value)
        //the new keyword on the right side of = means that I am taking RAM and I am assigning 
        //a piece of that RAM for a dictionary of type int Badge 
        //_badgeDictionary has an address via the new keyword on the right side of the = 
        //anytime i use _badgeDictionary I am pointing to that address in RAM(cpu memory)
        private readonly Dictionary<int, Badge> _badgeDictionary = new Dictionary<int, Badge>();
        private int _count = 0;
        //Create
        public bool AddBadgeToDatabase(Badge badge)
        {
            if (badge is null)
            {
                return false;
            }
            //increment _count by one
            _count++;
            //
            badge.ID = _count;
            _badgeDictionary.Add(badge.ID, badge);
            return true;
        }
        public Dictionary<int, Badge> GetBadges()
        {
            return _badgeDictionary;
        }
        public Badge GetBadgeByKey (int userKeyInput)
        {
            foreach (KeyValuePair<int, Badge> badge in _badgeDictionary)
            {
                if (badge.Key == userKeyInput)
                {
                    return badge.Value;
                }
            }
            return null;
        }

    public bool UpdateBadgeData(int userKeyInput, Badge newBadgeData)
        {
            var oldBadgeData = GetBadgeByKey(userKeyInput);
            if(oldBadgeData != null)
            {
                oldBadgeData.Name = newBadgeData.Name;
                oldBadgeData.Doors = newBadgeData.Doors;
                return true;
            }
            return false;
        }
        public bool DeleteBadgeData (int userKeyInput)
        {
            var oldBadgeData = GetBadgeByKey(userKeyInput);
            if (oldBadgeData !=null)
            {
                _badgeDictionary.Remove(oldBadgeData.ID);
                return true;
            }
            return false;
        }
        //the plan is to ask the user for a specific key
        //also we want to retrieve the door name that the u er wants to delete
        public bool RemoveDoor(int userKeyInput, string doorName)
        {
            //user helper method
            //the method below will give me back a badge
            var badge  = GetBadgeByKey(userKeyInput);
            //check to see if badgeForDeletion actually exists 
            if (badge != null)
            {
                //on every badge there is a list/collection of type string that represtents every door on the badge
                //we need to loop through the list of doors on this particiular badge 
                foreach (string door in badge.Doors)
                {
                    if (door == doorName)
                    {
                        badge.Doors.Remove(door);
                        return true;
                    }
                }
            }
            return false;
        }
        public bool AddDoor (int userKeyInput, string doorName)
        {
            var badge = GetBadgeByKey(userKeyInput);
            if (badge !=null)
            {
                badge.Doors.Add(doorName);
                return true;
            }
            return false;
        }
        public bool RemoveAllDoors (int userKeyInput)
        {
            var badge = GetBadgeByKey (userKeyInput);
            if (badge !=null)
            {
                badge.Doors = null;
                return true;
            }
            return false;
        }

    public object GetDoors()
    {
        throw new NotImplementedException();
    }
}
