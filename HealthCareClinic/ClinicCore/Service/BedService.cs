using Model;
using Storages;
using System.Collections.Generic;

namespace Service
{
    public class BedService
    {
        private BedFileStorage bfs = new BedFileStorage();
        public List<Bed> AllBeds { get; set; }

        public int MaxId;

        private static BedService instance = null;
        public static BedService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BedService();
                }
                return instance;
            }
        }

        private BedService()
        {
            AllBeds = bfs.GetAll();
        }

        public void FindMaxID()
        {
            int max = 0;
            foreach (Bed bed in AllBeds)
            {
                if (max < bed.BedId)
                {
                    max = bed.BedId;
                }
            }

            MaxId = max;
        }

        public int GenerateBedID()
        {
            FindMaxID();
            ++MaxId;
            return MaxId;
        }

        public void AddBed(Bed bed)
        {
            if (bed == null)
            {
                return;
            }

            if (AllBeds == null)
            {
                AllBeds = new List<Bed>();

            }

            if (!AllBeds.Contains(bed))
            {
                bed.BedId = GenerateBedID();
                AllBeds.Add(bed);
                bfs.SaveBeds(AllBeds);

            }
        }

        public void RemoveBed(Bed bed)
        {
            if (bed == null)
            {
                return;
            }

            if (AllBeds != null)
            {
                foreach (Bed tempBed in AllBeds)
                {
                    if (bed.BedId.Equals(tempBed.BedId))
                    {
                        AllBeds.Remove(tempBed);
                        bfs.SaveBeds(AllBeds);
                        break;
                    }
                }
            }

        }

        public void UpdateBed(Bed bed)
        {
            for (int i = 0; i < AllBeds.Count; i++)
            {
                if (bed.BedId == AllBeds[i].BedId)
                {
                    AllBeds.Remove(AllBeds[i]);
                    AllBeds.Insert(i, bed);
                    bfs.SaveBeds(AllBeds);
                    return;
                }
            }
        }

        public List<Bed> GetBedsByRoomId(int roomId)
        {
            List<Bed> beds = new List<Bed>();
            foreach(Bed bed in AllBeds)
            {
                if (bed.RoomId.Equals(roomId))
                {
                    beds.Add(bed);
                }
            }
            return beds;
        }

        public Bed GetBedById(int bedId)
        {
            Bed ret = null;
            foreach (Bed bed in AllBeds)
            {
                if (bed.BedId.Equals(bedId))
                {
                    ret = bed;
                    break;
                }
            }
            return ret;
        }
    }
}
