using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_8
{
    class Contact
    {
        private string fio;
        private string street;
        private int homeNumber;
        private int apartmentNumber;
        private ulong mobileNumber;
        private int homePhoneNumber;

        public string FIO
        {
            get 
            {
                return fio;
            }
            set 
            {
                fio = value;
            }
        }

        public string Street
        {
            get
            {
                return street;
            }
            set
            {
                street = value;
            }
        }

        public int HomeNumber
        {
            get
            {
                return homeNumber;
            }
            set
            {
                homeNumber = value;
            }
        }

        public int Apartment
        {
            get
            {
                return apartmentNumber;
            }
            set
            {
                apartmentNumber = value;
            }
        }

        public ulong MobileNUmber
        {
            get
            {
                return mobileNumber;
            }
            set
            {
                mobileNumber = value;
            }
        }

        public int HomePhoneNumber
        {
            get
            {
                return homePhoneNumber;
            }
            set
            {
                homePhoneNumber = value;
            }
        }
    }
}
