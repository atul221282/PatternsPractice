using System;
using System.Collections.Generic;
using System.Text;

namespace ConcoleApp.Contract
{
    public class RegisterOrderCommand : IRegisterOrderCommand
    {
        public string PickupName { get; set; }

        public string PickupAddress { get; set; }

        public string PickupCity { get; set; }

        public string DeliverName { get; set; }

        public string DeliverAddress { get; set; }

        public string DeliverCity { get; set; }

        public int Weight { get; set; }

        public bool Fragile { get; set; }

        public bool Oversized { get; set; }

        public RegisterOrderCommand()
        {
            this.Weight = 1;
            this.PickupName = "Atul Test" + " " + Guid.NewGuid().ToString();
            this.PickupAddress = "123456";
            this.PickupCity = "Address Test";
            this.DeliverName = "Atul Deleivery Name";
        }
    }
}
