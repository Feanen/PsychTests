using PsychTestsMilitary.ViewModels;
using System;

namespace PsychTestsMilitary.ViewModels.TemplateViewModels
{
    public partial class TechniqueType3 : BaseTechniqueType
    {
        public TechniqueType3(BaseTechniqueModel td) : base(td)
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
    }
}
