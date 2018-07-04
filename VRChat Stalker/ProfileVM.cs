﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace VRChat_Stalker
{
    public class ProfileVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public ProfileVM()
        {
#if DEBUG
            User = new VRCUser()
            {
                Id = "Test-ID",
                Name = "TEST NameLongLongHi",
                ImageUrl = @"http://www.personalbrandingblog.com/wp-content/uploads/2017/08/blank-profile-picture-973460_640-300x300.png",
                Star = 2,
                Location = "offline",
                StatusText = "Status TEST Hi ZZ",
            };
#endif
        }

        public VRChatApi.VRChatApi Vrc { get; set; }
        private VRCUser m_user = null;
        public VRCUser User
        {
            get { return m_user; }
            set
            {
                m_user = value;
                OnPropertyChanged("User");
            }
        }
    }
}