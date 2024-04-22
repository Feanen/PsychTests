﻿using System;
using System.Windows.Media;
using System.Windows;

namespace PsychTestsMilitary.ViewModels.TemplateViewModels
{
    public partial class TechniqueType7 : BaseTechniqueType
    {
        public TechniqueType7(BaseTechniqueModel td) : base(td)
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
            SetWindowScale(mainGrid, new ScaleTransform(1.28, 1.28));
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
