using System;
using System.Collections;
using System.Collections.Generic;

namespace _08.PetClinic
{
    public class Clinic : IEnumerable<Pet>
    {
        private Pet[] pets;
        private int rooms;
        private Queue<int> roomsRow;
        
        public int Rooms
        {
            get { return this.rooms; }
            private set
            {
                if(value % 2 == 0)
                {
                    throw new ArgumentException("The rooms count cannot be an even number!");
                }

                this.rooms = value;
            }
        }

        public string Name { get; }

        public Clinic(string name, int rooms)
        {
            this.Rooms = rooms;
            this.pets = new Pet[this.Rooms];
            this.Name = name;
            this.roomsRow = InitRooms();
        }

        private Queue<int> InitRooms()
        {
            var roomsRow = new Queue<int>();
            int skiper = 1;
            int emptyRooms = this.rooms - 1;
            int middleRoom = (rooms / 2) + 1;
            int currentRoom = middleRoom;
            roomsRow.Enqueue(currentRoom);
            
            while(emptyRooms > 0)
            {
                if(currentRoom < middleRoom)
                {
                    currentRoom = middleRoom + skiper;
                    skiper++;
                }
                else
                {
                    currentRoom = middleRoom - skiper;
                }
                roomsRow.Enqueue(currentRoom);
                emptyRooms--;
            }

            return roomsRow;
        }

        public bool AddNewPet(IPet pet)
        {
            if(this.roomsRow.Count == 0)
            {
                return false;
            }

            int currentRoom = this.roomsRow.Dequeue();

            this.pets[currentRoom] = (Pet)pet;
            return true;
        }

        public bool HasEmptyRooms()
        {
            return this.roomsRow.Count > 0;
        }

        public IEnumerator<Pet> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
