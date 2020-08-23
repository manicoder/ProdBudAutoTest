using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ProdBudAutoTest.Models
{
    public class VehicleInfoModel : INotifyPropertyChanged
    {
        public string Result { get; set; }
        public string VinNo { get; set; }
        public string Desc { get; set; }
        public string TestType { get; set; }

        private bool mIsFail;
        public bool IsFail
        {
            get { return mIsFail; }
            set
            {
                mIsFail = value;
                RaisePropertyChanged();
            }
        }
        private bool mIsPass;
        public bool IsPass
        {
            get { return mIsPass; }
            set
            {
                mIsPass = value;
                RaisePropertyChanged();
            }
        }
        private bool mIsNil;
        public bool IsNil
        {
            get { return mIsNil; }
            set
            {
                mIsNil = value;
                RaisePropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
