namespace Computers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class HardDriver
    {
        private int capacity;

        private int hardDrivesInRaid;

        private IList<HardDriver> hardDrives;

        private SortedDictionary<int, string> data;

        private bool isInRaid;

        internal HardDriver(int capacity, bool isInRaid, int hardDrivesInRaid)
        {
            this.capacity = capacity;
            this.isInRaid = isInRaid;
            this.hardDrivesInRaid = hardDrivesInRaid;
            this.data = new SortedDictionary<int, string>();
            this.hardDrives = new List<HardDriver>();
        }

        internal HardDriver(int capacity, bool isInRaid, int hardDrivesInRaid, IList<HardDriver> hardDrives)
        {
            this.capacity = capacity;
            this.isInRaid = isInRaid;
            this.hardDrivesInRaid = hardDrivesInRaid;
            this.data = new SortedDictionary<int, string>();
            this.hardDrives = hardDrives;
        }

        private int Capacity
        {
            get
            {
                if (this.isInRaid)
                {
                    if (!this.hardDrives.Any())
                    {
                        return 0;
                    }

                    return this.hardDrives.First().Capacity;
                }

                return this.capacity;
            }
        }

        private void SaveData(int addr, string newData)
        {
            if (this.isInRaid)
            {
                foreach (var hardDrive in this.hardDrives)
                {
                    hardDrive.SaveData(addr, newData);
                }
            }
            else
            {
                this.data[addr] = newData;
            }
        }

        private string LoadData(int address)
        {
            if (this.isInRaid)
            {
                if (!this.hardDrives.Any())
                {
                    throw new OutOfMemoryException("No hard drive in the RAID array!");
                }

                return this.hardDrives.First().LoadData(address);
            }

            if (true)
            {
                return this.data[address];
            }
        }
    }
}