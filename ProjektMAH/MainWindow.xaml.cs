﻿using System;
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



    public partial class MainWindow
    {
#region Variables
        public List<CriterionModel> CriterionLst;
        public List<AlternativeModel> AlternativeLst;
        public List<Relacja> RelacjaLST;
        public GoalModel Goal;
        public CriterionMatrixModel CriterionMatrix;
        public AlternativeMatrixModel AlternativeMatrix;
        public CriterionMatrix CrMatrix;

        #endregion
        public MainWindow()
        {
            AlternativeLst = new List<AlternativeModel>();
            CriterionLst = new List<CriterionModel>();
            CrMatrix = new CriterionMatrix();
            RelacjaLST = new List<Relacja>();
            //CriterionSliderValue.Text = "";

            InitializeComponent();
        }

#region Stwórz Model
        /// <summary>
        /// (Okno "Stwóz model") dodanie kryteriów do dataGrid CriteriumDG i do listy CriterionLst
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CriterionBtn_Click(object sender, RoutedEventArgs e)           // TU zacząć twórzyć matrix
        {
            if(CriterionTextBox.Text!="")
            {
                CriterionLst.Add(new CriterionModel(CriterionTextBox.Text));
                CryteriumDG.ItemsSource = CriterionLst;
                CryteriumDG.Items.Refresh();
            }



        }
        /// <summary>
        /// (Okno "Stwóz model") Czyści CriterionLst i datagrid CriteriumDG
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CriterionClearBtn_Click(object sender, RoutedEventArgs e)
        {
            CriterionLst.Clear();
            CryteriumDG.ItemsSource = null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AlternativeClearBtn_Click(object sender, RoutedEventArgs e)
        {
            AlternativeLst.Clear();
            AlternativeDG.ItemsSource = null;
        }
        /// <summary>
        /// Sprawdza czy dane są poprawne i tworzy pustą macierz kryteriów i dodaje do CB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AcceptBtn_Click(object sender, RoutedEventArgs e)
        {
            if (GoalTextBox.Text != "")
                Goal = new GoalModel() { Name = GoalTextBox.Text };
            else
                MessageBox.Show("error");
            foreach (var v in CriterionLst)
                CrMatrix.AddCriterion(v.Name); //mamy ilość
            ItemX.ItemsSource = CriterionLst.Select(x => x.Name);
            ItemY.ItemsSource = CriterionLst.Select(x => x.Name);


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
        #endregion


#region Kryteria Ocena
        private void ButtonSaveCriterionValue_Click(object sender, RoutedEventArgs e)
        {
            if (SliderValue.Value != 0)
            {
                CrMatrix.SetValue(ItemX.SelectedItem.ToString(), ItemY.SelectedItem.ToString(), SliderValue.Value);
                RelacjaLST.Add(new Relacja()
                {
                    C1 = ItemX.SelectedItem.ToString(),
                    C2 = ItemY.SelectedItem.ToString(),
                    V = SliderValue.Value
                });

                RelacjeDG.ItemsSource = RelacjaLST;
                RelacjeDG.Items.Refresh();
            }
            else
                MessageBox.Show("Podano złe parametry");

            
        }
#endregion

    }
}
