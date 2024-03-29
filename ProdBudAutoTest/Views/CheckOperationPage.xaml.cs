﻿using CarouselView.FormsPlugin.Abstractions;
using ProdBudAutoTest.Controls;
using ProdBudAutoTest.Models;
using ProdBudAutoTest.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace ProdBudAutoTest.Views
{
    public partial class CheckOperationPage : ContentPage
    {
        List<View> processView = null;

        public CheckOperationPage()
        {
            InitializeComponent();
            processView = new List<View>();
        }

        private void StepInitiliase()
        {
            var vm = this.BindingContext as CheckOperationPageViewModel;
            var currentProcess = Services.CurrentProcess.Instance.Proccess;
            if (currentProcess == null) return;
            var orderByProcess = currentProcess.station_process.OrderBy(x => x.priority);
            vm.TotalSteps = orderByProcess.Count();
            stepProcessFooter.BindingContext = orderByProcess;
            foreach (var process in orderByProcess)
            {
                process.station_process_steps = process.station_process_steps.Where(x => x.description != null).OrderBy(x => x.priority).ToList();
                var procesStepControl = new ProcessStepControl
                {
                    BindingContext = process
                };
                processView.Add(procesStepControl);

                //var headerName = process.name;
                // var allSteps = process.station_process_steps;
                //var VehicleInfoList = new ObservableCollection<VehicleInfoModel>();
                //foreach (var step in allSteps)
                //{ step.description
                //   // VehicleInfoList.Add(new VehicleInfoModel() { TestType = step.chassis_api_pid, Desc = "MC2XXXX", Result = "Pass", IsPass = true });

                //}
            }
            if (processView.Count > 0)
            {
                var finalStep = new Step6View();
                finalStep.BindingContext = orderByProcess;
                processView.Add(finalStep);
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            StepInitiliase();
            this.crouselView.ItemsSource = processView;

        }
        private void Button_Clicked_1(object sender, System.EventArgs e)
        {
            Utils.AppUtils.CurrentStep = 1;
        }

        private void Button_Clicked_2(object sender, System.EventArgs e)
        {
            Utils.AppUtils.CurrentStep = 2;
        }

        private void Button_Clicked_3(object sender, System.EventArgs e)
        {
            Utils.AppUtils.CurrentStep = 3;
        }

        private void crouselView_SizeChanged(object sender, System.EventArgs e)
        {
            var aa = sender as CarouselViewControl;
            var h = aa.Height;
            var hr = aa.HeightRequest;
        }

        private void Frame_SizeChanged(object sender, System.EventArgs e)
        {
            var aa = sender as Frame;
            var h = aa.Height;
            var hr = aa.HeightRequest;
        }
    }
}
