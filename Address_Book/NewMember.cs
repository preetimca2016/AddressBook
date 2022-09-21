using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book
{
    class NewMember
    {
        ////getter and setter property for getting setting details.
        public string FirstName
        {
            get;
            set;
        }
        public string LastName
        {
            get;
            set;
        }
        public string Address
        {
            get;
            set;
        }
        public string City
        {
            get;
            set;
        }
        public string State
        {
            get;
            set;
        }
        public string PinCode
        {
            get;
            set;
        }
        public string PhoneNumber
        {
            get;
            set;
        }
        public string EmailId
        {
            get;
            set;
        }
        public override string ToString()
        {
            return "Name: " + this.FirstName + this.LastName + " ,Address: " + this.Address + "  ,City: " + this.City + " ,State: " + this.State + " ,Pincode: " + this.PinCode + " ,phonenumber: " + this.PhoneNumber + " ,emailId: " + this.EmailId;
        }
    }
}
