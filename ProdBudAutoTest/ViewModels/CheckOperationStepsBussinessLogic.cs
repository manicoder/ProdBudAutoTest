using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProdBudAutoTest.ViewModels
{
    public partial class CheckOperationPageViewModel
    {
        private async void StepsInitCommand()
        {
            SetStepProgress(1);
            StepProgressCommand = new Command(async () =>
            {
                var step = CurrentStepPosition + 2;
                CurrentStepPosition += 1;
                if (step <= 5)
                {
                    IsBusy = true;
                    await Task.Delay(TimeSpan.FromSeconds(3));
                    IsBusy = false;
                }
                SetStepProgress(step);
            });
        }
        private bool mIsStep1Pass;
        public bool IsStep1Pass
        {
            get { return mIsStep1Pass; }
            set
            {
                mIsStep1Pass = value;
                RaisePropertyChanged();
            }
        }

        private bool mIsStep2Pass;
        public bool IsStep2Pass
        {
            get { return mIsStep2Pass; }
            set
            {
                mIsStep2Pass = value;
                RaisePropertyChanged();
            }
        }

        private bool mIsStep3Pass;
        public bool IsStep3Pass
        {
            get { return mIsStep3Pass; }
            set
            {
                mIsStep3Pass = value;
                RaisePropertyChanged();
            }
        }

        private bool mIsStep4Pass;
        public bool IsStep4Pass
        {
            get { return mIsStep4Pass; }
            set
            {
                mIsStep4Pass = value;
                RaisePropertyChanged();
            }
        }

        private bool mIsStep5Pass;
        public bool IsStep5Pass
        {
            get { return mIsStep5Pass; }
            set
            {
                mIsStep5Pass = value;
                RaisePropertyChanged();
            }
        }

        private bool mIsStep6Pass;
        public bool IsStep6Pass
        {
            get { return mIsStep6Pass; }
            set
            {
                mIsStep6Pass = value;
                RaisePropertyChanged();
            }
        }

        private bool mIsStep1Done;
        public bool IsStep1Done
        {
            get { return mIsStep1Done; }
            set
            {
                mIsStep1Done = value;
                RaisePropertyChanged();
            }
        }

        private bool mIsStep2Done;
        public bool IsStep2Done
        {
            get { return mIsStep2Done; }
            set
            {
                mIsStep2Done = value;
                RaisePropertyChanged();
            }
        }

        private bool mIsStep3Done;
        public bool IsStep3Done
        {
            get { return mIsStep3Done; }
            set
            {
                mIsStep3Done = value;
                RaisePropertyChanged();
            }
        }

        private bool mIsStep4Done;
        public bool IsStep4Done
        {
            get { return mIsStep4Done; }
            set
            {
                mIsStep4Done = value;
                RaisePropertyChanged();
            }
        }

        private bool mIsStep5Done;
        public bool IsStep5Done
        {
            get { return mIsStep5Done; }
            set
            {
                mIsStep5Done = value;
                RaisePropertyChanged();
            }
        }

        private bool mIsStep6Done;
        public bool IsStep6Done
        {
            get { return mIsStep6Done; }
            set
            {
                mIsStep6Done = value;
                RaisePropertyChanged();
            }
        }
        public async void SetStepProgress(int currentStep)
        {
            switch (currentStep)
            {
                case 1:
                    IsStep1Pass = true;
                    IsStep1Done = true;
                    break;
                case 2:
                    IsStep2Pass = false;
                    IsStep2Done = true;
                    break;
                case 3:
                    IsStep3Pass = true;
                    IsStep3Done = true;
                    break;
                case 4:
                    IsStep4Pass = true;
                    IsStep4Done = true;
                    break;
                case 5:
                    IsStep5Pass = true;
                    IsStep5Done = true;
                    break;
                case 6:
                    IsStep6Pass = true;
                    IsStep6Done = true;
                    break;
                default:
                    break;
            }
        }

        public ICommand StepProgressCommand { get; set; }
    }
}
