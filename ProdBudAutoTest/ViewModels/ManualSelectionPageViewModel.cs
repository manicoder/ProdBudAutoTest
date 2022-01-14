using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Prodat.AppHelpers;
using Prodat.Models;
using Proddat.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProdBudAutoTest.ViewModels
{
    public class ManualSelectionPageViewModel : ViewModelBase
    {
        IApiServices _apiServices;
        List<ModelResult> results = null;

        public ManualSelectionPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IApiServices apiServices) : base(navigationService, pageDialogService)
        {
            _apiServices = apiServices;
            results = new List<ModelResult>();

            string[] segments = { "BSIII", "BSIV", "BSVI", "GENRIC" };
            Segments = new ObservableCollection<string>(segments);

            ManualSubmitCommand = new Command(async (obj) =>
            {
                if (!string.IsNullOrEmpty(SelectedYear))
                {
                    if (await GoToNextPgae())
                    {
                        NavigationService.NavigateAsync("CheckOperationPage");
                    }
                    else
                    {
                        PageDialogService.DisplayAlertAsync("Not Found", "Model not found!", "OK");
                    }
                }                
            });

        }

        private string mSelectedSegment;
        public string SelectedSegment
        {
            get { return mSelectedSegment; }
            set
            {
                mSelectedSegment = value;
                SubModels = new ObservableCollection<string>(results.Select(l => l.name).Where(x => x.Contains(SelectedSegment)));
                Years = new ObservableCollection<string>();
                RaisePropertyChanged();
            }
        }

        private string mSelectedSubModel;
        public string SelectedSubModel
        {
            get { return mSelectedSubModel; }
            set
            {
                mSelectedSubModel = value;
                var fileteredSubModels = results.Where(x => x.name.Equals(SelectedSubModel)).FirstOrDefault();
                if (fileteredSubModels != null)
                {
                    Years = new ObservableCollection<string>();
                    foreach (var item in fileteredSubModels.sub_models)
                    {
                        Years.Add(Convert.ToString(item.id));
                    }
                }
                RaisePropertyChanged();
            }
        }

        private string mSelectedYear;
        public string SelectedYear
        {
            get { return mSelectedYear; }
            set
            {
                mSelectedYear = value;
                RaisePropertyChanged();
            }
        }



        private ObservableCollection<string> mSegments;
        public ObservableCollection<string> Segments
        {
            get { return mSegments; }
            set
            {
                mSegments = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<string> mSubModels;
        public ObservableCollection<string> SubModels
        {
            get { return mSubModels; }
            set
            {
                mSubModels = value;
                RaisePropertyChanged();
            }
        }


        private ObservableCollection<string> mYears;
        public ObservableCollection<string> Years
        {
            get { return mYears; }
            set
            {
                mYears = value;
                RaisePropertyChanged();
            }
        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            var models = await _apiServices.GetAllModelsAsync();
            this.results = models.results;
        }
        public ICommand ManualSubmitCommand { get; set; }

        public async Task<bool> GoToNextPgae()
        {
            IsBusy = true;
            bool isFound = false;
            try
            {
                var year = this.SelectedYear;
                if (!string.IsNullOrEmpty(Convert.ToString(year)))
                {
                    var id = KeyStorage.Get("ID");
                    var allStations = await this._apiServices.GetStationDataAsync();

                    foreach (var item in allStations.results)
                    {
                        if (item.id == Convert.ToInt32(id))
                        {
                            foreach (var pro in item.process.sp_process)
                            {
                                if (pro.year == Convert.ToInt32(year))
                                {
                                    Services.CurrentProcess.Instance.Proccess = pro;
                                    isFound = true;
                                    break;
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
            IsBusy = false;
            return false;
        }
    }
}
