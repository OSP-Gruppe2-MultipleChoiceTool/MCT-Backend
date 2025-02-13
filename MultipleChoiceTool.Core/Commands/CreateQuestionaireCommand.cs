using MediatR;
using MultipleChoiceTool.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleChoiceTool.Core.Commands
{
    public class CreateQuestionaireCommand : IRequest<QuestionaireModel>
    {
        public CreateQuestionaireCommand(QuestionaireModel questionaire)
        {
            Questionaire = questionaire;
        }

        public QuestionaireModel Questionaire { get; }
    }
}