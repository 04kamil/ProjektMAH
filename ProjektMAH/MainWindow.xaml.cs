using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using ProjektMAH.Models;

namespace ProjektMAH
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow
    {
#region Variables
        public List<CriterionModel> CriterionLst;
        public List<AlternativeModel> AlternativeLst;
        public GoalModel Goal;
        public CriterionMatrixModel CriterionMatrix;
        public AlternativeMatrixModel AlternativeMatrix;

        #endregion
        public MainWindow()
        {
            AlternativeLst = new List<AlternativeModel>();
            CriterionLst = new List<CriterionModel>();
            //CriterionSliderValue.Text = "";

            InitializeComponent();
        }

        private void CriterionBtn_Click(object sender, RoutedEventArgs e)           // TU zacząć twórzyć matrix
        {
            if(CriterionTextBox.Text!="")
            {
                CriterionLst.Add(new CriterionModel(CriterionTextBox.Text));
                CryteriumDG.ItemsSource = CriterionLst;
                CryteriumDG.Items.Refresh();
            }



        }

        private void CriterionClearBtn_Click(object sender, RoutedEventArgs e)
        {
            CriterionLst.Clear();
            CryteriumDG.ItemsSource = null;
        }

        private void AlternativeClearBtn_Click(object sender, RoutedEventArgs e)
        {
            AlternativeLst.Clear();
            AlternativeDG.ItemsSource = null;
        }

        private void AcceptBtn_Click(object sender, RoutedEventArgs e)
        {
            if (GoalTextBox.Text != "")
                Goal = new GoalModel() { Name = GoalTextBox.Text };
            else
                MessageBox.Show("error");
            CriterionMatrix = new CriterionMatrixModel(CriterionLst.Count);



            //for (int i = 0; i < CriterionLst.Count; i++)
            //{

            //    CriterionRelationStackPanel.Children.Add(new TextBlock() { Margin = new Thickness(10), TextAlignment = TextAlignment.Center, FontSize = 26, Foreground = Brushes.Gray, Text = CriterionLst[i].Name });
            //    //int j = i;
            //    for (int j = i + 1; j < CriterionLst.Count; j++)
            //    {
            //        StackPanel st = new StackPanel() { Orientation = Orientation.Horizontal };
            //        st.Children.Add(new TextBlock() { Margin = new Thickness(10), TextAlignment = TextAlignment.Center, FontSize = 26, Foreground = Brushes.Gray, Text = CriterionLst[j].Name });
            //        st.Children.Add(new Slider() { Minimum = 1, Maximum = 9, Width = 200, AutoToolTipPlacement = System.Windows.Controls.Primitives.AutoToolTipPlacement.BottomRight, AutoToolTipPrecision = 0 });
            //        CriterionRelationStackPanel.Children.Add(st);
            //    }
            //    //CriterionRelationStackPanel.Children.Add(new Button() {Content="Add" });
            //    CriterionRelationStackPanel.Children.Add(new Separator() { Background = Brushes.LightCoral, Margin = new Thickness(10) });

            //}

        }

        private void AlternativeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AlternativeTextBox.Text != "")
            {
                AlternativeLst.Add(new AlternativeModel(AlternativeTextBox.Text));
                AlternativeDG.ItemsSource = AlternativeLst;
                AlternativeDG.Items.Refresh();
            }
        }

        //private void CriterionAddRelationBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    //TUUUUUUUUU
        //    List<CriterionPairModel> cp = new List<CriterionPairModel>();
        //    //foreach(object tb in CriterionRelationStackPanel.Children)
        //    //{
        //    //    string text = 
        //    //}
        //    var containerOfFirest = CriterionRelationStackPanel.Children.OfType<TextBlock>();
        //    var containerOfRest = CriterionRelationStackPanel.Children.OfType<StackPanel>();
        //    //int i = containerOfFirest.Count;
        //    //Adresy 
        //    for(int i=0;i<containerOfFirest.Count(); i++)
        //    {

        //    }
        //}

        private void ButtonSaveCriterionValue_Click(object sender, RoutedEventArgs e)
        {

        }

        //private void CriterionSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{
        //    if ((sender as Slider).Value == 0)
        //        (sender as Slider).Value = 1;
        //}

        //private void CriterionSlider_SizeChanged(object sender, SizeChangedEventArgs e)
        //{
        //    //CriterionSliderValue.Text=CriterionSlider.Value.ToString();
        //}

        //private void CriterionSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{
        //    //CriterionSliderValue.Text = CriterionSlider.Value.ToString();

        //}
    }
}
