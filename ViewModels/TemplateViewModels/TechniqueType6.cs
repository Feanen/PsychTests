using System;
using System.Windows.Media;
using System.Windows;
using PsychTestsMilitary.Services;

namespace PsychTestsMilitary.ViewModels.TemplateViewModels
{
    public partial class TechniqueType6 : BaseTechniqueType
    {
        public TechniqueType6(BaseTechniqueModel td) : base(td)
        {
            InitializeComponent();
            InitTechnique();
        }

        protected override void InitTechnique()
        {
            Technique = TechniqueData.Technique;

            if (TechniqueData != null)
                Update(TechniqueData.NextQuestion(), nextButton);
        }

        public override void OnFullScreen()
        {
            SetWindowScale(mainGrid, ScreenManager.SetDynamicFullScreen());
        }

        private void AnswerSelected(object sender, EventArgs e)
        {
            AnswerSelected(sender, e, nextButton);
        }

        private void ShowNextQuestion(object sender, EventArgs e)
        {
            ShowNextQuestion(sender, e, answerButtonsGrid, nextButton);
        }
    }
}
