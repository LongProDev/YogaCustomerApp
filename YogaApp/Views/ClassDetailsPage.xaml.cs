using Microsoft.Maui.Controls;           
using System;
using System.Threading.Tasks;
using YogaApp.ViewModels;               
using YogaApp.Models;
namespace YogaApp.Views
{
    public partial class ClassDetailsPage : ContentPage
    {
        private readonly ClassDetailsViewModel _viewModel;

        public ClassDetailsPage(ClassDetailsViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }

        protected override async void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);

            if (args.Parameter is int classInstanceId)
            {
                await _viewModel.LoadClassDetails(classInstanceId);
            }
        }
    }
}
