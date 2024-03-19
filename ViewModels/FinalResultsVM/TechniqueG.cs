using PsychTestsMilitary.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace PsychTestsMilitary.ViewModels.FinalResults
{
    public partial class TechniqueG : BaseResultsWindow, INotifyPropertyChanged
    {
        private UserMultipleAnswer[][] userAnswersMatrix;
        private const int matrixWidth = 3;
        private const int matrixHeight = 7;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public UserMultipleAnswer[][] UserAnswersMatrix
        {
            get { return userAnswersMatrix; }
            set 
            { 
                userAnswersMatrix = value; 
                OnPropertyChanged(nameof(UserAnswersMatrix)); 
            }
        }

        public TechniqueG() : base() { }

        public TechniqueG(List<ScaleResult> ur, string pd, string ctp, string tn, UserMultipleAnswer[] ua) : base(ur, pd, ctp, tn)
        {
            MakeUserAnswersViewable(ua);
            InitializeComponent();
            DataContext = this;
        }

        private async void MakeUserAnswersViewable(UserMultipleAnswer[] ua)
        {
            userAnswersMatrix = new UserMultipleAnswer[matrixWidth][];
            for (int i = 0; i < matrixWidth; i++)
            {
                userAnswersMatrix[i] = new UserMultipleAnswer[matrixHeight];
            }
            await Task.Run(() =>
            {
                for (int i = 0; i < matrixWidth; i++)
                {
                    for (int j = 0; j < matrixHeight; j++)
                    {
                        userAnswersMatrix[i][j] = ua[i * matrixWidth + j];
                    }
                }
            });

            UserAnswersMatrix = userAnswersMatrix;
        }
    }
}
