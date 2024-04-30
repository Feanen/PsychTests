using PsychTestsMilitary.Services;
using System;
using System.Windows;
using System.Windows.Media;

namespace PsychTestsMilitary.ViewModels.TemplateViewModels
{
    public partial class TechniqueType1 : BaseTechniqueType
    {
        public TechniqueType1(BaseTechniqueModel td) : base(td)
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

        private void AnswerSelected(object sender, EventArgs e)
        {
            AnswerSelected(sender, e, nextButton);
        }

        private void ShowNextQuestion(object sender, EventArgs e)
        {
            ShowNextQuestion(sender, e, answerButtonsGrid, nextButton);
        }

        public override void OnFullScreen()
        {
            SetWindowScale(mainGrid, ScreenManager.SetDynamicFullScreen());
        }
    }
}
