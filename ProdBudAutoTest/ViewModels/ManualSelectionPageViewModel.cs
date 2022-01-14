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

            ManualSubmitCommand = new Command((obj) =>
            {
                NavigationService.NavigateAsync("CheckOperationPage");
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
                //        List<SubModel>
                var fileteredSubModels = results.Where(x => x.name.Equals(SelectedSubModel)).FirstOrDefault();
                Years = new ObservableCollection<int>( fileteredSubModels.sub_models.Select(x=>x.id));
                //var years = results.Select(l => l.name == SelectedSubModel).;

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


        private ObservableCollection<int> mYears;
        public ObservableCollection<int> Years
        {
            get { return mYears; }
            set
            {
                mYears = value;
                RaisePropertyChanged();
            }
        }

        

        List<string> ModelList = new List<string>
            {
               "Model 1", "Model 2", "Model 3", "Model 4", "Model 5", "Model 6",
            };
        List<string> SubModelList = new List<string>
            {
                "Sub Model 1","Sub Model 2","Sub Model 3","Sub Model 4","Sub Model 5","Sub Model 6",
            };
        List<string> ModelYearList = new List<string>
            {
                "Year 1","Year 2","Year 3","Year 4","Year 5","Year 6"
            };

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            var models = await _apiServices.GetAllModelsAsync();
            this.results = models.results;
        }
        public ICommand ManualSubmitCommand { get; set; }

        public async void GoToNextPgae()
        {
            IsBusy = true;
            try
            {
                var year = ""; //selectedyesr from submodel  
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
        }
    }
}
