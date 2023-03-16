using System;

namespace EnglishCentreManagement.Model
{
    class Notice
    {
        private string IDSender;
        private string IDReceiver;
        private string Description;
        public string idsender
        {
            get { return this.IDSender; }
            set
            {
                if (value == null)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must be not null");
                this.IDSender = value;
            }
        }
        public string idreceiver
        {
            get { return this.IDReceiver; }
            set
            {
                if (value == null)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must be not null");
                this.IDReceiver = value;
            }
        }
        public string description
        {
            get { return this.Description; }
            set { this.description = value; }
        }
    }
}
