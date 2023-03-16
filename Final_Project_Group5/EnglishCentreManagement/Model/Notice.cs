using System;

namespace EnglishCentreManagement.Model
{
    class Notice
    {
        private string idSender;
        private string idReceiver;
        private string description;
        public string IDSender
        {
            get { return this.idSender; }
            set
            {
                if (value == null)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must be not null");
                this.idSender = value;
            }
        }
        public string IDReceiver
        {
            get { return this.idReceiver; }
            set
            {
                if (value == null)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must be not null");
                this.idReceiver = value;
            }
        }
        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }
    }
}
