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



    public partial class MainWindow
    {
#region Variables
        public List<CriterionModel> CriterionLst;
        public List<AlternativeModel> AlternativeLst;
        public List<Relacja> RelacjaLST;
        public List<Relacja> RelacjaALST;
        public List<AlternativeMatrix2>AM2;
        public GoalModel Goal;
        public CriterionMatrixModel CriterionMatrix;
        public CriterionMatrix CrMatrix;
        public AlternativeMatrix AlMatrix;

        #endregion
        public MainWindow()
        {
            AlternativeLst = new List<AlternativeModel>();
            CriterionLst = new List<CriterionModel>();
            AM2 = new List<AlternativeMatrix2>();
            CrMatrix = new CriterionMatrix();
            AlMatrix = new AlternativeMatrix();
            RelacjaLST = new List<Relacja>();
            RelacjaALST = new List<Relacja>();
            InitializeComponent();
        }

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
        private void AlternativeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AlternativeTextBox.Text != "")
            {
                AlternativeLst.Add(new AlternativeModel(AlternativeTextBox.Text));
                AlternativeDG.ItemsSource = AlternativeLst;
                AlternativeDG.Items.Refresh();
            }
        }

        private void AlternativeClearBtn_Click(object sender, RoutedEventArgs e)
        {
            AlternativeLst.Clear();
            AlternativeDG.ItemsSource = null;

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

            foreach (var v in AlternativeLst)
                AlMatrix.AddAlternative(v.Name); //mamy ilość
            ItemAX.ItemsSource = AlternativeLst.Select(x => x.Name);
            ItemAY.ItemsSource = AlternativeLst.Select(x => x.Name);


        }




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

        private void AcceptCryterionBtn_Click(object sender, RoutedEventArgs e)
        {
            //bool test = CrMatrix.Check();
            if(CrMatrix.Check() == false)
            {
                MessageBox.Show("Uzupełnij dane poprawnie");

            }
            else
            {
                CrMatrix.WyliczWartosci();
            }
        }

        private void ButtonSaveAlternativeValue_Click(object sender, RoutedEventArgs e)
        {
            if (SliderAValue.Value != 0)
            {
                AlMatrix.SetValue(ItemAX.SelectedItem.ToString(), ItemAY.SelectedItem.ToString(), SliderAValue.Value);
                RelacjaALST.Add(new Relacja()
                {
                    C1 = ItemAX.SelectedItem.ToString(),
                    C2 = ItemAY.SelectedItem.ToString(),
                    V = SliderAValue.Value
                });

                RelacjeADG.ItemsSource = RelacjaALST;
                RelacjeADG.Items.Refresh();
            }
            else
                MessageBox.Show("Podano złe parametry Alternatyw");

        }

        private void AcceptABtn_Click(object sender, RoutedEventArgs e)
        {
            if (AlMatrix.Check() == false)
            {
                MessageBox.Show("Uzupełnij dane poprawnie");

            }
            else
            {

                AlMatrix.WyliczWartosci();
            }
        }
    }
}
